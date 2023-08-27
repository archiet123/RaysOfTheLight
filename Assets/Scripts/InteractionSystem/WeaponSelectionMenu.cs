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

    //WeaponList, because im dumb we need a list of 3g guns for each slot
    public List<GameObject> WeaponsToChoose1 = new List<GameObject>();
    public List<GameObject> WeaponsToChoose2 = new List<GameObject>();

    // public List<char> WeaponNames = new List<char>();
    //active weapon
    private GameObject ActiveWeapon1;
    private GameObject ActiveWeapon2;
    private string ActiveSlot;

    public GameObject Slot1;
    public GameObject Slot2;

    //ui stuff slot for current weapon
    public GameObject Slot1Container;
    public GameObject Slot2Container;

    public Image ImageContainer1;
    public Image ImageContainer2;
    public TextMeshProUGUI GunName1;
    public TextMeshProUGUI GunName2;

    public TextMeshProUGUI AmmoCounter1;
    public TextMeshProUGUI AmmoCounter2;

    private Vector3 Shrink;
    private Vector3 Grow;


    private string Slot1WeaponID;
    private string Slot2WeaponID;


    void Start()
    {
        Grow = new Vector3(1.0f, 1.0f, 1.0f);
        Shrink = new Vector3(0.5f, 0.5f, 1.0f);
        Slot2Container.transform.localScale = Shrink;

        Slot1.SetActive(true);
        Slot2.SetActive(true);
        Slot2.SetActive(false);
        ActiveSlot = "Slot1";

        Addlisteners();
        OnStartWeapons();
    }

    void Update()
    {
        GetInput();
        GetWeaponInfo();
        GetAmmoCount();
    }

    public void OnStartWeapons()
    {

    }

    public void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //active hotbar slot is to scale, inactive is shrunk by half
            Slot2Container.transform.localScale = Shrink;
            Slot1Container.transform.localScale = Grow;

            Slot2.SetActive(false);
            Slot1.SetActive(true);

            ActiveSlot = "Slot1";
            GetWeaponInfo();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Slot2Container.transform.localScale = Grow;
            Slot1Container.transform.localScale = Shrink;

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
        if (Slot1.tag == "Weapon" && Slot2.tag == "Weapon")
        {
            string Slot1WeaponName = Slot1.GetComponent<WeaponInfo>().WeaponName;
            GunName1.text = Slot1WeaponName;
            ImageContainer1.sprite = Slot1.GetComponent<WeaponInfo>().WeaponIcon;

            Slot1WeaponID = Slot1.GetComponent<WeaponInfo>().WeaponID;
            Debug.Log(Slot1WeaponID);

            Slot2WeaponID = Slot2.GetComponent<WeaponInfo>().WeaponID;
            Debug.Log(Slot2WeaponID);

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
        ActiveWeapon1 = WeaponsToChoose1[buttonIndex];
        ActiveWeapon2 = WeaponsToChoose2[buttonIndex];
        if (ActiveSlot == "Slot1")
        {
            Slot1.SetActive(false);
            Slot1 = ActiveWeapon1;
            Slot1.SetActive(true);
            GetWeaponInfo();
        }
        else if (ActiveSlot == "Slot2")
        {
            Slot2.SetActive(false);
            Slot2 = ActiveWeapon2;
            Slot2.SetActive(true);
            GetWeaponInfo();
        }
        else
        {
            Debug.Log("not worked");
        }
    }
}