using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
public class ItemGeneration : MonoBehaviour, IInteractable
{
    public VendingMachineScript vendingMachineScript;
    public InventoryManager inventoryManager;
    private GameObject SetObject;
    public GameObject items;
    [SerializeField] private string RandomItemName;
    private int RandInt;
    private Vector3 ItemVector;

    //List of possible perks
    //make this a dictionary with the key a description of what the item does
    string[] AllItems = new string[] { "Pills", "Pheromones", "Mag", "Spanner", "Meds" };
    // private string[] CurrentEquipedPerks = new string[] { };
    List<string> CurrentEquipedPerks = new List<string> { };

    string[] test = new string[] { };

    public GameObject[] PerkObjects = new GameObject[] { };

    //items to destroy 
    //items to add: "Akdov", "FabergeEgg", "MouldyTurnip", "JarOfBees", "Beans",
    //calc length of item list
    //output random string from 0,length of list
    //GameObject.Find corresponding Named script on Spawned perk 'item'
    //This methods means that all unique ability scripts will be stored on the spawned items,
    //this logic just sets one to active at random and 

    public void Awake()
    {
        //foreach item in AllItems, PlayerPrefs.reset
    }

    void Start()
    {
        ItemVector = gameObject.transform.position;

        Debug.Log("started");
        test = PlayerPrefsX.GetStringArray("CurrentEquipedPerks");
        foreach (string ItemName in test)
        {
            // UpdatePerkQuantities(ItemName);
            // Debug.Log(ItemName);
        }
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
        SetObject = (GameObject)GameObject.Instantiate(GetObject, gameObject.transform.position, Quaternion.Euler(0f, 180f, 0f)); // Quaternion.identity needs to flip item 180
        SetObject.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        vendingMachineScript.DestroyList.Add(SetObject);
    }

    public void ActionFunction()
    {
        gameObject.SendMessage("RecievePerkName", RandomItemName);

        //adding +1 when perk picked
        //will try to get counter otherwise will create new and +1
        try
        {
            int CurrentItemCounter = PlayerPrefs.GetInt(RandomItemName);
            CurrentItemCounter += 1;
            PlayerPrefs.SetInt(RandomItemName, CurrentItemCounter);
        }
        catch
        {
            PlayerPrefs.SetInt(RandomItemName, 0);
        }

        inventoryManager.UpdatePerkQuantities(RandomItemName);
        SetCurrentPerks();
        //play item animation disappear

        Invoke("DestroySpawnedItems", 0.2f);
    }

    public void SetCurrentPerks()
    {
        if (CurrentEquipedPerks.Contains(RandomItemName))
        {
            Debug.Log("already added");
        }
        else
        {
            // Debug.Log($"added {RandomItemName}");
            CurrentEquipedPerks.Add(RandomItemName);

            string[] str = CurrentEquipedPerks.ToArray();
            PlayerPrefsX.SetStringArray("CurrentEquipedPerks", str);
        }
    }




    public void DestroySpawnedItems()
    {
        items.SetActive(false);
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
        // //.Log("got transform");
        return transform;
    }
}
