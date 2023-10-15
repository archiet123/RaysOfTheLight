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
            Debug.Log($"{RandomItemName} already in list");
            //position is the index that the item is in the list, will be the same as the item in hierarcy
            int position = PerkList.IndexOf(RandomItemName);
            Debug.Log(position);
        }
        else
        {
            Add = true;
            PerkList.Add(RandomItemName);
            Debug.Log($"add to list{RandomItemName}");
        }

        ImgToSet = RandomItemName;
        path = $"ItemIcons/{ImgToSet}";

        GameObject imgObject = new GameObject(RandomItemName);
        RectTransform trans = imgObject.AddComponent<RectTransform>();
        // Debug.Log(imgObject);


        // Debug.Log($"before {Add}");
        if (Add)
        {
            //setting image
            trans.transform.SetParent(PerkContainer.transform); // setting parent
            trans.localScale = Vector3.one;
            trans.anchoredPosition = new Vector2(0f, 0f); // setting position, will be on center
            trans.sizeDelta = new Vector2(50, 50); // custom size
            // Debug.Log($"after {Add}");
            Image image = imgObject.AddComponent<Image>();
            Texture2D tex = Resources.Load<Texture2D>(path);
            image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0f, 0f));
            imgObject.transform.SetParent(PerkContainer.transform);

            //setting text
            GameObject PerkCounterText = new GameObject("PerkCounter");
            PerkCounterText.transform.SetParent(imgObject.transform);

            RectTransform TextTrans = PerkCounterText.AddComponent<RectTransform>();
            TextTrans.anchoredPosition = new Vector2(40f, -35f);


            Text CounterText = PerkCounterText.AddComponent<Text>();
            CounterText.transform.SetParent(PerkCounterText.transform);

            CounterText.text = "0";
            Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
            CounterText.font = ArialFont;
            CounterText.material = ArialFont.material;
            // CounterText.color = Color.Red;

            CounterText.color = new Color(2, 0, 0, 2);

        }

        //too instantiate text on the correct item get index of item in list, 
        //get index
        //set parent to gameobject in hierarcy of the same index as item in list
        //get counter of this item from playerprefs
        //clear any text that has previously been set to this gameobject
        //instantiate new text on corresponding gameobject using playerprefs counter variable
    }
}