using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour {
    
    public Transform BulletSpanwer1;
    public Transform BulletSpanwer2;
    public Transform BulletSpanwer3;

    public GameObject GunSparkParticleYellow;
    public GameObject GunSparkParticleGreen;

    public Transform GunSparkSpawner;
    public Transform GunSparkSpawnerUpper;
    

    public Transform BulletSpanwer_ShootUp_1;
    public Transform BulletSpanwer_ShootUp_2;
    public Transform BulletSpanwer_ShootUp_3;

    public GameObject YellowBulletPref;
    public GameObject GreenBulletPref;

    private Animator Animation;

    private AudioSource BulletSfx;
    private AudioSource PowerUpSfx;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private bool yellowBullet, greenBullet;
    private bool normalFire, tripleFire; //, upDownFire;

    public bool shootUp;

    void Awake () {
        timeBtwShots = startTimeBtwShots;
        normalFire = true;
        yellowBullet = true;

        Animation = GetComponent<Animator>();

        BulletSfx = GameObject.FindGameObjectWithTag ("AudioSources").transform.GetChild(1).GetComponent<AudioSource>();
        PowerUpSfx = GameObject.FindGameObjectWithTag ("AudioSources").transform.GetChild(6).GetComponent<AudioSource>();
    }

    void Update () {

        // if (Input.GetButtonDown("Fire1"))
        //     Shoot ();

        timeBtwShots -= Time.deltaTime;

    }

    public void Shoot (bool shoot_up) {

        shootUp = shoot_up;

        if (shoot_up)
            Animation.Play ("Shoot_up");
        else
            Animation.Play ("idle");

        if (timeBtwShots <= 0) {

            // SFX
            if (PlayerPrefs.GetInt("sound") == 0)
                BulletSfx.Play ();

            // SPAWN GUN SPARK
            if (!shoot_up)
            {
                if (yellowBullet)
                    SpawnGunSpark (GunSparkParticleYellow, false);
                else 
                    SpawnGunSpark (GunSparkParticleGreen, false);
            }

            else 
            {
                if (yellowBullet)
                    SpawnGunSpark (GunSparkParticleYellow, true);
                else 
                    SpawnGunSpark (GunSparkParticleGreen, true);
            }
            


            if (normalFire) {

                if (yellowBullet)
                {
                    if (shoot_up)
                        InstantiateBullet (YellowBulletPref, BulletSpanwer_ShootUp_1);
                    else
                        InstantiateBullet (YellowBulletPref, BulletSpanwer1);
                }

                if (greenBullet)
                {
                    if (shoot_up)
                        InstantiateBullet (GreenBulletPref, BulletSpanwer_ShootUp_1);
                    else
                        InstantiateBullet (GreenBulletPref, BulletSpanwer1);
                }

            }

            else if (tripleFire) {

                if (yellowBullet) 
                {
                    if (shoot_up)
                    {
                        InstantiateBullet (YellowBulletPref, BulletSpanwer_ShootUp_1);
                        InstantiateBullet (YellowBulletPref, BulletSpanwer_ShootUp_2);
                        InstantiateBullet (YellowBulletPref, BulletSpanwer_ShootUp_3);
                    }

                    else 
                    {
                        InstantiateBullet (YellowBulletPref, BulletSpanwer1);
                        InstantiateBullet (YellowBulletPref, BulletSpanwer2);
                        InstantiateBullet (YellowBulletPref, BulletSpanwer3);
                    }
                }

                if (greenBullet) 
                {
                    if (shoot_up)
                    {
                        InstantiateBullet (GreenBulletPref, BulletSpanwer_ShootUp_1);
                        InstantiateBullet (GreenBulletPref, BulletSpanwer_ShootUp_2);
                        InstantiateBullet (GreenBulletPref, BulletSpanwer_ShootUp_3);
                    } 
                    else 
                    {
                        InstantiateBullet (GreenBulletPref, BulletSpanwer1);
                        InstantiateBullet (GreenBulletPref, BulletSpanwer2);
                        InstantiateBullet (GreenBulletPref, BulletSpanwer3);
                    }
                }

            }
            
            timeBtwShots = startTimeBtwShots;
        }
    }

    void InstantiateBullet (GameObject BulletPrefab, Transform BulletSpanwerPosition)
    {
        Instantiate(BulletPrefab, BulletSpanwerPosition.position, Quaternion.identity);
    }


    void SpawnGunSpark (GameObject GunSpark, bool spawnUpper)
    {
        if (spawnUpper)
            Instantiate(GunSpark, GunSparkSpawnerUpper.position, Quaternion.identity);
        else 
            Instantiate(GunSpark, GunSparkSpawner.position, Quaternion.identity);
    }


    void OnTriggerEnter2D(Collider2D target) {

        if (target.tag == "BulletPowerupRed") {

            // SFX
            if (PlayerPrefs.GetInt("sound") == 0)
                PowerUpSfx.Play ();

            normalFire = false;
            tripleFire = true;
        }

        if (target.tag == "BulletPowerupGreen") {

            // SFX
            if (PlayerPrefs.GetInt("sound") == 0)
                PowerUpSfx.Play ();
                
            yellowBullet = false;
            greenBullet = true;
        }
    }

    public void DefaultPlayerFiring () {

        // Select yellow bullet
        yellowBullet = true;
        greenBullet = false;

        // Select Normal Fire
        normalFire = true;
        tripleFire = false;

    }

}
