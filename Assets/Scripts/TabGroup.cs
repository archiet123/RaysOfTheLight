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
    public GameObject WeaponPanel;
    public GameObject WeaponButton;

    void Start()
    {
        WeaponButton.GetComponent<Image>().sprite = ActiveTab;
        WeaponPanel.SetActive(true);
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
