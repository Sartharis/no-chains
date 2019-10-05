using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnDelay = 0.5f;
    [SerializeField] Rigidbody2D toSpawn = null;
    [SerializeField] float spawnForce = 100.0f;

    

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            Rigidbody2D body = Instantiate(toSpawn, transform.position, transform.rotation);
            if (body)
            {
                body.AddForce(transform.right * spawnForce);
            }
        }
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }
}
