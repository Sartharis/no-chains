using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] bool destroyOnHit = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health h = collision.collider.GetComponent<Health>();
        if (h)
        {
            h.ChangeHealth(-damage);
            if (destroyOnHit)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health h =collision.GetComponent<Health>();
        if(h)
        {
            h.ChangeHealth(-damage);
            if (destroyOnHit)
            {
                Destroy(gameObject);
            }
        }
    }
}
