using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAlienBullet : MonoBehaviour
{
    
    private ShieldAlien ShieldAlienScript;

    public ParticleSystem particle;
    private PlayParticle playParticleScript;

    private AudioSource ShieldAlienBulletSfx;

    private float moveSpeed = 5f, maxTravelPosX = 18f, travelPosX;
    private bool turnLeft;

    
    void Awake ()
    {
        ShieldAlienScript = GameObject.FindGameObjectWithTag("ShieldAlien").GetComponent<ShieldAlien> ();
        turnLeft = ShieldAlienScript.turnLeft;

        playParticleScript = GameObject.FindGameObjectWithTag("playParticle").GetComponent<PlayParticle>();

        ShieldAlienBulletSfx = GameObject.FindGameObjectWithTag ("AudioSources").transform.GetChild(3).GetComponent<AudioSource>();

        // SFX
        if (PlayerPrefs.GetInt("sound") == 0)
            ShieldAlienBulletSfx.Play ();

        travelPosX = transform.position.x + maxTravelPosX;
    }


    void Update ()
    {
        Vector2 temp = transform.position;

        if (turnLeft)
            temp.x -= moveSpeed * Time.deltaTime;
        else
            temp.x += moveSpeed * Time.deltaTime;
            
        transform.position = temp;

        // IF BULLET POSITION X GREATER THAN TRAVEL POS X VARIABLE
        if (transform.position.x > travelPosX)
            Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D target) 
    {
        if (target.tag == "Player")
        {
            playParticleScript.DestroyAndPlayParticles(particle, transform.position, gameObject);   // Destroy And Play Particles
        }    
    }

}
