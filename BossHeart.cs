using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHeart : Unit
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (hp < 1) animator.SetTrigger("Dead");
    }
}
