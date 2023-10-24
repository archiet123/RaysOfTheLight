using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyDoors : MonoBehaviour
{
    // public GameObject DoorCollider;
    public Animator animator;

    private void OnCollisionEnter(Collision CollsionObject)
    {
        Debug.Log(CollsionObject.gameObject.tag);
        animator.SetBool("DoorTrigger", true);
    }

    private void OnCollisionExit(Collision CollsionObject)
    {
        animator.SetBool("DoorTrigger", false);
    }

    private void OnTriggerEnter(Collider CollsionObject)
    {
        // Debug.Log(CollsionObject.gameObject.tag);
        animator.SetBool("DoorTrigger", true);
    }

    private void OnTriggerExit(Collider CollsionObject)
    {
        animator.SetBool("DoorTrigger", false);
    }
}
