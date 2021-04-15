using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    
    private float speed = 15;
    private bool turn = true;

    private float timeToPatrol = 1000;
    private float timeToShoot = 0;
    private float timeToHeal = 50;
    private float timeToInstant = 500;

    public Transform groundcheck;
    public LayerMask Ground;
    public LayerMask Box;
    private Collider2D bossCollider;
    public Transform firepoint1;
    public Transform firepoint2;
    
    public GameObject Rasengun;
    public GameObject BossHeart;
    public GameObject Dragon;
    

    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        bossCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        //блок кода отвечает за временные рамки бега и стрельбы босса
        if (timeToPatrol > 0)
        {
            Patrol();
        }
        else
        {
            if (timeToShoot < 1)
            {
                Shoot();
                timeToShoot = 70;
            }
            timeToShoot--;
        }

        if (timeToPatrol < -1000) timeToPatrol = 1000;
        //босс восстанавливает жизни пока на сцене есть его сердце
        if ((GameObject.FindGameObjectWithTag("BossHeart") != null) && (timeToHeal < 0))
        {
            Heal();
            timeToHeal = 150;
        }
        else
        //в противном случае он может получать урон, но через некоторое время сердце снова появится
        {
            if ((GameObject.FindGameObjectWithTag("BossHeart") == null))
            {
                maxHp = hp;
                timeToInstant--;
            }

            if (timeToInstant < 0)
            {
                Instantiate(BossHeart);
                Instantiate(Dragon);
                timeToInstant = 500;
            }
        }

        timeToPatrol--;
        timeToHeal--;

        if (hp < 1) animator.SetTrigger("Dead");
    }

    void Patrol()//патрулирование босса
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.right, speed * Time.deltaTime);
        turn = !Physics2D.OverlapCircle(groundcheck.position, 0.3f, Ground)||bossCollider.IsTouchingLayers(Box);
        if (turn) transform.Rotate(0f, 180f, 0f);

        animator.SetBool("IsRunning", true);
    }


    void Shoot()//стрельба босса
    {
        animator.SetBool("IsRunning", false);

        Instantiate(Rasengun, firepoint1.position, firepoint1.rotation);
        Instantiate(Rasengun, firepoint2.position, firepoint2.rotation);
    }
}
