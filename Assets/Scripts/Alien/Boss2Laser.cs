using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Laser : MonoBehaviour
{
    private Animator Animation;
    private BoxCollider2D collider2D;

    public float timer;


    void Awake ()
    {
        Animation = GetComponent<Animator>();
        collider2D = GetComponent<BoxCollider2D>();
    }

    
    void FixedUpdate ()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
            Animation.Play ("hide");
    }

    public void DestroyAfterAnimation ()
    {
        Destroy (gameObject);
    }


    public void DisableCollider ()
    {
        collider2D.enabled = false;
    }

    
}  // Class
