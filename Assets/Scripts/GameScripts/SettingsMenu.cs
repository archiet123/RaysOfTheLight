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
    private float PlayerSens;

    //Datafile
    private PlayerSettings playerSettings;

    //paths
    private string PersistantPath = "";
    private string Path = "";


    //====================================================================================//

    public void Start()
    {
        SetPaths();

        LoadData();
        // Debug.Log(playerSettings.LoadFloat());
    }

    public void Update()
    {
        UpatedCurrentPlayerSettings();
    }

    private void SetPaths()
    {
        Path = Application.dataPath + "/" + "SaveData.json";
        PersistantPath = Application.persistentDataPath + "/" + "SaveData.json";
    }

    private void UpatedCurrentPlayerSettings()
    {
        playerSettings = new PlayerSettings(ShowFPS, PlayerSens);
    }


    public void SaveData()
    {
        // Debug.Log("path: " + SavePath);
        string json = JsonUtility.ToJson(playerSettings);
        Debug.Log(json);

        using StreamWriter writer = new StreamWriter(Path);
        writer.Write(json);
    }

    public void LoadData()
    {
        using StreamReader reader = new StreamReader(Path);
        string json = reader.ReadToEnd();
        PlayerSettings settings = JsonUtility.FromJson<PlayerSettings>(json);
        PlayerSens = settings.LoadFloat();
        SetSensitivity(PlayerSens);
        HideFPSCounter(ShowFPS);
    }




    /* Player Settings */
    [System.Serializable]
    public class PlayerSettings
    {
        //Settings
        public bool FPS;
        public float Sens;

        public PlayerSettings(bool FPS, float Sens)
        {
            this.FPS = FPS;
            this.Sens = Sens;
        }

        public float LoadFloat()
        {
            return Sens;
        }

        public bool LoadBool()
        {
            return FPS;
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

    public void SetSensitivity(float Sensitivity)
    {
        PlayerSens = Sensitivity;
        float XSens = Sensitivity;
        float YSens = Sensitivity;
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
