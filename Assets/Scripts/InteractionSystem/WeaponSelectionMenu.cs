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

    void Start()
    {
        ActiveWeapon = WeaponsToChoose[0];
        ActiveWeapon.SetActive(true);

        for (int i = 0; i < GunButtons.Count; i++)
        {
            int closureIndex = i; // adds listener to all buttons in list
            GunButtons[closureIndex].onClick.AddListener(() => TaskOnClick(closureIndex));
        }
    }


    public void TaskOnClick(int buttonIndex)
    {
        //setting old weapon to false and new to true
        ActiveWeapon.SetActive(false);
        ActiveWeapon = WeaponsToChoose[buttonIndex];
        ActiveWeapon.SetActive(true);
    }
}
