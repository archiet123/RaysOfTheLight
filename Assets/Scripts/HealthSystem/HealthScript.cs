using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    int countDownStartValue = 3;
    public int EnemyHealth;
    public int DeadEnemyCount;
    // public ActiveChilderen activeChilderen;

    //Name of room enemy is in
    public string EnemyRoom;

    //script for enemies in level
    public CheckLevel checkLevel;

    //UI Objects
    public Slider HealthSlider;
    public GameObject EnemyHealthBar;

    public CurrencySystem currencySystem;

    public int EnemyValue = 5;

    void Update()
    {
        CheckEnemyHealth();
    }

    void Start()
    {
        EnemyHealthBar.SetActive(false);
        // activeChilderen = GameObject.Find("Enemies").GetComponent<ActiveChilderen>();
    }

    public void CheckEnemyHealth()
    {
        if (EnemyHealth <= 0)
        {
            DisableEnemy();
            currencySystem.GetMoners(EnemyValue);
        }
    }

    public void DisableEnemy()
    {
        gameObject.SetActive(false);
        DeadEnemyCount++;
        // Debug.Log($"enemy script: {DeadEnemyCount}");

        //when enemy dies check if the room should open
        checkLevel.IsComplete(DeadEnemyCount, EnemyRoom);

    }


    public void SetHealth(int CurrentHealth)
    {
        // Debug.Log("sethealth");
        HealthSlider.value = CurrentHealth;
    }

    public void DealDamage(int WeaponDamage)
    {
        EnemyHealth = EnemyHealth - WeaponDamage;
        countDownTimer();
        EnemyHealthBar.SetActive(true);
        SetHealth(EnemyHealth);
    }

    void countDownTimer()
    {
        if (countDownStartValue > 0)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(countDownStartValue);
            countDownStartValue--;
            Invoke("countDownTimer", 1.0f);
        }
        else
        {
            EnemyHealthBar.SetActive(false);
        }
    }
}
