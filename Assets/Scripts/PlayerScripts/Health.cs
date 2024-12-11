using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    
    public Image[] hearts;

    private AudioSource PlayerDieSfx;

    public GameObject ControlUI;
    private AudioSource HealthGainSfx;

    public int health;

    public bool die;
    public float timeBtwDieFromPoisionParticle = 1f;
    private float timeBtwCall, timeTakenToDieFromPoision;
    private bool PlayDieSfxOnce;


    void Awake () {
        PlayerDieSfx = GameObject.FindGameObjectWithTag ("AudioSources").transform.GetChild(4).GetComponent<AudioSource>();
        HealthGainSfx = GameObject.FindGameObjectWithTag ("AudioSources").transform.GetChild(14).GetComponent<AudioSource>();

        timeBtwCall = 1f;
        timeTakenToDieFromPoision = timeBtwDieFromPoisionParticle;
    }

    void FixedUpdate () {

        for (int i = 0; i < hearts.Length; i++) {
            if (i < health) {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }

        timeBtwCall -= Time.deltaTime;
        
        if (die && timeBtwCall < 0) {
            die = false;
            PlayDieSfxOnce = false;
        }

        if (health <= 0) {
            GetComponent<GameOver>().gameOver ();
        }

        if (transform.position.y < -6f)
        {
            if (health > 0 && !die) 
            {
                ReduceHealthAndRespawn ();
            }
        }
        
        if (timeTakenToDieFromPoision < 0)
        {
            if (health > 0 && !die) 
            {
                ReduceHealthAndRespawn ();
                timeTakenToDieFromPoision = timeBtwDieFromPoisionParticle;
            }
        }

    }

    void OnCollisionEnter2D(Collision2D target) {
        if (target.gameObject.tag == "SingleEyeAlien" || target.gameObject.tag == "FourSpikesAlien" || target.gameObject.tag == "ElectricShockAlien" || target.gameObject.tag == "ShieldAlien" || target.gameObject.tag == "Bone Alien" || target.gameObject.tag == "Boss1" || target.gameObject.tag == "Mad Runner Alien" || target.gameObject.tag == "Small Alien" || target.gameObject.tag == "Bomb Alien" || target.gameObject.tag == "Ghost Alien" || target.gameObject.tag == "Circle Spikes Alien" || target.gameObject.tag == "Boss2") {
            if (health > 0 && !die) {
                ReduceHealthAndRespawn ();
            }    
        }
    }

    void OnCollisionStay2D(Collision2D target) {
        if (target.gameObject.tag == "SingleEyeAlien" || target.gameObject.tag == "FourSpikesAlien" || target.gameObject.tag == "ElectricShockAlien" || target.gameObject.tag == "ShieldAlien" || target.gameObject.tag == "Bone Alien" || target.gameObject.tag == "Boss1" || target.gameObject.tag == "Mad Runner Alien" || target.gameObject.tag == "Small Alien" || target.gameObject.tag == "Bomb Alien" || target.gameObject.tag == "Ghost Alien" || target.gameObject.tag == "Circle Spikes Alien" || target.gameObject.tag == "Boss2") {
            if (health > 0 && !die) {
                ReduceHealthAndRespawn ();
            }    
        }
    }

    void OnTriggerEnter2D (Collider2D target) {

        if (target.tag == "AirShooterAlien" || target.tag == "AlienBullet"
            || target.tag == "Blade" || target.tag == "SpikesAlien" || target.tag == "ShieldAlienBullet" || target.tag == "Boss1 Bullet" || target.tag == "Bone Alien" || target.tag == "ChainWheel" || target.tag == "Current Paul" || target.tag == "Spikes" || target.tag == "Spaceship Alien" || target.tag == "Tope Bullet" || target.tag == "Boss Laser") 
            {
                if (health > 0 && !die) {
                    ReduceHealthAndRespawn ();
                }  
            }


        if (target.tag == "Health Gainer")
        {
            // SFX
            if (PlayerPrefs.GetInt("sound") == 0) {
                HealthGainSfx.Play ();
            }

            health += 1;
        }
        
    }

    private void OnParticleCollision(GameObject target) 
    {
        if (target.tag == "ElectricCurrentParticle" || target.tag == "Bomb Blast Particle")
        {
            if (health > 0 && !die) {
                ReduceHealthAndRespawn ();
            } 
        }

        if (target.tag == "Poision Particle")
        {
            timeTakenToDieFromPoision -= Time.deltaTime;
        }

    }


    void ReduceHealthAndRespawn () {

        die = true;

        ControlUI.SetActive (false);

        // SFX
        if (PlayerPrefs.GetInt("sound") == 0 && !PlayDieSfxOnce) {
            PlayerDieSfx.Play ();
            PlayDieSfxOnce = true;
        }

        timeBtwCall = 2.5f;
        
        health -= 1;
        GetComponent<Repositioning>().Die ();
        GetComponent<Repositioning>().diePosX = transform.position.x;
    
    }

    
}
