using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullet : MonoBehaviour {

    public ParticleSystem particle;
    private PlayParticle playParticle;

    private AudioSource AirShooterAlienBulletSfx;

     void Awake () {
        playParticle = GameObject.FindGameObjectWithTag("playParticle").GetComponent<PlayParticle>();
        AirShooterAlienBulletSfx = GameObject.FindGameObjectWithTag ("AudioSources").transform.GetChild(2).GetComponent<AudioSource>();

        // SFX
        if (PlayerPrefs.GetInt("sound") == 0)
            AirShooterAlienBulletSfx.Play ();
    }
    
    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Player") {
            playParticle.DestroyAndPlayParticles(particle, transform.position, gameObject);   // Destroy And Play Particles
        }
    }
    
}
