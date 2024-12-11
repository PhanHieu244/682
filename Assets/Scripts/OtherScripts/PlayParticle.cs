using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticle : MonoBehaviour {
    
    public void DestroyAndPlayParticles (ParticleSystem particle, Vector2 target, GameObject gameObj) {

        Destroy(gameObj);
        
        ParticleSystem newParticleSystem = Instantiate(
            particle,
            target,
            Quaternion.identity
        ) as ParticleSystem;

        newParticleSystem.Play();

        Destroy(
            newParticleSystem.gameObject,
            newParticleSystem.startLifetime
        );
    }

    public void PlayParticles (ParticleSystem particle, Vector2 target) {
        
        ParticleSystem newParticleSystem = Instantiate(
            particle,
            target,
            Quaternion.identity
        ) as ParticleSystem;

        newParticleSystem.Play();

        Destroy(
            newParticleSystem.gameObject,
            newParticleSystem.startLifetime
        );
    }

}
