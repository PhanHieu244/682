using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss2 : MonoBehaviour
{

    public GameObject Laser;
    public Transform LaserSpawner;

    public GameObject CircleSpikesAlien;
    public Transform CircleSpikesAlienSpawner;

    public GameObject Bomb;
    public Transform BombSpawner;

    public GameObject SpaceshipAlien;
    public Transform SpaceshipAlienSpawner;

    private Transform Player;
    public Slider BossHealthbarSlider;

    public ParticleSystem particle;
    private PlayParticle playParticleScript;

    public GameObject BossHealthbar;

    private Animator Animation;

    private AudioSource DieSfx;
    private AudioSource LaserSfx;
    private AudioSource ElectricShockSfx;

    private ScoreScript scoreScript;

    public GameObject UpperElectricCurrent;

    public float timeBtwSpawnLaser, timeBtwSpawnSpikesAlien, timeBtwSpawnBomb, timeBtwSpawnSpaceshipAlien;
    private float timeTakenToSpawnLaser, timeTakenToSpawnSpikesAlien, timeTakenToSpawnBomb, timeTakenToSpawnSpaceshipAlien;

    public int bossHealth = 120, yellowBuletDamage = 1, greenBuletDamage = 2, score = 10000; // DEFAULT VALUE
    private bool startSpawningSpikesAlien, startSpawningBomb, spawningBomb, spawnSpaceshipAlien;


    void Awake ()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Animation = GetComponent<Animator>();
        playParticleScript = GameObject.FindGameObjectWithTag("playParticle").GetComponent<PlayParticle>();

        DieSfx = GameObject.FindGameObjectWithTag ("AudioSources").transform.GetChild(8).GetComponent<AudioSource>();
        LaserSfx = GameObject.FindGameObjectWithTag ("AudioSources").transform.GetChild(13).GetComponent<AudioSource>();
        ElectricShockSfx = GameObject.FindGameObjectWithTag ("AudioSources").transform.GetChild(9).GetComponent<AudioSource>();

        scoreScript = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript> ();

        timeTakenToSpawnLaser = timeBtwSpawnLaser;
        timeTakenToSpawnSpikesAlien = timeBtwSpawnSpikesAlien;
        timeTakenToSpawnBomb = timeBtwSpawnBomb;
        timeTakenToSpawnSpaceshipAlien = timeBtwSpawnSpaceshipAlien;
    }


    void FixedUpdate ()
    {
        // UPDATE BOSS HEALTHBAR REGULARLY
        BossHealthbarSlider.value = bossHealth;

        if (transform.position.x - Player.transform.position.x < 14f)
        {
            timeTakenToSpawnLaser -= Time.deltaTime;
            timeTakenToSpawnSpikesAlien -= Time.deltaTime;
            timeTakenToSpawnBomb -= Time.deltaTime;
            timeTakenToSpawnSpaceshipAlien -= Time.deltaTime;

            if (timeTakenToSpawnLaser < 0 )
            {
                Animation.SetBool ("Shoot", true);
                timeTakenToSpawnLaser = timeBtwSpawnLaser;
            }


            if (timeTakenToSpawnSpikesAlien < 0 && startSpawningSpikesAlien)
            {
                Spawn (CircleSpikesAlien, CircleSpikesAlienSpawner);
                timeTakenToSpawnSpikesAlien = timeBtwSpawnSpikesAlien;
            }


            if (timeTakenToSpawnBomb < 0 && startSpawningBomb)
            {
                Spawn (Bomb, BombSpawner);
                timeTakenToSpawnBomb = timeBtwSpawnBomb;
            }

        
            if (timeTakenToSpawnSpaceshipAlien < 0 && spawnSpaceshipAlien)
            {
                Spawn (SpaceshipAlien, SpaceshipAlienSpawner);
                timeTakenToSpawnSpaceshipAlien = timeBtwSpawnSpaceshipAlien;
            }

            // WHEN PLAYER TRY TO JUMP OVER BOSS - THEN ENABLE UPPER ELECTRIC SHOCK CHILDREN GAMEOBJECT & DISABLE AFTER A SECOND
            if (Player.transform.position.x + 1f > transform.position.x)
                StartCoroutine(UpperElectricShock());

        }


        if (bossHealth < 80 && !startSpawningSpikesAlien && !startSpawningBomb)
            startSpawningSpikesAlien = true;


        if (bossHealth < 50 && !startSpawningBomb)
        {
            startSpawningBomb = true;
            startSpawningSpikesAlien = false;

            timeTakenToSpawnBomb = timeBtwSpawnBomb;
        }


        if (bossHealth < 20 && !spawnSpaceshipAlien) 
        {
            spawnSpaceshipAlien = true;
        }


        if (bossHealth <= 0)
        {
            // DISABLE BOSS HEALTH BAR
            BossHealthbar.SetActive (false);

            // SFX
            if (PlayerPrefs.GetInt("sound") == 0)
                DieSfx.Play ();

            // UPDATE SCORE
            scoreScript.UpdateScore (score);

            // SPAWN PARTICLE AND DESTROY BOSS
            playParticleScript.DestroyAndPlayParticles(particle, transform.position, gameObject);   // Destroy And Play Particles
        }

    }


    void Spawn (GameObject SpawnObject, Transform SpawnPosition)
    {
        Instantiate (SpawnObject, SpawnPosition.position, Quaternion.identity);
    }


    public void SpawnLaser ()
    {    
        // SFX
        if (PlayerPrefs.GetInt("sound") == 0)
            LaserSfx.Play ();

        Instantiate (Laser, LaserSpawner.position, Quaternion.identity);
    }


    public void PlayIdleAnimation ()
    {
        Animation.SetBool ("Shoot", false);
    }


    private void OnTriggerEnter2D(Collider2D target) 
    {
        if (target.tag == "PlayerBulletYellow")
        {
            bossHealth -= yellowBuletDamage;
        }

        if (target.tag == "PlayerBulletGreen")
        {
            bossHealth -= greenBuletDamage;
        }

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

    
}  // Class
