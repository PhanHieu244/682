using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tope : MonoBehaviour
{

    private Animator Animation;
    
    public GameObject LeftBullet;
    public GameObject RightBullet;

    public Transform LeftBulletSpawner;
    public Transform RightBulletSpawner;

    private Transform Player;

    private AudioSource BulletSfx;

    public float timeBtwSpawnBullet;
    private float timeTakenToSpawnBullet, posX;
    private bool spawnLeft, start;


    void Awake ()
    {
        Animation = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        BulletSfx = GameObject.FindGameObjectWithTag ("AudioSources").transform.GetChild(3).GetComponent<AudioSource>();

        timeTakenToSpawnBullet = timeBtwSpawnBullet;
        posX = transform.position.x;
    }

    void FixedUpdate ()
    {

        float playerPosX = Player.transform.position.x;

        if (playerPosX < posX)
        {
            if (playerPosX + 20f > posX)
                start = true;
            else 
                start = false;
        }

        else if (playerPosX > posX)
        {
            if (playerPosX - 20f < posX)
                start = true;
            else 
                start = false;
        }
        

        if (start)
        {
            timeTakenToSpawnBullet -= Time.deltaTime;

            if (timeTakenToSpawnBullet < 0 && spawnLeft)
            {
                Animation.Play ("fireLeft");
                SpawnBullet (true);
            }

            if (timeTakenToSpawnBullet < 0 && !spawnLeft)
            {
                Animation.Play ("fireRight");
                SpawnBullet (false);
            }

        }

    }


    void SpawnBullet (bool left)
    {
        // SFX
        if (PlayerPrefs.GetInt("Sound") == 0)
            BulletSfx.Play ();

        timeTakenToSpawnBullet = timeBtwSpawnBullet;
        
        if (left)
        {
            Instantiate (LeftBullet, LeftBulletSpawner.position, Quaternion.identity);
            spawnLeft = false;
        }

        else 
        {
            Instantiate (RightBullet, RightBulletSpawner.position, Quaternion.identity);
            spawnLeft = true;
        }
    }

}  // Class
