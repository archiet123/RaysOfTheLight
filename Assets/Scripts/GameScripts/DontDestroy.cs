using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{

    public static DontDestroy DD;

    void Awake()
    {
        MakeThisTheOnlyGameManager();
    }


    void MakeThisTheOnlyGameManager()
    {
        if (DD == null)
        {
            DontDestroyOnLoad(gameObject);
            DD = this;
        }
        else
        {
            if (DD != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
