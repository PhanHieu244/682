using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisionParticle : MonoBehaviour
{
    
    private ParticleSystem ParticleSystem;

    public float timeBtwStart = 3f;


    void Awake () 
    {
        ParticleSystem = GetComponent<ParticleSystem>();    
    }


    void Start ()
    {
        InvokeRepeating ("PlayParticle", timeBtwStart, timeBtwStart);
    }


    void PlayParticle () 
    {
        ParticleSystem.Play ();
    }
    
}
