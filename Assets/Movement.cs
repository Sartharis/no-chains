using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] SpriteRenderer slowDownSprite = null;
    [SerializeField] float timeSlowScale = 0.5f;
    [SerializeField] float moveSpeed = 6.0f;
    private Vector2 vel = new Vector2(0.0f, 0.0f);
    private Rigidbody2D body = null;
    public Vector2 knockback = new Vector2();

    private float timeFactor = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();   
    }

    private void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            Time.timeScale = timeSlowScale;
            timeFactor = 1.0f / timeSlowScale;
            Time.fixedDeltaTime = 0.02f / timeFactor;
            slowDownSprite.enabled = true;
        }
        else
        {
            Time.timeScale = 1.0f;
            timeFactor = 1.0f;
              Time.fixedDeltaTime = 0.02f / timeFactor;
            slowDownSprite.enabled = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        knockback = Vector2.Lerp(knockback, new Vector2(), 0.1f);
        Vector2 dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (dir.magnitude > 0.1f)
        {
            vel = Vector2.Lerp(vel, (dir.normalized * moveSpeed), 0.2f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,-dir.x * 10.0f), 0.2f);
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1,1+dir.y * 0.1f,1), 0.2f);
        }
        else
        {
            vel = Vector2.Lerp(vel, new Vector2(), 0.2f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,0), 0.2f);
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1,1 +dir.y * 0.1f,1), 0.2f);
        }
        body.velocity = timeFactor*vel/Mathf.Max(knockback.magnitude, 1.0f) + knockback;
        //body.MovePosition(body.position + (vel  * Time.fixedDeltaTime));
    }
}
