using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateEnemy : Enemy
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (hp < 1) animator.SetTrigger("Dead");
    }

}
