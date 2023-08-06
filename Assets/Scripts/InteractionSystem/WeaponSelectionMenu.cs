using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponSelectionMenu : MonoBehaviour
{

    //unique buttonID
    public int ButtonID = 0;

    //List of buttons
    public List<Button> GunButtons;

    //WeaponList
    public List<GameObject> WeaponsToChoose = new List<GameObject>();

    //active weapon
    public GameObject ActiveWeapon;
    public string ActiveSlot;

    public GameObject Slot1;
    public GameObject Slot2;

    public GameObject theObject;

    void Start()
    {
        Slot1.SetActive(true);
        ActiveSlot = "Slot1";
        Addlisteners();
    }

    void Update()
    {
        GetWeaponInfo();
        GetInput();

        // Debug.Log(Slot1);
        // Debug.Log(Slot2);
    }

    public void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Slot2.SetActive(false);
            Slot1.SetActive(true);

            ActiveSlot = "Slot1";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Slot1.SetActive(false);
            Slot2.SetActive(true);

            ActiveSlot = "Slot2";
        }
    }

    public void GetWeaponInfo()
    {
        //gets current gameobjects in slot1 and slot2, then fetches the components name
        theObject = GameObject.FindGameObjectWithTag("Weapon");
        if (theObject)
        {
            string Slot1Name = theObject.GetComponent<WeaponInfo>().WeaponName;
            Debug.Log(Slot1Name);
        }

        // string Slot1Name = Slot1.GetComponent<Tag>().WeaponName;
        // Debug.Log(Slot1Name);

        // string Slot2Name = Slot2.GetComponent<GunScript>().WeaponName;
        // Debug.Log(Slot2Name);
    }

    public void Addlisteners()
    {
        for (int i = 0; i < GunButtons.Count; i++)
        {
            int closureIndex = i; // adds listener to all buttons in list
            GunButtons[closureIndex].onClick.AddListener(() => TaskOnClick(closureIndex));
        }
    }


    public void TaskOnClick(int buttonIndex)
    {
        //setting old weapon to false and new to true        
        ActiveWeapon = WeaponsToChoose[buttonIndex];
        if (ActiveSlot == "Slot1")
        {
            // ActiveSlot.SetActive(false);
            Slot1.SetActive(false);
            Slot1 = ActiveWeapon;
            Slot1.SetActive(true);
        }
        else if (ActiveSlot == "Slot2")
        {
            Debug.Log("2");
            // ActiveSlot.SetActive(false);
            Slot2.SetActive(false);
            Slot2 = ActiveWeapon;
            Slot2.SetActive(true);
        }
        else
        {
            Debug.Log("not worked");
        }
    }
}