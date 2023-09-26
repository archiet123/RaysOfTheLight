using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLevel : MonoBehaviour
{
    public Elevator elevator;

    //Room Names
    public string Kitchen;
    public string Office;
    public string Server;
    public string Storage;
    public string Confrence;

    //amount enemys in each room
    public int KitchenEnemyCount;
    public int OfficeEnemyCount;
    public int ServerEnemyCount;
    public int StorageEnemyCount;
    public int ConfrenceEnemyCount;
    //animator to open doors
    public Animator animator;

    //counters
    public int TotalDead;
    //completed room list
    public List<string> CompletedRooms;


    void Start()
    {
    }

    void Update()
    {
        if (CompletedRooms.Count == 5)
        {
            // Debug.Log("unlock elevator");
            elevator.LevelComplete = true;
        }
    }

    public void IsComplete(int DeadEnemyCount, string EnemyRoom)
    {

        TotalDead += DeadEnemyCount;
        if (EnemyRoom == Kitchen)
        {
            if (TotalDead == KitchenEnemyCount)
            {
                //checkLevel
                animator.SetBool("RoomLock", false);
                TotalDead = 0;
                // Debug.Log($"cl: {TotalDead}");
            }
            else
            {
                // Debug.Log("stay closed");
                // Debug.Log($"cl1: {TotalDead}");
            }
        }
        else if (EnemyRoom == Office)
        {
            if (TotalDead == OfficeEnemyCount)
            {
                //checkLevel
                animator.SetBool("RoomLock", false);
                TotalDead = 0;
            }
            else
            {
                // Debug.Log("stay closed");
            }
        }
        else if (EnemyRoom == Server)
        {
            if (TotalDead == ServerEnemyCount)
            {
                //checkLevel                
                animator.SetBool("RoomLock", false);
                TotalDead = 0;
            }
            else
            {
                // Debug.Log("stay closed");
            }
        }
        else if (EnemyRoom == Storage)
        {
            if (TotalDead == StorageEnemyCount)
            {
                //checkLevel
                animator.SetBool("RoomLock", false);
                TotalDead = 0;
            }
            else
            {
                // Debug.Log("stay closed");
            }
        }
        else if (EnemyRoom == Confrence)
        {
            if (TotalDead == ConfrenceEnemyCount)
            {
                //checkLevel
                animator.SetBool("RoomLock", false);
                TotalDead = 0;
            }
            else
            {
                // Debug.Log("stay closed");
            }
        }
        else
        {
            Debug.Log("broke");
        }

    }
}
