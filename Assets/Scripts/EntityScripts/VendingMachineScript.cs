using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class VendingMachineScript : MonoBehaviour, IInteractable
{
    //items dispensed from machine
    public GameObject items;

    //currency script
    // public CurrencySystem currencySystem;

    //value of currency
    private int CurrentCurrency;
    //cost of vendingmachine
    public int UseCost = 15;

    //UI warning if not affordable
    public GameObject WarningParent;
    public TextMeshProUGUI WarningTMP;

    int countDownStartValue = 3;

    //counters
    public float ROFCounter;
    public int MoveSpeedCounter;
    public int FOVCounter;

    public List<GameObject> DestroyList = new List<GameObject>();

    //entities functionality goes here
    public void ActionFunction()
    {
        string VendingType = (gameObject.tag);

        if (VendingType == "Perks")
        {
            GivePlayerPerk();
        }
        else if (VendingType == "Weapons")
        {
            GivePlayerWeapon();
        }
        else if (VendingType == "Bullets")
        {
            GivePlayerBullets();
        }
        else
        {
            //.Log("vending machine type could not be found");
        }

    }

    public void GivePlayerPerk()
    {
        // int CurrentCurrency = currencySystem.GetComponent<CurrencySystem>().Moners;

        int CurrentCurrency = CurrencySystem.Moners;


        if (CurrentCurrency >= UseCost)
        {
            GameObject.FindObjectOfType<CurrencySystem>().TakeMoners(UseCost);
            // currencySystem.TakeMoners(UseCost);
            items.SetActive(true);
            //Debug.Log("gumball");
        }
        else
        {
            // //.Log("Cannot afford");
            WarningParent.SetActive(true);
            WarningTMP.SetText("Cannot afford");
            countDownTimer();
        }
    }

    public void GivePlayerWeapon()
    {

    }

    public void GivePlayerBullets()
    {

    }

    void countDownTimer()
    {
        if (countDownStartValue > 0)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(countDownStartValue);
            countDownStartValue--;
            Invoke("countDownTimer", 1.0f);
        }
        else
        {
            WarningParent.SetActive(false);
            countDownStartValue = 3;
        }
    }

    //Interactable stuff
    //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

    public void CallActionFunction()
    {
        ActionFunction();
    }

    public string GetInteractText()
    {
        return "Buy (₪5)";
    }

    void IInteractable.Interact(Transform InteractorTransform)
    {
        CallActionFunction();
    }

    public Transform GetTransform()
    {
        // //.Log("got transform");
        return transform;
    }
}

