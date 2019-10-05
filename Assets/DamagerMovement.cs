using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerMovement : MonoBehaviour
{
    [SerializeField] float circleForce = 0.0f;
    [SerializeField] float lifeTime = 5.0f;
    [SerializeField] float randomForce = 0.0f;
    [SerializeField] float randomTimeMin = 0.0f;
    [SerializeField] float randomTimeMax = 0.0f;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();    
        if (randomForce > 0.01f) StartCoroutine(RandomMove());
    }

    IEnumerator RandomMove()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(randomTimeMin, randomTimeMax));
            body.AddForce(Random.insideUnitCircle * randomForce);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(body.velocity.magnitude > 0.01f)
        {
            body.SetRotation(Quaternion.FromToRotation(new Vector3(1,0,0), body.velocity.normalized));
        }
        body.AddForce((-transform.up* 5000 + transform.right).normalized * circleForce);

        lifeTime -= Time.deltaTime;
        if(lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }
}
