using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

//Singletense
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager inventoryManager;
    public GameObject PerkInfoUI;
    public List<string> PerkList = new List<string> { };

    public Font GameFont;
    public GameObject PerkContainer;
    private string ImgToSet;
    private string path;


    //any duplicates will then be calculated and totaled
    //potentially calculate totals of sprite list, might be hard to associate wtih correct sprite after totalled
    //the icon/sprite will then be fetched from the list and added to PerkSprites List


    void Start()
    {

    }

    public void UpdatePerkQuantities(string RandomItemName)
    {
        // //Debug.Log(RandomItemName);
        bool Add = true;

        if (PerkList.Contains(RandomItemName))
        {
            Add = false;
            //.Log($"{RandomItemName} already in list");
            //position is the index that the item is in the list, will be the same as the item in hierarcy
            int position = PerkList.IndexOf(RandomItemName);

            int CurrentItemText = PlayerPrefs.GetInt(RandomItemName);
            PerkContainer.transform.GetChild(position).transform.GetChild(0).GetComponent<Text>().text = CurrentItemText.ToString();
        }
        else
        {
            Add = true;
            PerkList.Add(RandomItemName);
        }

        ImgToSet = RandomItemName;
        path = $"ItemIcons/{ImgToSet}";
        string FontPath = "Fonts/OCR-A Regular";

        GameObject imgObject = new GameObject(RandomItemName);
        RectTransform trans = imgObject.AddComponent<RectTransform>();



        if (Add)
        {
            //setting new gameObjects size/parent/vector
            trans.transform.SetParent(PerkContainer.transform); // setting parent
            trans.localScale = Vector3.one;
            trans.anchoredPosition = new Vector2(0f, 0f); // setting position, will be on center
            trans.sizeDelta = new Vector2(50, 50); // custom size

            //creating image component and setting Source image
            Image image = imgObject.AddComponent<Image>();
            Texture2D tex = Resources.Load<Texture2D>(path);
            image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0f, 0f));
            imgObject.transform.SetParent(PerkContainer.transform);

            //setting text
            GameObject PerkCounterText = new GameObject("PerkCounter");
            PerkCounterText.transform.SetParent(imgObject.transform);

            RectTransform TextTrans = PerkCounterText.AddComponent<RectTransform>();
            TextTrans.anchoredPosition = new Vector2(45f, -35f);

            Text CounterText = PerkCounterText.AddComponent<Text>();
            CounterText.transform.SetParent(PerkCounterText.transform);

            int textValue = PlayerPrefs.GetInt(RandomItemName);
            //.Log($"{RandomItemName}{textValue}");
            CounterText.text = textValue.ToString();

            CounterText.font = GameFont;
            CounterText.material = GameFont.material;
            CounterText.color = new Color(2, 0, 0, 2);
            CounterText.fontSize = 20;
        }

        //too instantiate text on the correct item get index of item in list, 
        //get index
        //set parent to gameobject in hierarcy of the same index as item in list
        //get counter of this item from playerprefs
        //clear any text that has previously been set to this gameobject
        //instantiate new text on corresponding gameobject using playerprefs counter variable
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ShowPerkUI();
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            HidePerkUI();
        }
    }

    public void ShowPerkUI()
    {
        PerkInfoUI.SetActive(true);
    }

    public void HidePerkUI()
    {
        PerkInfoUI.SetActive(false);
    }

    void MakeThisTheOnlyGameManager()
    {
        if (inventoryManager == null)
        {
            DontDestroyOnLoad(gameObject);
            inventoryManager = this;
        }
        else
        {
            if (inventoryManager != this)
            {
                Destroy(gameObject);
            }
        }
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        int SceneInt = SceneManager.GetActiveScene().buildIndex;
        if (SceneInt == 1)
        {
            PerkList.Clear();
            foreach (Transform child in PerkContainer.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}