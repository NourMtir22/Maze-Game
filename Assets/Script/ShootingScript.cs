using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject bulletPrefab; // The bullet prefab
    public Transform bulletSpawn; // The bullet spawn point
    public float bulletSpeed = 50f; // The speed of the bullet (increased for longer range)
    public float shootRate = 0.5f; // The rate at which the player can shoot
    private float shootCooldown;
    public float bulletLifetime = 5f; // The lifetime of the bullet before it gets destroyed
    public GameObject muzzleFlashPrefab; // The muzzle flash particle system prefab

    void Start()
    {
        shootCooldown = 0f;
    }

    void Update()
    {
        shootCooldown -= Time.deltaTime;

        if (Input.GetButton("Fire1") && shootCooldown <= 0f) // "Fire1" is the default input for left ctrl or mouse click
        {
            Shoot();
            shootCooldown = shootRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = bulletSpawn.forward * bulletSpeed;

        Destroy(bullet, bulletLifetime); // Destroy the bullet after 'bulletLifetime' seconds

        if (muzzleFlashPrefab != null)
        {
            GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, bulletSpawn.position, bulletSpawn.rotation);
            Destroy(muzzleFlash, 0.5f); // Destroy the muzzle flash after 0.5 seconds
        }
    }
}
