using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelectionMenu : MonoBehaviour
{
    [SerializeField] private int ButtonID;


    void Update()
    {
        SetWeapon();
    }
    public void SetWeapon()
    {
        ISetWeapon setWeapon = GetUniqueID();
    }

    public ISetWeapon GetUniqueID()
    {
        setWeapon.SetWeaponActive(ButtonID);
    }

}
