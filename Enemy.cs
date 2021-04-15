using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
   //любой враг при соприкосновении с игрококом наносит ему урон
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Unit unit = collision.collider.GetComponent<Unit>();

        if (unit && unit is Pig)
        {
            unit.Damage();
        }
    }
}
