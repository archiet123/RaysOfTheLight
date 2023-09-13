using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //variables
    public int Health;

    //GameObjects
    public GameObject GameManager;

    //UI Objects
    public Slider HealthSlider;

    void Update()
    {

        if (Health <= 0)
        {
            // Debug.Log("you lose");
            GameManager.GetComponent<UIController>().DisplayLoseScreen();
        }
    }

    public void SetHealth(int CurrentHealth)
    {
        HealthSlider.value = CurrentHealth;
    }

    public void DealDamage(int EnemyDamage)
    {
        // Debug.Log("test");
        Health = Health - EnemyDamage;
        SetHealth(Health);
    }
}
