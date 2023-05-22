using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint1;
    public Transform firePoint2;
    public float fireRate1 = 0.5f;
    public float fireRate2 = 0.7f;
    public float fireDelay = 0.2f;
    public float bulletSpeed = 20f;
    private float fireCountdown1 = 0f;
    //private float fireCountdown2 = 0f;
    private bool firedFrom1 = true;
    public bool canShoot = false;
    
    

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            canShoot = true;
            Debug.Log("deneme");
        }
    }
    

    void Update()
    {
        if (canShoot && fireCountdown1 <= 0f)
        {
            if (firedFrom1)
            {
                Shoot(firePoint1, fireRate1);
                fireCountdown1 = fireRate1 + fireDelay;
                firedFrom1 = false;
            }
            else
            {
                Shoot(firePoint2, fireRate2);
                fireCountdown1 = fireRate2;
                firedFrom1 = true;
            }
        }
        fireCountdown1 -= Time.deltaTime;
    }

    void Shoot(Transform firePoint, float fireRate)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = -firePoint.up * bulletSpeed;
    }
    

    
}