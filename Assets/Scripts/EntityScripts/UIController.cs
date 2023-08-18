using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //UI   
    public GameObject pauseMenu;
    public GameObject player;
    // public GameObject GunBenchUI;
    public GameObject OptionsMenu;
    public GameObject WinDisplay;
    public GameObject LoseDisplay;
    //bools
    public static bool isPaused;
    [SerializeField] public static bool DisablePauseMenu = false;
    public static bool OptionsDisplayed = false;

    public void Update()
    {
        GetInput();
    }

    public void GetBool(bool IsShown)
    {
        DisablePauseMenu = IsShown;
    }

    private void GetInput()
    {

        if (!DisablePauseMenu)
        {
            //if false the pause menu will be displayed
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (OptionsDisplayed)
                {

                    HideOptionsMenu();
                }
                else if (isPaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
            else
            {

            }
        }
        else if (DisablePauseMenu)
        {
            //if true the gunbenchUI will be hidden
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // GunBenchUI.SetActive(false);
                Time.timeScale = 1f;
                player.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                DisablePauseMenu = false;
                // getting variable from GunBenchScript
                // FindObjectOfType<GunBenchScript>().GetBool(DisablePauseMenu);
                FindObjectOfType<EquipmentController>().GetBool(DisablePauseMenu);
                // FindObjectOfType<GunBenchScript>().GetBool1(DisablePauseMenu);
                //is false
                FindObjectOfType<GunScript>().GetBool1(DisablePauseMenu);
            }
        }
        else
        {
            Debug.Log("error");
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        player.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        player.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public void DisplayOptionsMenu()
    {
        OptionsDisplayed = true;
        pauseMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void HideOptionsMenu()
    {
        OptionsDisplayed = false;
        OptionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void DisplayWinScreen()
    {
        player.SetActive(false);
        Time.timeScale = 0f;
        WinDisplay.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void DisplayLoseScreen()
    {
        player.SetActive(false);
        Time.timeScale = 0f;
        LoseDisplay.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}