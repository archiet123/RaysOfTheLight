using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject Bullet;
    public int MaxCollisions;
    public int Collisions;
    public int WeaponDamage;


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
            //calc damage = bullet damage*playerDamageMultiplyer
            other.GetComponent<HealthScript>().DealDamage(WeaponDamage);
            Destroy();
        }
        else if (Collision.gameObject.tag == "Player")
        {
            // other.GetComponent<PlayerHealth>().DealDamage(EnemyDamage);
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
