using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollTrigDestroy : MonoBehaviour {
    
    public ParticleSystem particle;
    private PlayParticle playParticle;

    public bool onCollide, onTrigged;
    public string[] targetTag;

    void Awake () {
        playParticle = GameObject.FindGameObjectWithTag("playParticle").GetComponent<PlayParticle>();
    }


    void OnTriggerEnter2D(Collider2D target) {
        if (onTrigged) 
        {
            for (int i = 0; i < targetTag.Length; i++)
            {
                if (target.tag == targetTag[i])
                    SpawnParticle ();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D target) {

        if (onCollide) 
        {
            for (int i = 0; i < targetTag.Length; i++)
            {
                if (target.gameObject.tag == targetTag[i]) 
                {
                    SpawnParticle ();
                }
            }
        }
    }


    void SpawnParticle () {
        playParticle.DestroyAndPlayParticles(particle, transform.position, gameObject);
    }

}
