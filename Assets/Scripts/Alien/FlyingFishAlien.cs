using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingFishAlien : MonoBehaviour
{
    
    private Rigidbody2D Physics2D;

    public float moveTowardsSpeed = 2f, moveUpSpeed = 10f;


    void Awake ()
    {
        Physics2D = GetComponent<Rigidbody2D>();
    }


    void Start ()
    {
        Physics2D.AddForce(new Vector2(-moveTowardsSpeed, moveUpSpeed), ForceMode2D.Impulse);
    }


    void FixedUpdate () 
    {
        if (transform.position.y < -7f)
            Destroy (gameObject);
    }


}  // Class
