using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : Enemy
{
    public Transform firepoint;
    public GameObject Rasengun;
    private Animator animator;
    public float timeToShoot = 100;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
        //стреляющий враг стреляет через определенный промежуток времени
    {
        timeToShoot--;
        if(timeToShoot < 1)
        {
            Shoot();
            timeToShoot = 300;
        }

        if (hp < 1) animator.SetTrigger("Dead");
    }

    private void Shoot()
    {
        Instantiate(Rasengun, firepoint.position, firepoint.rotation);
    }
}
