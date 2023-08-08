using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class WeaponSelectionMenu : MonoBehaviour
{
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
    public Image ImageContainer1;
    public Image ImageContainer2;
    public TextMeshProUGUI GunName1;
    public TextMeshProUGUI GunName2;

    public TextMeshProUGUI AmmoCounter1;
    public TextMeshProUGUI AmmoCounter2;

    void Awake()
    {

    }

    void Start()
    {
        Slot1.SetActive(true);
        Slot2.SetActive(true);
        Slot2.SetActive(false);
        ActiveSlot = "Slot1";
        Addlisteners();

    }

    void Update()
    {
        GetInput();
        GetWeaponInfo();
        GetAmmoCount();
    }

    public void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Slot2.SetActive(false);
            Slot1.SetActive(true);

            ActiveSlot = "Slot1";
            GetWeaponInfo();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Slot1.SetActive(false);
            Slot2.SetActive(true);

            ActiveSlot = "Slot2";
            GetWeaponInfo();
        }
    }

    public void GetAmmoCount()
    {
        int bulletsLeft1 = Slot1.transform.GetChild(0).GetComponent<GunScript>().BulletsLeft;
        int bulletsPerTap1 = Slot1.transform.GetChild(0).GetComponent<GunScript>().BulletsPerTap;
        int magazineSize1 = Slot1.transform.GetChild(0).GetComponent<GunScript>().MagazineSize;

        int bulletsLeft2 = Slot2.transform.GetChild(0).GetComponent<GunScript>().BulletsLeft;
        int bulletsPerTap2 = Slot2.transform.GetChild(0).GetComponent<GunScript>().BulletsPerTap;
        int magazineSize2 = Slot2.transform.GetChild(0).GetComponent<GunScript>().MagazineSize;

        AmmoCounter1.SetText(bulletsLeft1 / bulletsPerTap1 + " / " + magazineSize1 / bulletsPerTap1);
        AmmoCounter2.SetText(bulletsLeft2 / bulletsPerTap2 + " / " + magazineSize2 / bulletsPerTap2);
    }

    public void GetWeaponInfo()
    {
        //gets current gameobjects in slot1 and slot2, then fetches the components name

        // CurrentEquipedWeapon = GameObject.FindGameObjectWithTag("Weapon");
        // if (CurrentEquipedWeapon)
        // {
        //     foreach (char slot in CurrentEquipedWeapon.ToString())
        //     {
        //         //gets and sets current weapon name to ui
        //         string Slot1Name = CurrentEquipedWeapon.GetComponent<WeaponInfo>().WeaponName;
        //         GunName.text = Slot1Name;

        //         //gets and sets current icon name to ui
        //         ImageContainer.sprite = CurrentEquipedWeapon.GetComponent<WeaponInfo>().WeaponIcon;
        //     }
        // }

        if (Slot1.tag == "Weapon" && Slot2.tag == "Weapon")
        {
            string Slot1WeaponName = Slot1.GetComponent<WeaponInfo>().WeaponName;
            GunName1.text = Slot1WeaponName;
            ImageContainer1.sprite = Slot1.GetComponent<WeaponInfo>().WeaponIcon;


            string Slot2WeaponName = Slot2.GetComponent<WeaponInfo>().WeaponName;
            GunName2.text = Slot2WeaponName;
            ImageContainer2.sprite = Slot2.GetComponent<WeaponInfo>().WeaponIcon;
        }
        else
        {
            Debug.Log("a gun could not be found");
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
            GetWeaponInfo();
        }
        else if (ActiveSlot == "Slot2")
        {
            Debug.Log("2");
            // ActiveSlot.SetActive(false);
            Slot2.SetActive(false);
            Slot2 = ActiveWeapon;
            Slot2.SetActive(true);
            GetWeaponInfo();
        }
        else
        {
            Debug.Log("not worked");
        }
    }
}