using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RasengunMove : MonoBehaviour
{
    // класс отвечает за движение любой пули 
    public float speedGun = 10f;
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.right, speedGun * Time.deltaTime);
        
        Destroy(gameObject, 2F);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit)
        {
            unit.Damage();
        }
        Destroy(gameObject); 
    }
}
