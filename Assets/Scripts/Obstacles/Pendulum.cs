using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour {
    
    private Rigidbody2D body2d;

    public float leftPushRange;
    public float rightPushRange;
    public float velocityThreshold;

    void Awake () {
        body2d = GetComponent<Rigidbody2D>();
        body2d.angularVelocity = velocityThreshold;
    }

    void FixedUpdate () {
        Push ();
    }

    void Push () {

        if (transform.position.z > 0 
            && transform.position.z < rightPushRange 
            && (body2d.angularVelocity > 0) 
            && body2d.angularVelocity < velocityThreshold)
        {
            body2d.angularVelocity = velocityThreshold;
        }

        else if (transform.position.z < 0
            && transform.position.z > leftPushRange
            && (body2d.angularVelocity < 0)
            && body2d.angularVelocity > velocityThreshold * -1)
        {
            body2d.angularVelocity = velocityThreshold;
        }
    }

}  // class
