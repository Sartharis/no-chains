using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 3;
    [SerializeField] float hitInvTime = 0.5f;
    private int health = 1;
    private float invTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        invTime -= Time.deltaTime;
    }

    public void ChangeHealth(int change)
    {
        if (change > 0 || invTime <= 0.01f)
        {
            health = Mathf.Clamp(health + change, 0, maxHealth);
            if (change < 0)
            {
                invTime = hitInvTime;
            }
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
