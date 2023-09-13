using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour, IInteractable
{
    public bool LevelComplete;

    //entities functionality goes here
    public void Start()
    {

    }

    public void ActionFunction()
    {
        if (LevelComplete == true)
        {
            // Debug.Log("start next scene");
            SceneManager.LoadScene(0);
            Cursor.lockState = CursorLockMode.None;
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
        return "Elevator";
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

