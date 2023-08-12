using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachineScript : MonoBehaviour, IInteractable
{
    public CurrencySystem currencySystem;

    //entities functionality goes here
    public void ActionFunction()
    {
        Debug.Log(gameObject.tag);

        int CurrentCurrency = currencySystem.GetComponent<CurrencySystem>().Moners;
        if (CurrentCurrency == 0)
        {
            Debug.Log("not enough money");
        }
        else
        {
            Debug.Log("give item");
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

