using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLevel : MonoBehaviour
{
    //Room Names
    public string Kitchen;
    public string Office;
    public string ServerRoom;

    //amount enemys in each room
    public int KitchenEnemyCount;
    public int OfficeEnemyCount;
    public int ServerEnemyCount;

    //animator to open doors
    public Animator animator;

    //counter per room
    public int TotalDead;

    public void IsComplete(int DeadEnemyCount, string EnemyRoom)
    {
        TotalDead += DeadEnemyCount;
        if (EnemyRoom == Kitchen)
        {
            if (TotalDead == KitchenEnemyCount)
            {
                Debug.Log("open");
                animator.SetBool("RoomLock", false);
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
                Debug.Log("open");
                animator.SetBool("RoomLock", false);
            }
            else
            {
                // Debug.Log("stay closed");
            }
        }
        else if (EnemyRoom == ServerRoom)
        {
            if (TotalDead == ServerEnemyCount)
            {
                Debug.Log("open");
                animator.SetBool("RoomLock", false);
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
