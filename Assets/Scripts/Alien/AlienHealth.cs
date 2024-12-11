using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienHealth : MonoBehaviour {

    public ParticleSystem particle;

    private PlayParticle playParticle;
    private ScoreScript scoreScript;

    private AudioSource alienDieSfx;

    public int health;
    public int yellowBulletDamage;
    public int greenBulletDamage;
    public int score;

    void Awake () {
        playParticle = GameObject.FindGameObjectWithTag("playParticle").GetComponent<PlayParticle>();
        scoreScript = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript> ();
        alienDieSfx = GameObject.FindGameObjectWithTag ("AudioSources").transform.GetChild(8).GetComponent<AudioSource>();
    }

    void Update () {

        if (health <= 0 ) 
        {
            // SFX
            if (PlayerPrefs.GetInt("sound") == 0)
                alienDieSfx.Play ();

            scoreScript.UpdateScore (score);
            playParticle.DestroyAndPlayParticles(particle, transform.position, gameObject);   // Destroy And Play Particles
        }

        if (transform.position.y < -7f)
        {
            Destroy (gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D target) {

        if (target.tag == "PlayerBulletYellow") {
            health -= yellowBulletDamage;
        }

        if (target.tag == "PlayerBulletGreen") {
            health -= greenBulletDamage;
        }

    }
    

    void OnParticleCollision(GameObject target) 
    {
        if (target.tag == "Bomb Blast Particle")
        {
            health = 0;
        }
    }


}
