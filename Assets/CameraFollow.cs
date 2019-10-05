using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, transform.position.y, transform.position.z), 0.1f);
        }
    }
}
