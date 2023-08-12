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
        // MonersTMP.SetText("₪" + Moners);
    }

    public void GetMoners(int MonersToAdd)
    {
        // Debug.Log(MonersToAdd);
        StartCoroutine(AddMoners(MonersToAdd));
    }

    //this slowly adds moners, please find a better way
    IEnumerator AddMoners(int MonersToAdd)
    {
        for (int i = 0; i < MonersToAdd; i++)
        {
            Moners += 1;
            MonersTMP.SetText("₪" + Moners);
            // Debug.Log(Moners);
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;

        }
    }

    public void TakeMoners(int MonersToSubtract)
    {
        Debug.Log(MonersToSubtract);
        StartCoroutine(SubtractMoners(MonersToSubtract));
    }

    //this slowly adds moners, please find a better way
    IEnumerator SubtractMoners(int MonersToSubtract)
    {
        for (int i = 0; i < MonersToSubtract; i++)
        {
            Moners -= 1;
            MonersTMP.SetText("₪" + Moners);
            // Debug.Log(Moners);
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;

        }
    }
}
