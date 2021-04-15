using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{   //кактус не является живым врагом, поэтому не наследуется от класса Enemy
    public void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is Pig)
        {
            unit.Damage();
        }
    }
}