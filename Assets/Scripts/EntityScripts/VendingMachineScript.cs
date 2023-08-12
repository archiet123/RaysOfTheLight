using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachineScript : MonoBehaviour, IInteractable
{
    //currency script
    public CurrencySystem currencySystem;

    //value of currency
    private int CurrentCurrency;

    public int UseCost = 15;

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
            Debug.Log("vending machine type could not be found");
        }

    }

    public void GivePlayerPerk()
    {
        int CurrentCurrency = currencySystem.GetComponent<CurrencySystem>().Moners;
        if (CurrentCurrency >= UseCost)
        {
            currencySystem.TakeMoners(UseCost);
            Debug.Log("give perk");
            //call spawn function here
        }
        else
        {
            Debug.Log("Cannot afford");
        }
    }

    public void GivePlayerWeapon()
    {

    }

    public void GivePlayerBullets()
    {

    }


    //Interactable stuff
    //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

    public void CallActionFunction()
    {
        ActionFunction();
    }

    public string GetInteractText()
    {
        return "Buy";
    }

    void IInteractable.Interact(Transform InteractorTransform)
    {
        CallActionFunction();
    }

    public Transform GetTransform()
    {
        // Debug.Log("got transform");
        return transform;
    }
}

