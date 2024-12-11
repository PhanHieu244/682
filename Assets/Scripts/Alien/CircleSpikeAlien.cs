using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpikeAlien : MonoBehaviour
{
    
    public float rotateSpeed = 200f, moveSpeed = 3f;


    void Update ()
    {
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);

        Move ();
    }


    void Move ()
    {
        Vector3 temp = transform.position;
        temp.x -= moveSpeed * Time.deltaTime;
        transform.position = temp;
    }

}  // Class
