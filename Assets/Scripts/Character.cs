using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame updateB
    Rigidbody rigidbody_;
    void Start()
    {
        rigidbody_ = GetComponent<Rigidbody>();
        //transform.position.x = 10;
    }

    Vector3 postionZ0;
    Vector3 angles;
    // Update is called once per frame
    void Update()
    {
        postionZ0 = transform.position;
        postionZ0.z = 0;
        transform.position = postionZ0;
    }

    void FixedUpdate() {
        rigidbody_.velocity = Vector3.zero;
        rigidbody_.angularVelocity = Vector3.zero;
    }

    void Move(float x, float y) 
    {
        postionZ0 = transform.position;
        postionZ0.x = x;
        postionZ0.y = y;
        postionZ0.z = 0;
        transform.position = postionZ0;
    }

    void Rotate(float angle) {
        angles = transform.eulerAngles;
        angles.x = angle;
        angles.y = -90;
        angles.z = 90;
        transform.eulerAngles = angles;
    }
}

