﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunTurret : MonoBehaviour
{

    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 0.2f;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 2f;

	// Use this for initialization
	void Start ()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
	}

	// Update is called once per frame
	void Update ()
    {
        CountDownAndShoot();
	}

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject gunshot = Instantiate(
            projectile,
            transform.position,
            Quaternion.identity
            ) as GameObject;
        gunshot.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed, 0);
    }

}
