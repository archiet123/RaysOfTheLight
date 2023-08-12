using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrencySystem : MonoBehaviour
{
    //TMP for money
    public TextMeshProUGUI MonersTMP;

    //variable for Moners
    public int Moners = 0;

    void Start()
    {
        MonersTMP.SetText("₪" + Moners);
    }

    void Update()
    {
        MonersTMP.SetText("₪" + Moners);
    }
}
