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
        float ROFMultiplier = PlayerPrefs.GetFloat("WeaponRateOfFire");

        weaponSelectionMenu.Slot1.transform.GetChild(0).GetComponent<GunScript>().TimeBetweenShooting -= ROFMultiplier;
        weaponSelectionMenu.Slot2.transform.GetChild(0).GetComponent<GunScript>().TimeBetweenShooting -= ROFMultiplier;

        Debug.Log(ROFMultiplier);
    }
}
