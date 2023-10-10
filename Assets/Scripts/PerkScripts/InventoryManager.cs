using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    public List<string> PerkList = new List<string> { };
    List<Sprite> PerkSprites = new List<Sprite>();

    public GameObject PerkContainer;

    //PerkName will be added to PerkUIList when perk is picked

    //any duplicates will then be calculated and totaled
    //potentially calculate totals of sprite list, might be hard to associate wtih correct sprite after totalled

    //the icon/sprite will then be fetched from the list and added to PerkSprites List
    //foreach Sprite in list
    //{
    //  add sprite to PerkList (content)
    //}

    void Update()
    {

    }

    public void UpdatePerkQuantities()
    {
        var List = PerkList.GroupBy(item => item).Select(g => new { Value = g.Key, Count = g.Count() }).OrderByDescending(item => item.Count);

        foreach (var item in List)
        {
            Debug.Log("Value: " + item.Value + " Count: " + item.Count);
            // Debug.Log(List);
        }
    }
}