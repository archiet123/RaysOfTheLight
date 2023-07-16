using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    //bools
    public bool DisableInteract = false;

    private void Update()
    {
        //if E is clicked within range on an entity NpcInteracable is called, 
        //functionality for that entity is run on NpcInteractable.
        if (Input.GetKeyDown(KeyCode.E))
        {
            //if DisableInteract is true the player wont be able to initiate an interaction,
            //this way E can be use to skip sentances
            if (DisableInteract)
            {
                // Debug.Log("disable interact");
            }
            else
            {
                // Debug.Log("enable interact");
                IInteractable interactable = GetInteractableObject();
                if (interactable != null)
                {
                    // Debug.Log("e click");
                    interactable.Interact(transform);
                }
                else
                {
                    // Debug.Log("false");
                }
            }
        }
    }

    public void GetBool(bool TalkingToNPC)
    {
        DisableInteract = TalkingToNPC;
        // DisableInteract = true;

    }

    public void DialogueEnded(bool DialogueEnded)
    {
        DisableInteract = DialogueEnded;
        // DisableInteract = true;
    }

    public IInteractable GetInteractableObject()
    {
        //script for displaying interaction prompt, also checking for closest possible entity
        float InteractRange = 4f;
        List<IInteractable> interactableList = new List<IInteractable>();
        Collider[] ColliderArray = Physics.OverlapSphere(transform.position, InteractRange);
        foreach (Collider Collider in ColliderArray)
        {
            if (Collider.TryGetComponent(out IInteractable interactable))
            {
                interactableList.Add(interactable);
                // return interactable;
            }
        }
        IInteractable closestInteractable = null;
        foreach (IInteractable interactable in interactableList)
        {
            if (closestInteractable == null)
            {
                closestInteractable = interactable;
            }
            else
            {
                if (Vector3.Distance(transform.position, interactable.GetTransform().position) <
                    Vector3.Distance(transform.position, closestInteractable.GetTransform().position))
                {
                    //closest interactable.
                    closestInteractable = interactable;
                    // Debug.Log(closestInteractable);
                }
            }
        }

        return closestInteractable;
    }
}
