using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainWheel : MonoBehaviour
{
    
    public float moveSpeed = 4f, rotateSpeed = 200f, posY = 2f;
    private float minMoveY, maxMoveY;

    public bool up, down;


    void Awake () 
    {
        minMoveY = transform.position.y - posY;
        maxMoveY = transform.position.y + posY;
    }


    void Update () 
    {
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);

        Move ();
    }


    void Move () 
    {
        Vector3 temp = transform.position;

       if (up) 
       {
            temp.y += moveSpeed * Time.deltaTime;

            if (temp.y >= maxMoveY) 
            {
                up = false;
                down = true;
            }
        }

        if (down) 
        {
            temp.y -= moveSpeed * Time.deltaTime;

            if (temp.y <= minMoveY) 
            {
                up = true;
                down = false;
            }
        }

        transform.position = temp;
    }


}  // Class
