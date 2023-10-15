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
    private string ImgToSet;
    private string path;
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

    public void UpdatePerkQuantities(string RandomItemName)
    {
        bool Add = true;
        // Debug.Log(Add);
        // string item = RandomItemName;

        if (PerkList.Contains(RandomItemName))
        {
            Add = false;
            // PerkList.Add($"already in list{RandomItemName}");
            Debug.Log($"{RandomItemName} already in list");
        }
        else
        {
            Add = true;
            PerkList.Add(RandomItemName);
            Debug.Log($"add to list{RandomItemName}");
        }

        ImgToSet = RandomItemName;
        path = $"ItemIcons/{ImgToSet}";

        GameObject imgObject = new GameObject(path);
        RectTransform trans = imgObject.AddComponent<RectTransform>();
        // Debug.Log(imgObject);


        // Debug.Log($"before {Add}");
        if (Add)
        {
            trans.transform.SetParent(PerkContainer.transform); // setting parent
            trans.localScale = Vector3.one;
            trans.anchoredPosition = new Vector2(0f, 0f); // setting position, will be on center
            trans.sizeDelta = new Vector2(50, 50); // custom size
            // Debug.Log($"after {Add}");
            Image image = imgObject.AddComponent<Image>();
            Texture2D tex = Resources.Load<Texture2D>(path);
            image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0f, 0f));
            imgObject.transform.SetParent(PerkContainer.transform);
        }

    }
}