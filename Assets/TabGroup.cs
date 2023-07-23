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
        button.Background.sprite = ActiveTab;
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        ResetTabs();
        button.Background.sprite = ActiveTab;
    }

    public void ResetTabs()
    {
        foreach (TabButton button in TabButtons)
        {
            button.Background.sprite = IdleTab;
        }
    }
}
