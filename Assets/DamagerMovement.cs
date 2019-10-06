using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerMovement : MonoBehaviour
{
    [SerializeField] float circleForce = 0.0f;
    [SerializeField] float lifeTime = 5.0f;
    [SerializeField] float followForce = 0.0f;
    [SerializeField] float randomForce = 0.0f;
    [SerializeField] float randomTimeMin = 0.0f;
    [SerializeField] float randomTimeMax = 0.0f;
    [SerializeField] bool rotateVel = false;
    private float targetScale = 1.0f;
    private Vector3 startScale;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale;
        body = GetComponent<Rigidbody2D>();    
        StartCoroutine(RandomMove());
    }

    IEnumerator RandomMove()
    {
        while (true)
        {
            if(GameObject.FindGameObjectWithTag("Player") && (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).magnitude < 15.0f)
            {
                yield return new WaitForSeconds(Random.Range(randomTimeMin, randomTimeMax));
                targetScale = 1.2f;
                yield return new WaitForSeconds(0.4f);
                body.AddForce(Random.insideUnitCircle * randomForce);
                body.AddForce(followForce * (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized);
                targetScale = 1.0f;
                //transform.localScale = startScale * 0.7f;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, startScale * targetScale, 0.1f);

        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(body.velocity.magnitude > 0.01f && rotateVel)
        {
            body.SetRotation(Quaternion.FromToRotation(new Vector3(1,0,0), body.velocity.normalized));
        }
        body.AddForce((-transform.up* 5000 + transform.right).normalized * circleForce);
    }
}
