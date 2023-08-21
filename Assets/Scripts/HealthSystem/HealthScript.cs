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
            // StartCoroutine(AddMoners(EnemyValue));
        }
    }

    public void DisableEnemy()
    {
        gameObject.SetActive(false);
        DeadEnemyCount++;
        // Debug.Log($"enemy script: {DeadEnemyCount}");

        // activeChilderen.sendValue(DeadEnemyCount);
        checkLevel.IsComplete(DeadEnemyCount, EnemyRoom);
        //maybe send second parameter to GameStatus script.
        //second parm will be the room the enemie is assigned to
        //then when all enemies are dead for that room the doors will open again

        //public void IsComplete(EnemiesRemaining){ if EnemyRoom == x 
        //then check if DeadEnemyCount == Enemies in x }
    }

    // IEnumerator AddMoners(int EnemyValue)
    // {
    //     for (int i = 0; i < EnemyValue; i++)
    //     {
    //         currencySystem.Moners += 1;
    //         yield return null;
    //         yield return null;
    //     }
    // }

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
