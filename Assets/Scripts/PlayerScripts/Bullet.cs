using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public ParticleSystem particle;
    public ParticleSystem smallParticle;

    private PlayParticle playParticleScript;

    private BulletSpawner BulletSpawnerScript;
    
    private float moveSpeed = 7f, moveSpeedY = 7f, maxTravelPosX = 10f;

    private bool left;
    private float travelPosX;

    private bool shoot_up;

    void Awake () {
        left = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().left;
        playParticleScript = GameObject.FindGameObjectWithTag("playParticle").GetComponent<PlayParticle>();
        travelPosX = transform.position.x + maxTravelPosX;

        BulletSpawnerScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<BulletSpawner>();
        shoot_up = BulletSpawnerScript.shootUp;

        // if (shoot_up)
            moveSpeed += 3.3f;
    }

    void Update () {

        if (shoot_up) 
            MoveXY ();

        else 
           MoveX ();

        if (transform.position.x > travelPosX)
            Destroy(gameObject);

    }

    void MoveX () {

        Vector2 temp = transform.position;

        if (left)
            temp.x -= moveSpeed * Time.deltaTime;
        else
            temp.x += moveSpeed * Time.deltaTime; 

        transform.position = temp;

    }

    void MoveXY () {

        Vector2 temp = transform.position;

        if (left)
        {
            temp.x -= moveSpeed * Time.deltaTime;
            temp.y += moveSpeedY * Time.deltaTime; 
        }
            
        else
        {
            temp.x += moveSpeed * Time.deltaTime; 
            temp.y += moveSpeedY * Time.deltaTime; 
        }
            
        transform.position = temp;

    }

    void OnTriggerEnter2D(Collider2D target) {

        if (target.tag == "Air Platform" || target.tag == "AirShooterAlien" 
            || target.tag == "FourSpikesAlien" || target.tag == "SingleEyeAlien" 
            || target.tag == "SpikesAlien" || target.tag == "ElectricShockAlien" || target.tag == "ShieldAlien" || target.tag == "Bone Alien" || target.tag == "Boss1" || target.tag == "Current Paul" || target.tag == "Mad Runner Alien" || target.tag == "Small Alien" || target.tag == "Bomb Alien" || target.tag == "Bomb" || target.tag == "Spikes" || target.tag == "ChainWheel" || target.tag == "Spaceship Alien" || target.tag == "Spaceship Alien ball" || target.tag == "Ghost Alien" || target.tag == "Circle Spikes Alien" || target.tag == "Boss2")
        {
            playParticleScript.DestroyAndPlayParticles(particle, transform.position, gameObject);   // Destroy And Play Particles
        }

    }

}
