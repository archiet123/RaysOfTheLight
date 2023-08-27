using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class SettingsMenu : MonoBehaviour
{
    //audio
    public AudioMixer MusicMixer;
    public AudioMixer SFXMixer;


    //display
    public GameObject FPSCounter;


    //controlls



    public void HideFPSCounter(bool Value)
    {
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
