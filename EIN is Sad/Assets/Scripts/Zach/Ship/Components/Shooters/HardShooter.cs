﻿using UnityEngine;

public class HardShooter : MonoBehaviour, IShooter
{
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private Transform[] shootpoints;

    public void Shoot()
    {
        for (int i = 0; i < shootpoints.Length; i++)
        {
            Instantiate(projectile, shootpoints[i]);
        }
    }
}