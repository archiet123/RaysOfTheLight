using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perks : MonoBehaviour
{
    public void RecievePerkName(string MethodToCall)
    {
        Debug.Log($"Picked {MethodToCall}");
    }
}
