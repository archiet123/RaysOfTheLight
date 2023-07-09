using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunScript : MonoBehaviour
{
    //bullet
    public GameObject Bullet;

    //bullet force
    public float ShootForce, UpwardForce;

    //Gun Stats
    public float TimeBetweenShooting, ReloadTime, TimeBetweenShots;
    public int MagazineSize, BulletsPerTap;
    public bool AllowButtonHold;

    int BulletsLeft, BulletsShot;

    //bools//
    bool Shooting, ReadyToShoot, Reloading;

    //Refrences
    public Camera PlayerCam;
    public Transform AttackPoint;

    public GameObject MuzzleFlash;
    public TextMeshProUGUI AmmoDisplay;

    public bool AllowInvoke = true;

    //audio definitions
    public AudioSource ShootFX;
    public AudioSource ReloadFX;

    private void Awake()
    {
        BulletsLeft = MagazineSize;
        ReadyToShoot = true;
    }

    private void Update()
    {
        MyInput();

        //Set ammo display if it exists 
        if (AmmoDisplay != null)
        {
            AmmoDisplay.SetText(BulletsLeft / BulletsPerTap + " / " + MagazineSize / BulletsPerTap);
        }
    }
    private void MyInput()
    {
        //is full auto availible
        if (AllowButtonHold)
        {
            Shooting = (Input.GetKey(KeyCode.Mouse0));
        }
        else
        {
            Shooting = (Input.GetKeyDown(KeyCode.Mouse0));
        }


        //Reloading
        if (Input.GetKeyDown(KeyCode.R) && BulletsLeft < MagazineSize && !Reloading)
        {
            Reload();
        }

        //shooting
        if (ReadyToShoot && Shooting && !Reloading && BulletsLeft > 0)
        {
            //set bullets to 0
            BulletsShot = 0;

            Shoot();
        }
    }

    private void Shoot()
    {
        //audio stuff here
        ShootFX.Play();

        ReadyToShoot = false;

        Ray ray = PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
        RaycastHit hit;

        Vector3 TargetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            TargetPoint = hit.point;
        }
        else
        {
            TargetPoint = ray.GetPoint(75);
        }

        Vector3 Direction = TargetPoint - AttackPoint.position;

        GameObject CurrentBullet = Instantiate(Bullet, AttackPoint.position, Quaternion.identity);

        CurrentBullet.transform.forward = Direction.normalized;

        CurrentBullet.GetComponent<Rigidbody>().AddForce(Direction.normalized * ShootForce, ForceMode.Impulse);
        CurrentBullet.GetComponent<Rigidbody>().AddForce(PlayerCam.transform.up * UpwardForce, ForceMode.Impulse);

        if (MuzzleFlash != null)
        {
            Instantiate(MuzzleFlash, AttackPoint.position, Quaternion.identity);
        }

        BulletsLeft--;
        BulletsShot++;

        //invoke stuff
        if (AllowInvoke)
        {
            Invoke("ResetShot", TimeBetweenShooting);
            AllowInvoke = false;
        }
        //if more than one bulletsPerTap make sure to repeat shoot function
        if (BulletsShot < BulletsPerTap && BulletsLeft > 0)
        {
            Invoke("Shoot", TimeBetweenShots);
        }
    }

    private void ResetShot()
    {
        //Allow shooting and invoke again
        ReadyToShoot = true;
        AllowInvoke = true;
    }

    private void Reload()
    {
        ReloadFX.Play();
        Reloading = true;
        Invoke("ReloadFinished", ReloadTime);
    }

    private void ReloadFinished()
    {
        BulletsLeft = MagazineSize;
        Reloading = false;
        Debug.Log("Reloaded");
    }
}
