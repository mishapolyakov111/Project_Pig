using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float hp;
    private float time;
    public float maxHp;

    protected void FixedUpdate()
        //любой враг умирает если у него нет жизней или он находится слишком низко(высоко)
    {
        if (hp < 1)
        { 
            Die();
        }

        time--;
        if (time <= 0) gameObject.GetComponentInChildren<Renderer>().material.color = Color.white;

        if (Mathf.Abs(transform.position.y) > 100) hp = 0;
    }

    public virtual void Die()
    {
        Destroy(gameObject, 0.4F);
    }
    public virtual void Damage()
        //при нанесении урона объекту у него уменьшется количество жизней и он краснеет
    {
        hp--;

        time = 10f;
        if ((time >= 0) && (hp > 0)) gameObject.GetComponentInChildren<Renderer>().material.color = Color.red; 
    }
    public void Heal()
    //функция восстанавливет количество жизней и объект зеленеет 
    {
        hp = maxHp;
        time = 20f;
        if ((time >= 0) && (hp > 0)) gameObject.GetComponentInChildren<Renderer>().material.color = Color.green;
    }
}
