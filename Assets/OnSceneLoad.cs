using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OnSceneLoad : MonoBehaviour
{

    public WeaponSelectionMenu weaponSelectionMenu;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Invoke("LoadData", 0.01f);
        //invoke a method to set the stats 0.1 seconds later, is being set to default weapons of WeaponSelectionMenu
    }

    public void LoadData()
    {
        float ROFMultiplier = PlayerPrefs.GetFloat("WeaponRateOfFire");

        // weaponSelectionMenu.Slot1.transform.GetChild(0).GetComponent<GunScript>().TimeBetweenShooting;
        float test = weaponSelectionMenu.Slot1.transform.GetChild(0).GetComponent<GunScript>().TimeBetweenShooting -= ROFMultiplier;

        // Debug.Log(ROFMultiplier);
        // Debug.Log(test);    }
    }
}