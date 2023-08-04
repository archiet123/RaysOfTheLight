using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelectionMenu : MonoBehaviour
{
    [SerializeField] private string ButtonID;

    // interactable.Interact(ButtonID);

    public void GetString()
    {
        GetButtonID();
    }
    public string GetButtonID()
    {
        return ButtonID;
    }
}
