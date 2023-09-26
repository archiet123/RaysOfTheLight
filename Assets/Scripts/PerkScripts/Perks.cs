using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perks : MonoBehaviour
{
    public void RecievePerkName(string MethodToCall)
    {
        Invoke(MethodToCall, 0f);
    }

    //All perk functions below
    //I recommend ctrl + f
    public void Akdov()
    {
        Debug.Log($"Picked Akdov");
    }

    public void FabergeEgg()
    {
        Debug.Log($"Picked FabergeEgg");
    }

    public void MouldyTurnip()
    {
        Debug.Log($"Picked MouldyTurnip");
    }

    public void JarOfBees()
    {
        Debug.Log($"Picked JarOfBees");
    }

    public void Beans()
    {
        Debug.Log($"Picked Beans");
    }
}
