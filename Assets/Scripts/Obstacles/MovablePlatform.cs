using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour
{

    private GameObject SetPlayerChildren, SetPlayerParent;
    
    public float moveSpeed = 4f, posMoveX, posMoveY;
    private float minMoveX, maxMoveX, minMoveY, maxMoveY;
    public bool moveX, moveY, left, right, up, down;


    void Awake ()
    {
        SetPlayerChildren = gameObject.transform.GetChild(1).gameObject;
        SetPlayerParent = GameObject.FindGameObjectWithTag("SetPlayerParent");
    }


    void Start () 
    {
        if (moveX) 
        {
            minMoveX = transform.position.x - posMoveX;
            maxMoveX = transform.position.x + posMoveX;
        }

        if (moveY) 
        {
            minMoveY = transform.position.y - posMoveY;
            maxMoveY = transform.position.y + posMoveY;
        }
    }


    void Update () 
    {
        if (moveX)
            MoveX ();

        if (moveY)
            MoveY ();
    }


    void MoveX () 
    {
        Vector3 temp = transform.position;

       if (left) {
            temp.x -= moveSpeed * Time.deltaTime;

            if (temp.x <= minMoveX) 
            {
                left = false;
                right = true;
            }
        }

        if (right) 
        {
            temp.x += moveSpeed * Time.deltaTime;

            if (temp.x >= maxMoveX) 
            {
                left = true;
                right = false;
            }
        }

        transform.position = temp;

    }


    void MoveY () 
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
    

    void OnCollisionStay2D(Collision2D target) {
        if (moveX) 
        {
            if (target.gameObject.tag == "Player") 
                GameObject.FindGameObjectWithTag("Player").transform.SetParent(SetPlayerChildren.transform.parent);
        }
    }


    void OnCollisionExit2D(Collision2D target) {
        if (moveX) 
        {
            if (target.gameObject.tag == "Player")
                GameObject.FindGameObjectWithTag("Player").transform.SetParent(SetPlayerParent.transform.parent);
        }
    }


} // Class
