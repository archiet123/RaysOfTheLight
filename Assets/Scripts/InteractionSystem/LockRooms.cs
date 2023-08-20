using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRooms : MonoBehaviour
{
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
                CompletedRooms.Add(CurrentRoom);
                LockAllDoors();
                SpawnEnemies(CurrentRoom);
            }
        }
        else
        {
            Debug.Log("enemy");
        }
    }

    public void SpawnEnemies(string CurrentRoom)
    {
        Debug.Log(CurrentRoom);
    }

    public void LockAllDoors()
    {
        animator.SetBool("RoomLock", true);
        // Debug.Log("lock all doors");
    }
}