using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 6.0f;
    private Vector2 vel = new Vector2(0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        transform.position += (Vector3)(vel  * Time.deltaTime);
    }
}
