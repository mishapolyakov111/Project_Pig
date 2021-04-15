using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //любой стреляющий объект имеет дочерний объект, являющийся точкой откуда ведется стрельба
    public Transform firepoint;
    public GameObject Rasengun;
    private float timeToShoot = 10;


    void Update()
        //отслеживает нажатие кнопки стрельбы и вызывает метод стрельбы
    {
        if (Input.GetButtonDown("Fire1")&&(timeToShoot < 0))
        {
            Shoot();
            timeToShoot = 50;
        }

        timeToShoot--;
    }

    void Shoot()
    {
        Instantiate(Rasengun, firepoint.position, firepoint.rotation);
    }
}
