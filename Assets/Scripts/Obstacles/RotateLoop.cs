using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLoop : MonoBehaviour {
    
    public float rotateSpeed;

    [HideInInspector]
    public bool rotate;

    void Awake () {
        rotate = true;
    }

    void FixedUpdate () {
        if (rotate)
            transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }
    
}
