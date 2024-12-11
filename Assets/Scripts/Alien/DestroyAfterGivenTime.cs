using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterGivenTime : MonoBehaviour
{

    public ParticleSystem particle;
    private PlayParticle playParticleScript;

    public float timeTakeToDestroy;
    private float timeTaken;

    public bool NoParticle;
  
    void Awake ()
    {
        if (!NoParticle)
            playParticleScript = GameObject.FindGameObjectWithTag("playParticle").GetComponent<PlayParticle>();

        timeTaken = timeTakeToDestroy;
    }

    void FixedUpdate ()
    {
        timeTaken -= Time.deltaTime;
        
        if (timeTaken < 0)
        {
            if (!NoParticle)
                playParticleScript.DestroyAndPlayParticles(particle, transform.position, gameObject);
            else 
                Destroy (gameObject);
        }
    }
    
}
