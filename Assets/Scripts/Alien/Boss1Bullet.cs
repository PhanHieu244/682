using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Bullet : MonoBehaviour
{

    public ParticleSystem particle;
    private PlayParticle playParticleScript;

    private float moveSpeed = 7f;


    void Awake ()
    {
        playParticleScript = GameObject.FindGameObjectWithTag("playParticle").GetComponent<PlayParticle>();
    }


    void Update()
    {
        Vector2 temp = transform.position;
        temp.x -= moveSpeed * Time.deltaTime;
        transform.position = temp;
    }

    private void OnTriggerEnter2D(Collider2D target) 
    {
        if (target.tag == "Player")
            playParticleScript.DestroyAndPlayParticles(particle, transform.position, gameObject);   // Destroy And Play Particles
    }

} // Class
 