using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTeleporter : MonoBehaviour, IInteractable
{
    public int GameScene;
    public GameObject Portal;
    public Collider TeleporterCollider;
    // public GameObject PortalObject;
    
    
    //entities functionality goes here
    public void ActionFunction()
    {
        Portal.SetActive(true);
        // TeleporterCollider.SetActive(true);
        TeleporterCollider = TeleporterCollider.GetComponent<CapsuleCollider>();
        TeleporterCollider.enabled = !TeleporterCollider.enabled;
        
    
    }

    
    //Interactable stuff
    //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

    public void CallActionFunction()
    {
        ActionFunction();
    }

    public string GetInteractText()
    {
        return "Initialise";
    }

    void IInteractable.Interact(Transform InteractorTransform)
    {
        CallActionFunction();
    }

    public Transform GetTransform()
    {
        // Debug.Log("got transform");
        return transform;
    }
}



