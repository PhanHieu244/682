using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipAlienBall : MonoBehaviour
{
    
    public GameObject AlienToSpawn;
    private Transform Player;
    private Rigidbody2D Physics2D;

    public ParticleSystem particle;
    private PlayParticle playParticleScript;

    private AudioSource SpaceshipAlienBallSfx;

    public float thrustmoveForwardSpeed = 5f, thrustmoveUpSpeed = 3f;
    private float timer = 1f;
    private bool startTimer;


    void Awake ()
    {
        playParticleScript = GameObject.FindGameObjectWithTag("playParticle").GetComponent<PlayParticle>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Physics2D = GetComponent<Rigidbody2D>();
        SpaceshipAlienBallSfx = GameObject.FindGameObjectWithTag ("AudioSources").transform.GetChild(12).GetComponent<AudioSource>();
    }


    void Start ()
    {
        if (Player.transform.position.x < transform.position.x)
            Physics2D.AddForce(new Vector2(-thrustmoveForwardSpeed, thrustmoveUpSpeed), ForceMode2D.Impulse);

        else
            Physics2D.AddForce(new Vector2(thrustmoveForwardSpeed, thrustmoveUpSpeed), ForceMode2D.Impulse);

    }


    void FixedUpdate () 
    {
        if (startTimer)
            timer -= Time.deltaTime;

        if (timer < 0)
        {
            // SFX
            if (PlayerPrefs.GetInt("Sound") == 0)
                SpaceshipAlienBallSfx.Play ();

            Instantiate(AlienToSpawn, transform.position, Quaternion.identity);
            playParticleScript.DestroyAndPlayParticles(particle, transform.position, gameObject);
        }

        if (transform.position.y < -7f)
            Destroy (gameObject);
    
    }


    void OnCollisionEnter2D(Collision2D target) 
    {
        if (target.gameObject.tag == "Platform")
            startTimer = true;    

        if (!startTimer && target.gameObject.tag == "Ghost Alien")
        {
            AlienHealth targetAlienHealthScript = target.gameObject.GetComponent<AlienHealth>();
            targetAlienHealthScript.health = 0;
        }
    }


}
