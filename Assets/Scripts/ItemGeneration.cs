using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
public class ItemGeneration : MonoBehaviour, IInteractable
{
    public GameObject items;
    public int itemOption;

    [SerializeField]
    private string RandomItemName;

    //List of possible perks
    string[] AllItems = new string[] { "GoFast", "DamageIncrease", "MoreHealth", "Armour", "HighCapacityMagazine", "ShootFaster" };
    //items to add: "Akdov", "FabergeEgg", "MouldyTurnip", "JarOfBees", "Beans",

    //calc length of item list
    //output random string from 0,length of list
    //GameObject.Find corresponding Named script on Spawned perk 'item'
    //This methods means that all unique ability scripts will be stored on the spawned items,
    //this logic just sets one to active at random and 



    public void Start()
    {
    }

    public void GetRandomInt()
    {
        //Gets random number from 0 to length of list,
        //will be used to get index of perk
        int RandInt = Random.Range(0, AllItems.Length);
        RandomItemName = AllItems[RandInt];
    }


    public void ActionFunction()
    {
        gameObject.SendMessage("RecievePerkName", RandomItemName);
        //play item animation disappear
        Invoke("DestroySpawnedItems", 0.2f);
    }

    public void DestroySpawnedItems()
    {
        items.SetActive(false);
    }

    void OnEnable()
    {
        //resets items when spawned
        GetRandomInt();
    }

    //Interactable stuff
    //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

    public void CallActionFunction()
    {
        ActionFunction();
    }

    public string GetInteractText()
    {
        return $"Pick Item {RandomItemName}";
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
