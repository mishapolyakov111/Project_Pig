using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemy
{
    public float speed;
    private float distance = 25;

    private Transform player;
    public Transform startPosition;

    private Animator animator;
    private SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    void Update()
       
    {
        if (hp < 1) animator.SetTrigger("Dead");
        //дракон начинает преследовать ирока только если он находится достаточно близко
        if ((GameObject.FindGameObjectWithTag("Player") != null)
            &&(Vector3.Distance(transform.position, player.position) > 3)
            &&(Vector3.Distance(transform.position, player.position) < distance))
        {
            Vector3 direction = player.position - transform.position; 

            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

            sprite.flipX = direction.x > 0;
        }
        else
        {
            if (startPosition != null)
            {
                Vector3 direction = startPosition.position - transform.position;

                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

                sprite.flipX = direction.x > 0;
            }
        }
        
    }
}
