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
    private int RandInt;
    private Vector3 ItemVector;

    //List of possible perks
    //make this a dictionary with the key a description of what the item does
    string[] AllItems = new string[] { "Pills", "Pheromones", "DamageIncrease", "MoreHealth", "HighCapacityMagazine", "ShootFaster" };
    public GameObject[] PerkObjects = new GameObject[] { };



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
    }

    public void GetRandomInt()
    {
        //Gets random number from 0 to length of list,
        //will be used to get index of perk
        RandInt = Random.Range(0, AllItems.Length);
        RandomItemName = AllItems[RandInt];

        //Spawn object
        string path = $"Items/{RandomItemName}";
        // Instantiate(Resources.Load<GameObject>(path));

        UnityEngine.Object GetObject = Resources.Load(path);
        GameObject SetObject = (GameObject)GameObject.Instantiate(GetObject, ItemVector, Quaternion.identity);

        // Debug.Log(path);

    }


    public void ActionFunction()
    {
        gameObject.SendMessage("RecievePerkName", RandomItemName);

        //another ass method
        //relys on all objects in list being in a particular order
        gameObject.SendMessage("RecievePerkIndex", RandInt);
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
