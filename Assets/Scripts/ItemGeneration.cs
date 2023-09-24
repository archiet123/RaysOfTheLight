using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGeneration : MonoBehaviour, IInteractable
{
    public GameObject items;
    public int itemOption;

    //List of possible perks
    string[] AllItems = new string[] { "Akdov", "FabergeEgg", "MouldyTurnip", "JarOfBees", "Beans", };

    public void Start()
    {
        int test = AllItems.Length;
        Debug.Log(test);
        //calc length of item list
        //output random string from 0,length of list
        //GameObject.Find corresponding Named script on Spawned perk 'item'
        //

        //This methods means that all unique ability scripts will be stored on the spawned items,
        //this logic just sets one to active at random and 
    }
    public void ActionFunction()
    {
        Debug.Log($"Item {itemOption} selected");
        items.SetActive(false);
    }

    //Interactable stuff
    //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

    public void CallActionFunction()
    {
        ActionFunction();
    }

    public string GetInteractText()
    {
        return $"Pick Item {itemOption}";
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
