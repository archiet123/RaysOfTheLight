using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportingScript : MonoBehaviour
{
    public Collider collider;
    public int GameScene;

    public WeaponSelectionMenu weaponSelectionMenu;

    public void ActionFunction()
    {
        StartGame(GameScene);
    }

    public void StartGame(int GameScene)
    {
        SceneManager.LoadScene(GameScene);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // current equiped weapons are saved to player prefs
            ActionFunction();

            int Slot1WeaponID = weaponSelectionMenu.Slot1.GetComponent<WeaponInfo>().WeaponID;
            PlayerPrefs.SetInt("Slot1Weapon", Slot1WeaponID);

            int Slot2WeaponID = weaponSelectionMenu.Slot2.GetComponent<WeaponInfo>().WeaponID;
            PlayerPrefs.SetInt("Slot2Weapon", Slot2WeaponID);

            //.Log($"before {Slot1WeaponID}");
            //.Log($"before {Slot2WeaponID}");
        }
        else
        {
            ////.Log(other.tag);
        }
    }
}