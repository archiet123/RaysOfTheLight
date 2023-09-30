using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perks : MonoBehaviour
{
    //Game object refrences
    public GameObject player;
    public Camera playerCam;
    public GameObject Bullet;
    public WeaponSelectionMenu weaponSelectionMenu;


    //Base Stat Values
    public float ROFCounter;

    //
    public void Start()
    {
        // playerCam = GetComponent<Camera>();
    }

    //will call the corresponding function instantly
    public void RecievePerkName(string MethodToCall)
    {
        Invoke(MethodToCall, 0f);
    }

    //All perk functions below
    //I recommend ctrl + f
    public void Akdov()
    {
        //Debug.Log();.Log($"Picked Akdov");
    }

    public void FabergeEgg()
    {
        //Debug.Log();.Log($"Picked FabergeEgg");
    }

    public void MouldyTurnip()
    {
        //Debug.Log();.Log($"Picked MouldyTurnip");
    }

    public void JarOfBees()
    {
        //Debug.Log();.Log($"Picked JarOfBees");
    }

    public void Beans()
    {
        //Debug.Log();.Log($"Picked Beans");
    }

    public void GoFast()
    {
        //Debug.Log();.Log($"Picked GoFast");

        player.GetComponent<PlayerMovement>().MoveSpeed += 1;
        playerCam.fieldOfView += 10f;
    }

    public void DamageIncrease()
    {
        //Debug.Log();.Log($"Picked DamageIncrease");
    }
    public void MoreHealth()
    {
        // //Debug.Log();.Log($"Picked MoreHealth");

        player.GetComponent<PlayerHealth>().IncreaseHealth(25);
    }
    public void Armour()
    {
        //Debug.Log();.Log($"Picked Armour");
    }
    public void HighCapacityMagazine()
    {
        //Debug.Log();.Log($"Picked HighCapacityMagazine");
    }
    public void ShootFaster()
    {
        //Debug.Log();.Log($"Picked ShootFaster");

        //a counter is required because the selected weapon will change
        //meaning the variable value will be different for each weapon
        //this will also mean it has to be set back to its default ROF before i can be set the the correct multiplyer value
        //ROFMultiplier = ItemCounter * 1
        //weapon rate of fire * ROFMultiplier
        ROFCounter += 1f;
        float ROFMultiplier = ROFCounter * 0.1f;
        Debug.Log(ROFCounter);

        //Get the weapnons 'Base' rate of fire
        float Slot1BaseROF = weaponSelectionMenu.Slot1.transform.GetChild(0).GetComponent<GunScript>().BaseROF;
        float Slot2BaseROF = weaponSelectionMenu.Slot2.transform.GetChild(0).GetComponent<GunScript>().BaseROF;

        //Set base rate of fire
        float Slot1ROF = weaponSelectionMenu.Slot1.transform.GetChild(0).GetComponent<GunScript>().TimeBetweenShooting = Slot1BaseROF;
        float Slot2ROF = weaponSelectionMenu.Slot2.transform.GetChild(0).GetComponent<GunScript>().TimeBetweenShooting = Slot1BaseROF;

        //update to current multiplier rate of fire
        Slot1ROF = weaponSelectionMenu.Slot1.transform.GetChild(0).GetComponent<GunScript>().TimeBetweenShooting -= ROFMultiplier;
        Slot2ROF = weaponSelectionMenu.Slot2.transform.GetChild(0).GetComponent<GunScript>().TimeBetweenShooting -= ROFMultiplier;
    }
}
