using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour
{

    public GameObject Bullet;
    public Transform BulletSpawner;
    public Slider BossHealthbarSlider;

    public GameObject ElectricSpark;
    public GameObject ElectricCurrent;
    public GameObject UpperElectricCurrent;
    public GameObject RandomAlienSpawner;
    public GameObject BossHealthbar;

    private Animator Animation;

    public ParticleSystem particle;
    private PlayParticle playParticleScript;

    private AudioSource BulletSfx;
    private AudioSource ElectricShockSfx;
    private AudioSource DieSfx;

    private Transform Player;

    private ScoreScript scoreScript;

    public int score;

    public float timeBtwShoot = 1.8f, timeBtwElectricShock = 2.2f;  // DEFAULT VALUE
    private float shootTime, electricShockTime;
    private bool electricShock, startShooting, spawnRandomAlien;

    public int boosHealth = 120, yellowBuletDamage = 2, greenBuletDamage = 4; // DEFAULT VALUE

    void Awake ()
    {
        Animation = GetComponent<Animator>();
        playParticleScript = GameObject.FindGameObjectWithTag("playParticle").GetComponent<PlayParticle>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        scoreScript = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript> ();

        BulletSfx = GameObject.FindGameObjectWithTag ("AudioSources").transform.GetChild(3).GetComponent<AudioSource>();
        ElectricShockSfx = GameObject.FindGameObjectWithTag ("AudioSources").transform.GetChild(9).GetComponent<AudioSource>();
        DieSfx = GameObject.FindGameObjectWithTag ("AudioSources").transform.GetChild(8).GetComponent<AudioSource>();

        shootTime = timeBtwShoot;   
        electricShockTime = timeBtwElectricShock;
    }


    void FixedUpdate ()
    {
    
        // UPDATE BOSS HEALTHBAR REGULARLY
        BossHealthbarSlider.value = boosHealth;


        // WHEN PLAYER POSITION IS NEAR BOSS
        if (Player.transform.position.x > transform.position.x - 14f)
        {
            // DECREASE VALUE OF THESE VARIABLES REGULARLY
            shootTime -= Time.deltaTime;
            electricShockTime -= Time.deltaTime;


            // WHEN SHOOT TIME VARIABLE LESS THAN 0 & ELECTRICSHOCK VARIABLE FALSE - 
            // THEN SHOOT & PLAY SHOOT ANIMATION & SHOOTIME VARIABLE BECOME EQOAL TO TIMEBTWSHOOT VARIABLE
            if (shootTime < 0 && !electricShock)
            {   
                Animation.SetBool ("Shoot", true);

                Shoot ();
                shootTime = timeBtwShoot; 
            }

            
            // WHEN BOSS HEALTH LESS THAN EQUAL TO 60 - THEN ELECTRIC SHOCK STARTS
            if (boosHealth <= 60)
            {
                if (electricShockTime < 0)
                {
                    // SFX
                    if (PlayerPrefs.GetInt("sound") == 0)
                        ElectricShockSfx.Play ();
                        
                    StartCoroutine (ElectricShock ());
                }
            }

        }


        // WHEN BOSS HEALTH LESS THAN EQUAL TO 50 - THEN START SPAWNING RANDOM AIR SHOOTER ALIEN
        if (boosHealth <= 50 && !spawnRandomAlien)
        {
            RandomAlienSpawner.SetActive (true);
            spawnRandomAlien = true;
        }


        // WHEN BOSS HEALTH BECOME 0 OR LESS - DIE
        if (boosHealth <= 0)
        {
            StartCoroutine (BossDie ());
        }


        // WHEN PLAYER TRY TO JUMP OVER BOSS - THEN ENABLE UPPER ELECTRIC SHOCK CHILDREN GAMEOBJECT & DISABLE AFTER A SECOND
        if (Player.transform.position.x + 1f > transform.position.x)
            StartCoroutine(UpperElectricShock());

    }


    IEnumerator BossDie ()
    {
        // DISABLE BOSS HEALTH BAR
        BossHealthbar.SetActive (false);

        yield return new WaitForSeconds (0.1f);

        // DESTROY RANDOM ALIEN SPAWNER GAMEOBJECT
        Destroy (RandomAlienSpawner);

        // UPDATE SCORE
        scoreScript.UpdateScore (score);

        // SFX
        if (PlayerPrefs.GetInt("sound") == 0)
            DieSfx.Play ();

        // SPAWN PARTICLE AND DESTROY BOSS
        playParticleScript.DestroyAndPlayParticles(particle, transform.position, gameObject);   // Destroy And Play Particles
    }


    IEnumerator ElectricShock ()
    {
        electricShock = true;

        // ENABLE ElectricSpark CHILDREN GAMEOBJECT
        ElectricSpark.SetActive (true);

        // WAIT
        yield return new WaitForSeconds (1.8f);

        // ENABLE ElectricCurrent CHILDREN GAMEOBJECT
        ElectricCurrent.SetActive (true);

        // WAIT
        yield return new WaitForSeconds (1f);

        // DISABLE BOTH ElectricSpark & ElectricCurrent CHILDREN GAMEOBJECT
        ElectricCurrent.SetActive (false);
        ElectricSpark.SetActive (false);

        electricShock = false;
        electricShockTime = timeBtwElectricShock;
    }


    IEnumerator UpperElectricShock ()
    {
        // SFX
        if (PlayerPrefs.GetInt("sound") == 0)
            ElectricShockSfx.Play ();

        UpperElectricCurrent.SetActive (true);

        yield return new WaitForSeconds (1f);

        UpperElectricCurrent.SetActive (false);
    }


    void Shoot ()
    {
        // SFX
        if (PlayerPrefs.GetInt("sound") == 0)
            BulletSfx.Play ();

        Instantiate (Bullet, BulletSpawner.position, Quaternion.identity);
    }


    // CALL WHEN SHOOT ANIMATION END - EVENT ADD ON ANIMATOR TAB AT LAST FRAME OF SHOOT ANIMATION
    public void PlayIdleAnimation ()
    {
        Animation.SetBool ("Shoot", false);
    }


    private void OnTriggerEnter2D(Collider2D target) 
    {
        if (target.tag == "PlayerBulletYellow")
        {
            boosHealth -= yellowBuletDamage;
        }

        if (target.tag == "PlayerBulletGreen")
        {
            boosHealth -= greenBuletDamage;
        }

    }


}  // Class
