using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDown : MonoBehaviour {
    
    public float moveSpeed;
    public float maxMovePosY;
    public bool up, down;

    private float minY, maxY;

    void Awake () {
        minY = transform.position.x - maxMovePosY;
        maxY = transform.position.x + maxMovePosY;
    }

    void Update () {
        MoveUpAndDown ();
    }
    
    void MoveUpAndDown () {

        Vector2 temp = transform.position;

        if (down) {
            temp.y -= moveSpeed * Time.deltaTime;
            if (temp.y <= minY) {
                down = false;
                up = true;
            }
        }

        if (up) {
            temp.y += moveSpeed * Time.deltaTime;
            if (temp.y >= maxY) {
                up = false;
                down = true;
            }
        }

        transform.position = temp;
    }

}
