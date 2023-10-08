using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
public class ItemGeneration : MonoBehaviour, IInteractable
{
    public VendingMachineScript vendingMachineScript;
    public GameObject SetObject;
    public GameObject items;
    [SerializeField] private string RandomItemName;
    private int RandInt;
    private Vector3 ItemVector;

    //List of possible perks
    //make this a dictionary with the key a description of what the item does
    string[] AllItems = new string[] { "Pills", "Pheromones", "Mag", "Spanner", "Meds" };
    public GameObject[] PerkObjects = new GameObject[] { };

    //items to destroy 



    //items to add: "Akdov", "FabergeEgg", "MouldyTurnip", "JarOfBees", "Beans",

    //calc length of item list
    //output random string from 0,length of list
    //GameObject.Find corresponding Named script on Spawned perk 'item'
    //This methods means that all unique ability scripts will be stored on the spawned items,
    //this logic just sets one to active at random and 

    public void Start()
    {
        ItemVector = gameObject.transform.position;
        // Debug.Log(ItemVector);
        //these are obviously relative
        //(-12.29, 2.02, 49.41)
        //(-12.29, 2.02, 51.69)


    }

    public void GetRandomInt()
    {
        //Gets random number from 0 to length of list,
        //will be used to get index of perk
        RandInt = Random.Range(0, AllItems.Length);
        RandomItemName = AllItems[RandInt];

        //Spawn object
        //gets path
        //loads object and resizes it
        string path = $"Items/{RandomItemName}";
        UnityEngine.Object GetObject = Resources.Load(path);
        SetObject = (GameObject)GameObject.Instantiate(GetObject, gameObject.transform.position, Quaternion.identity); // Quaternion.identity needs to flip item 180
        SetObject.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

        // DestroyList.Add(SetObject);
        vendingMachineScript.DestroyList.Add(SetObject);
        //NEED TO DESTROY OBJECT

        //set weapons from path
        //then use inheritance to set the correct settings
    }


    public void ActionFunction()
    {
        gameObject.SendMessage("RecievePerkName", RandomItemName);

        //another ass method
        //relys on all objects in list being in a particular order        
        //play item animation disappear
        Invoke("DestroySpawnedItems", 0.2f);
    }



    public void DestroySpawnedItems()
    {
        items.SetActive(false);
        // Destroy(SetObject);
        foreach (GameObject go in vendingMachineScript.DestroyList)
        {
            Destroy(go);
        }
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
