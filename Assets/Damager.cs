using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] bool destroyOnHit = true;
    [SerializeField] float knockBackForce = 100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health h = collision.collider.GetComponent<Health>();
        Movement m = collision.collider.GetComponent<Movement>();
        if (h)
        {
            h.ChangeHealth(-damage);
            if (destroyOnHit)
            {
                Destroy(gameObject);
            }
        }

        if(m)
        {
            Vector2 knockToStart = (new Vector3(GameObject.FindGameObjectWithTag("Respawn").transform.position.x,0,0) - new Vector3(transform.position.x,0,0)).normalized * knockBackForce / 3;
            if (Vector2.Dot(knockToStart, (Vector2)(collision.transform.position - transform.position)) > 0)
            {
                m.knockback = knockToStart + (Vector2)(collision.transform.position - transform.position).normalized * knockBackForce / 1.5f;
            }
            else
            {
                m.knockback = (Vector2)(collision.transform.position - transform.position).normalized * knockBackForce / 1.5f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health h =collision.GetComponent<Health>();
        Movement m = collision.GetComponent<Movement>();
        if(h)
        {
            h.ChangeHealth(-damage);
            if (destroyOnHit)
            {
                Destroy(gameObject);
            }
        }

        if (m)
        {
            Vector2 knockToStart = (new Vector3(GameObject.FindGameObjectWithTag("Respawn").transform.position.x, 0, 0) - new Vector3(transform.position.x, 0, 0)).normalized * knockBackForce / 6;
            if (Vector2.Dot(knockToStart, (Vector2)(collision.transform.position - transform.position)) > 0)
            {
                m.knockback = knockToStart + (Vector2)(collision.transform.position - transform.position).normalized * knockBackForce / 1.5f;
            }
            else
            {
                m.knockback = (Vector2)(collision.transform.position - transform.position).normalized * knockBackForce / 1.5f;
            }
        }
    }
}
