using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponSelectionMenu : MonoBehaviour
{
    [SerializeField] public string ButtonID;


    //add buttons to a list, print the index of the button in the list.

    //List of buttons
    public List<Button> GunButtons;

    void Update()
    {

    }

    //when button is clicked the index of the name is fetched
    public void SetWeapon()
    {
        for (int i = 0; i < GunButtons.Count; ++i)
        {
            int capturedButtonIndex = i;
            GunButtons[i].onClick.AddListener(() => { function(capturedButtonIndex); });
        }
    }

    public void function(int capturedButtonIndex)
    {
        ButtonID = capturedButtonIndex.ToString();
    }

    //returns the index of the button that has been clicked
    public string GetButtonID()
    {
        return ButtonID;
    }
}
