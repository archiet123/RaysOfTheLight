using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    public List<string> PerkList = new List<string> { };
    // List<Sprite> PerkSprites = new List<Sprite>();

    public GameObject PerkContainer;
    // public GameObject PerkContainer;

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

        foreach (var i in List)
        {
            Debug.Log("Value: " + i.Value + " Count: " + i.Count);
            // Debug.Log(List);
            string ImgToSet = i.Value;
            string path = $"ItemIcons/{ImgToSet}";

            GameObject imgObject = new GameObject(path);
            RectTransform trans = imgObject.AddComponent<RectTransform>();

            trans.transform.SetParent(PerkContainer.transform); // setting parent
            trans.localScale = Vector3.one;
            trans.anchoredPosition = new Vector2(0f, 0f); // setting position, will be on center
            trans.sizeDelta = new Vector2(50, 50); // custom size

            Image image = imgObject.AddComponent<Image>();
            Texture2D tex = Resources.Load<Texture2D>(path);
            image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0f, 0f));
            imgObject.transform.SetParent(PerkContainer.transform);


            //create text in code]
            //add image to that text??

            //or instantiate text to image??
            //check if i.value is in list
            //if not, destroy current and instantiate new text
            //this 

            //else
        }
    }
}