using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemBtn : MonoBehaviour, IInteractable
{
    public Animator animator;
    //entities functionality goes here
    public void ActionFunction()
    {
        Debug.Log("test");
        animator.SetBool("RoomOpen", true);
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

