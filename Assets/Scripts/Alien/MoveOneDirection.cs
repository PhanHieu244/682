using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOneDirection : MonoBehaviour {
    
    public float moveSpeed;

    [HideInInspector]
    public bool move;

    public bool right;

    private float maxTravelX;

    void Awake () {
        move = true;
        maxTravelX = transform.position.x + 15f;
    }

    void Update () {
        if (move)
            Move ();

        if (right && transform.position.x > maxTravelX)
            Destroy (gameObject);
    }

    void Move () 
    {
        Vector2 temp = transform.position;

        if (right)
            temp.x += moveSpeed * Time.deltaTime;
        else 
            temp.x -= moveSpeed * Time.deltaTime;

        transform.position = temp;
    }
    
}
