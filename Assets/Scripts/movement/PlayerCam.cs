using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    //Get updated sens values
    public SettingsMenu settingsMenu;

    public float SensX;
    public float SensY;

    public Transform Orientation;

    float XRotaion;
    float YRotaion;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void RecieveSens(float XSens, float YSens)
    {
        SensX = XSens;
        SensY = YSens;
    }

    void Update()
    {

        //get mouse input
        float MouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * SensX;
        float MouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * SensY;

        YRotaion += MouseX;
        XRotaion -= MouseY;

        //cant look over head or under feet
        XRotaion = Mathf.Clamp(XRotaion, -90f, 90f);

        //rotate cam and orientation
        transform.rotation = Quaternion.Euler(XRotaion, YRotaion, 0);
        Orientation.rotation = Quaternion.Euler(0, YRotaion, 0);

    }
}
