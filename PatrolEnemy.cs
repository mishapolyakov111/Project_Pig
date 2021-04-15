using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : Enemy
{
    public float speed;

    public bool turn = true;

    //объект, который проверяет наличие платформы впереди врага
    public Transform groundcheck;

    public LayerMask Ground;

    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.right, speed * Time.deltaTime);
        //патрулирующий враг разворачивается, когда платформа кончается
        turn = !Physics2D.OverlapCircle(groundcheck.position, 0.1f, Ground);
        if (turn) transform.Rotate(0f, 180f, 0f);

        if (hp < 1) animator.SetTrigger("Dead");
    }
   
}
