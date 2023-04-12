using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float range = 10f;
    public float fireRate = 1f;
    public float bulletSpeed = 10f;
    public Transform bulletSpawn;
    public GameObject bulletPrefab;

    private Transform target;
    private float nextFireTime;

    void Start()
    {
        // Ambil transform dari game object player
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Hitung jarak antara enemy dan player
        float distance = Vector3.Distance(transform.position, target.position);

        // Jika player dalam jangkauan tembakan
        if (distance <= range)
        {
            // Putar enemy ke arah player
            transform.LookAt(target);

            // Jika belum cooldown dari tembakan sebelumnya
            if (Time.time >= nextFireTime)
            {
                // Buat objek tembakan baru
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

                // Beri kecepatan pada objek tembakan
                bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed * Time.deltaTime;

                // Update nextFireTime sesuai dengan fireRate
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }
}
