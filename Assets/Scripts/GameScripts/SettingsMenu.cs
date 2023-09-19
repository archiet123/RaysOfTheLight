using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.IO;
// using StreamWriter;
public class SettingsMenu : MonoBehaviour
{
    //audio
    public AudioMixer MusicMixer;
    public AudioMixer SFXMixer;
    //display
    public GameObject FPSCounter;


    //values to write
    private bool ShowFPS;
    private float PlayerSens = 500;

    //Datafile
    private PlayerSettings playerSettings;

    //paths
    private string PersistantPath = "";
    private string Path = "";


    //====================================================================================//

    public void Start()
    {
        SetPaths();
    }

    public void Update()
    {
        SaveData();
    }

    private void SetPaths()
    {
        Path = Application.dataPath + "/" + "SaveData.json";
        PersistantPath = Application.persistentDataPath + "/" + "SaveData.json";
    }

    private void WritePlayerSettings()
    {
        playerSettings = new PlayerSettings(ShowFPS, PlayerSens);
    }


    public void SaveData()
    {
        string SavePath = Path;

        Debug.Log("path: " + SavePath);
        string json = JsonUtility.ToJson(playerSettings);
        Debug.Log(json);

        using StreamWriter writer = new StreamWriter(SavePath);
        writer.Write(json);
    }

    /* Player Settings */
    public class PlayerSettings
    {
        //Settings
        private bool FPS = true;
        private float Sens = 500;

        public PlayerSettings(bool FPS, float Sens)
        {
            this.FPS = FPS;
            this.Sens = Sens;
        }
    }
    /* Endregion */


    //setting values in game
    //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
    public void HideFPSCounter(bool Value)
    {
        ShowFPS = Value;
        if (Value)
        {
            FPSCounter.SetActive(true);
        }
        else
        {
            FPSCounter.SetActive(false);
        }
    }

    public void SetSensitivity(float Sens)
    {
        PlayerSens = Sens;
        float XSens = Sens;
        float YSens = Sens;
        FindObjectOfType<PlayerCam>().RecieveSens(XSens, YSens);
    }

    public void SFXVolume(float SFXVol)
    {
        SFXMixer.SetFloat("SFXVolume", SFXVol);
    }

    public void MusicVolume(float MusicVol)
    {
        MusicMixer.SetFloat("MusicVolume", MusicVol);
    }
}
