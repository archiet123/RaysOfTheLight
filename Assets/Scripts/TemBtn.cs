using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemBtn : MonoBehaviour, IInteractable
{
    //Door animator
    public Animator animator;

    public void ActionFunction()
    {
        animator.SetBool("RoomOpen", true);
        animator.SetBool("RoomLock", false);
    }

    //Interactable stuff
    //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

    public void CallActionFunction()
    {
        ActionFunction();
    }

    public string GetInteractText()
    {
        return "Action here";
        Debug.Log("clickable");
    }

    void IInteractable.Interact(Transform InteractorTransform)
    {
        CallActionFunction();
    }

    public Transform GetTransform()
    {
        Debug.Log("got transform");
        return transform;
    }
}

