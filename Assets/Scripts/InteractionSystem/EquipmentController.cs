using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class EquipmentController : MonoBehaviour, IInteractable
{
    //GameObjects
    public GameObject player;
    public GameObject EquipmentMenu;

    //bools
    [SerializeField] public static bool IsShown = false;
    //MenuTabs
    public Button WeaponTab;
    public Button UtilityTab;
    public Button StatsTab;


    //strings
    public string PreviousTab;
    public string CurrentTab;
    //images
    public Sprite InactiveTab;
    public Sprite ActiveTab;

    public GameObject ActiveButton;

    void start()
    {
        ActiveButton = WeaponTab;
        Debug.Log(ActiveButton);
    }

    public void SetActiveButton()
    {
        ActiveButton = EventSystem.current.currentSelectedGameObject;
        Debug.Log(ActiveButton);
    }

    public void Selectedbutton()
    {
        ActiveButton.GetComponent<Image>().sprite = ActiveTab;
        // Button button = ActiveButton;
        // button.image.sprite = ActiveTab;
    }

    public void DeSelectedButton()
    {
        ActiveButton.GetComponent<Image>().sprite = InactiveTab;
        // Button button = ActiveButton;
        // button.image.sprite = InactiveTab;
    }

    public void GetBool(bool DisablePauseMenu)
    {
        IsShown = DisablePauseMenu;
    }

    private void ToggleBenchUI()
    {
        //updating variable for status of MenuUI
        FindObjectOfType<UIController>().GetBool(IsShown);
        if (!IsShown)
        {
            OpenMenu();
            // Debug.Log("open bench");
            FindObjectOfType<UIController>().GetBool(IsShown);
            //is true
            FindObjectOfType<GunScript>().GetBool(IsShown);
        }
        else
        {
            CloseMenu();
            // Debug.Log("close bench");
            FindObjectOfType<UIController>().GetBool(IsShown);
            //is false
            FindObjectOfType<GunScript>().GetBool(IsShown);
        }
    }
    public void CloseMenu()
    {
        // Debug.Log("close");
        EquipmentMenu.SetActive(false);
        Time.timeScale = 1f;
        IsShown = false;
        player.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        IsShown = false;
    }

    public void OpenMenu()
    {
        // Debug.Log("open");
        EquipmentMenu.SetActive(true);
        Time.timeScale = 0f;
        IsShown = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //Interactable stuff for gun bench
    //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

    public void UseMenu()
    {
        // Debug.Log("Bench Toggled");
        ToggleBenchUI();
    }

    public string GetInteractText()
    {
        return "Equipment";
    }

    void IInteractable.Interact(Transform InteractorTransform)
    {
        UseMenu();
    }

    public Transform GetTransform()
    {
        return transform;
    }
}