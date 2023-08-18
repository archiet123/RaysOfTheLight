using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRooms : MonoBehaviour
{
    public Animator animator;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") ;
        {
            LockAllDoors();
        }
    }

    public void LockAllDoors()
    {
        // animator.SetBool("LockAllDoors", true); use this one
        animator.SetBool("RoomLock", true);
        Debug.Log("lock all doors");
    }
}