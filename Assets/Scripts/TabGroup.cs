using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TabGroup : MonoBehaviour
{
    //List of buttons
    public List<TabButton> TabButtons;
    //images for tab activity states 
    public Sprite IdleTab;
    public Sprite HoverTab;
    public Sprite ActiveTab;

    //setting active tab
    public TabButton SelectedTab;

    //list for different displays
    public List<GameObject> DisplaysToSwap;

    //on start UI
    public GameObject StartActivePanel;
    public GameObject StartActiveTab;

    void Start()
    {
        StartActiveTab.GetComponent<Image>().sprite = ActiveTab;
        StartActivePanel.SetActive(true);
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Q))
        // {
        //     if (SelectedTab.transform.GetSiblingIndex() > 0)
        //     {
        //         SetActive(SelectedTab.transform.GetSiblingIndex() - 1);
        //     }
        // }

        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     if (ActiveTab.transform.GetSiblingIndex() < (transform.childCount - 1))
        //     {
        //         SetActive(ActiveTab.transform.GetSiblingIndex() + 1);
        //     }
        // }
    }

    public void Subscribe(TabButton button)
    {
        if (TabButtons == null)
        {
            TabButtons = new List<TabButton>();
        }

        TabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        //this sprite needs to be "idle" 
        if (SelectedTab == null || button != SelectedTab)
        {
            button.Background.sprite = ActiveTab;
        }
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        SelectedTab = button;
        ResetTabs();
        button.Background.sprite = ActiveTab;
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < DisplaysToSwap.Count; i++)
        {
            if (i == index)
            {
                DisplaysToSwap[i].SetActive(true);
            }
            else
            {
                DisplaysToSwap[i].SetActive(false);
            }
        }
    }

    public void ResetTabs()
    {
        foreach (TabButton button in TabButtons)
        {
            if (SelectedTab != null && button == SelectedTab) { continue; }
            button.Background.sprite = IdleTab;
        }
    }
}
