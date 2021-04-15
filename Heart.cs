using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    // при соприкосновении с сердечком оно уничтожается и вызывает восстановление жизней игрока
    void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if ((unit is Pig) && (unit.hp != unit.maxHp)) 
        {
            unit.Heal();
            Destroy(gameObject);
        }
    }
}
