using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRooms : MonoBehaviour
{
    //refrence to Checklvl
    public CheckLevel checkLevel;

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
                Debug.Log("previously completed");
            }
            else
            {
                Debug.Log("entered");
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
        //resetting deathcounter to 0
        checkLevel.TotalDead = 0;

        //sets the enemy container in the hieracy to true and 'spawns' enemies#endregion
        GameObject.Find(EnemySpawn).transform.GetChild(0).gameObject.SetActive(true);
    }

    public void LockAllDoors()
    {
        animator.SetBool("RoomLock", true);
    }
}