using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class WeaponSelectionMenu : MonoBehaviour
{
    //unique buttonID
    public int ButtonID = 0;

    //List of buttons
    public List<Button> GunButtons;

    //WeaponList
    public List<GameObject> WeaponsToChoose = new List<GameObject>();

    public List<char> WeaponNames = new List<char>();
    //active weapon
    public GameObject ActiveWeapon;
    public string ActiveSlot;

    public GameObject Slot1;
    public GameObject Slot2;

    //current weapon of any type
    public GameObject CurrentEquipedWeapon;

    //ui stuff slot for current weapon
    public Image ImageContainer;
    public TextMeshProUGUI GunName;


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
        CurrentEquipedWeapon = GameObject.FindGameObjectWithTag("Weapon");
        if (CurrentEquipedWeapon)
        {
            foreach (char slot in CurrentEquipedWeapon.ToString())
            {
                //gets and sets current weapon name to ui
                string Slot1Name = CurrentEquipedWeapon.GetComponent<WeaponInfo>().WeaponName;
                GunName.text = Slot1Name;

                //gets and sets current icon name to ui
                ImageContainer.sprite = CurrentEquipedWeapon.GetComponent<WeaponInfo>().WeaponIcon;
            }
        }
    }

    public void Addlisteners()
    {
        for (int i = 0; i < GunButtons.Count; i++)
        {
            int closureIndex = i; // adds listener to all buttons in list
            GunButtons[closureIndex].onClick.AddListener(() => TaskOnClick(closureIndex));
        }
    }


    //this function actually sucks but it works so dont touch it
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