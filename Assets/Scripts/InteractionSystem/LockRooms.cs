using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRooms : MonoBehaviour
{
    public Animator animator;

    //List of completed rooms
    public List<string> CompletedRooms;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") ;
        {
            string CurrentRoom = (gameObject.tag);
            if (CompletedRooms.Contains(CurrentRoom))
            {
                Debug.Log("completed: " + CurrentRoom);
            }
            else
            {
                CompletedRooms.Add(CurrentRoom);
                // animator.SetBool("RoomOpen", true);
                LockAllDoors();
                SpawnEnemies(CurrentRoom);
            }
        }
    }

    public void SpawnEnemies(string CurrentRoom)
    {
        Debug.Log(CurrentRoom);
    }

    public void LockAllDoors()
    {
        // animator.SetBool("LockAllDoors", true); use this one
        animator.SetBool("RoomLock", true);
        Debug.Log("lock all doors");

    }
}