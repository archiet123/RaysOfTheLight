using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClosing : MonoBehaviour
{
    public Animator animator;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") ;
        {
            CloseFrontDoor();
        }
    }

    public void CloseFrontDoor()
    {
        // animator.SetBool("LockFrontDoor", true);
        // Debug.Log("close front door");
    }
}