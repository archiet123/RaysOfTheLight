using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
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

    void Update()
    {
        //get mouse input
        float MouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * SensX;
        float MouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * SensY;

        YRotaion += MouseX;
        XRotaion -= MouseY;

        XRotaion = Mathf.Clamp(XRotaion, -90f, 90f);

        //rotate cam and orientation
        transform.rotation = Quaternion.Euler(XRotaion, YRotaion, 0);
        Orientation.rotation = Quaternion.Euler(0, YRotaion, 0);

    }
}
