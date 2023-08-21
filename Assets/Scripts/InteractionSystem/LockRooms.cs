using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRooms : MonoBehaviour
{
    //enemies to set active
    private GameObject EnemySpawn;

    public Animator animator;

    //List of completed rooms
    public List<string> CompletedRooms;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            string CurrentRoom = (gameObject.tag);
            if (CompletedRooms.Contains(CurrentRoom))
            {
                // Debug.Log("previously completed");
            }
            else
            {
                CompletedRooms.Add(CurrentRoom);
                LockAllDoors();
                SpawnEnemies(CurrentRoom);
            }
        }
        else
        {
            // Debug.Log("enemy");
        }
    }

    public void SpawnEnemies(string EnemySpawn)
    {
        //sets the enemy container in the hieracy to true and 'spawns' enemies
        GameObject.Find(EnemySpawn).transform.GetChild(0).gameObject.SetActive(true);
    }

    public void LockAllDoors()
    {
        animator.SetBool("RoomLock", true);
    }
}