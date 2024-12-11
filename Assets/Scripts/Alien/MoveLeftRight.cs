using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour {

    private Transform Player;

    public float moveSpeed;
    public float maxMovePosX;
    public bool left, right;

    private float minX, maxX;
    public bool isGhostAlien;

    void Awake () {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        minX = transform.position.x - maxMovePosX;
        maxX = transform.position.x + maxMovePosX;
    }


    void Start ()
    {
        if (isGhostAlien)
        {
            if (Player.transform.position.x < transform.position.x)
            {
                left = true;
                right = false;
            }

            else
            {
                left = false;
                right = true;

                transform.Rotate(0f, 180f, 0f);
            }
        }
    }


    void Update () {
        MoveLeftAndRight ();
    }
    
    void MoveLeftAndRight () {

        Vector2 temp = transform.position;

        if (left) {
            temp.x -= moveSpeed * Time.deltaTime;
            if (temp.x <= minX) {
                transform.Rotate(0f, 180f, 0f);
                left = false;
                right = true;
            }
        }

        if (right) {
            temp.x += moveSpeed * Time.deltaTime;
            if (temp.x >= maxX) {
                transform.Rotate(0f, 180f, 0f);
                 right = false;
                left = true;
            }
        }

        transform.position = temp;
    }


}
