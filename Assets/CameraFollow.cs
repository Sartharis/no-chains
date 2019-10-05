using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float LeftLimit = -10.0f;
    [SerializeField] float RightLimit = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(new Vector3(LeftLimit,transform.position.y,0),new Vector3(RightLimit,transform.position.y,0));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(Mathf.Clamp(GameObject.FindGameObjectWithTag("Player").transform.position.x,LeftLimit,RightLimit), transform.position.y, transform.position.z), 0.1f);
        }
    }
}
