using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponSelectionMenu : MonoBehaviour
{
    //unique buttonID
    public int ButtonID;

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
    }

    void Update()
    {
        // SetWeaponActive()
    }

    //when button is clicked the index of the button is fetched
    public void SetWeapon()
    {
        for (int i = 0; i < GunButtons.Count; ++i)
        {
            int capturedButtonIndex = i;
            GunButtons[i].onClick.AddListener(() => { GetButtonID(capturedButtonIndex); });
        }
    }

    public void GetButtonID(int capturedButtonIndex)
    {
        ButtonID = capturedButtonIndex;
        Debug.Log($"weaponID: {ButtonID}");

        ActiveWeapon.SetActive(false);
        ActiveWeapon = WeaponsToChoose[capturedButtonIndex];
        ActiveWeapon.SetActive(true);
    }

}
