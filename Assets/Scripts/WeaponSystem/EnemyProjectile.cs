using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject Bullet;
    public int MaxCollisions;
    public int Collisions;
    public int WeaponDamage;
    public int EnemyDamage;

    private void Update()
    {
        if (Collisions > MaxCollisions)
        {
            Destroy();
        }
    }

    private void OnCollisionEnter(Collision Collision)
    {
        GameObject other = Collision.gameObject;
        Collisions++;

        if (Collision.gameObject.tag == "Enemy")
        {
            // other.GetComponent<HealthScript>().DealDamage(WeaponDamage);
            Destroy();

        }
        if (Collision.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().DealDamage(EnemyDamage);
            // Debug.Log("damage player");
        }
        else if (Collision.gameObject.tag == "Untagged")
        {
            Destroy();
        }
    }
    private void Destroy()
    {
        Destroy(gameObject);

    }
}
