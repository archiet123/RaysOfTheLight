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

    public void IsComplete(int DeadEnemyCount, string EnemyRoom)
    {
        if (EnemyRoom == Kitchen)
        {
            if (DeadEnemyCount == KitchenEnemyCount)
            {
                Debug.Log("open");
                animator.SetBool("RoomLock", false);
            }
            else
            {
                Debug.Log("stay closed");
            }
        }
        else if (EnemyRoom == Office)
        {
            if (DeadEnemyCount == OfficeEnemyCount)
            {
                Debug.Log("open");
                animator.SetBool("RoomLock", false);
            }
            else
            {
                Debug.Log("stay closed");
            }
        }
        else if (EnemyRoom == ServerRoom)
        {
            if (DeadEnemyCount == OfficeEnemyCount)
            {
                Debug.Log("open");
                animator.SetBool("RoomLock", false);
            }
            else
            {
                Debug.Log("stay closed");
            }
        }
        else
        {
            Debug.Log("broke");
        }

    }
}
