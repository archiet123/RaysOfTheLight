using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTeleporter : MonoBehaviour, IInteractable
{
    public int GameScene;
    public GameObject Portal;
    public Collider TeleporterCollider;

    //to make sure the player always spawns with pistol and shotgun
    public void Awake()
    {
        PlayerPrefs.SetInt("Slot1Weapon", 0);
        PlayerPrefs.SetInt("Slot2Weapon", 1);

        //perks
        PlayerPrefs.SetFloat("WeaponRateOfFire", 0.3f);
        PlayerPrefs.SetInt("PlayerSpeedCounter", 0);
        PlayerPrefs.SetInt("CameraFOVCounter", 0);
    }
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



