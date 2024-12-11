using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repositioning : MonoBehaviour {

    public BoxCollider2D BC2D;
    public CircleCollider2D[] CC2D;
    private Animator anim;
    private Rigidbody2D Physics2D;
    
    private Fade fade;
    private Health HealthScript;
    private PlayerController controller;

    public GameObject ControlUI;

    [HideInInspector]
    public float diePosX;

    public float PosY;
    private float LastCheckpointPosX;
    private bool die;

    void Awake () {
        anim = GetComponent<Animator>();
        HealthScript = GetComponent<Health>();
        fade = GameObject.FindGameObjectWithTag("Fade").GetComponent<Fade>();
        controller = GetComponent<PlayerController>();
        Physics2D = GetComponent<Rigidbody2D>();
        LastCheckpointPosX = -3.13f;
    }

    void FixedUpdate () {

        if (die) {

            int health = HealthScript.health;

            if (transform.position.y < -6f && health > 0) {
                RepositioningPlayer ();
                die = false;
            }

            if (transform.position.y < -6f && health <= 0) 
            {
                Vector2 temp = transform.position;
                temp.y = -6f;
                transform.position = temp;

                Physics2D.isKinematic = true;

                die = true;
            }

            
        }
        else {

            int health = HealthScript.health;
            
            if (!ControlUI.activeSelf && health > 0)
                ControlUI.SetActive(true);
        }

    }
    
    void OnTriggerEnter2D(Collider2D target) {

        if (target.tag == "Checkpoint") {
            LastCheckpointPosX = target.transform.position.x;
        }

    }

    void EnableAndDisbleColliders (bool trueOrFalse) {
        BC2D.enabled = trueOrFalse;

        for (int i = 0; i < CC2D.Length; i++) {
            CC2D[i].enabled = trueOrFalse;
        }
    }

    void DestroyGameObjects (string tag) {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject target in gameObjects) {
            GameObject.Destroy (target);
        }
    }

    public void SendInfoToAlienSpawner () {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("AlienSpawner");
        AlienSpawner spawner;
        foreach (GameObject target in gameObjects) {
            spawner = target.GetComponent("AlienSpawner") as AlienSpawner;
            spawner.playerDie = true;
            spawner.playerDiePosX = diePosX;
            spawner.LastCheckpointX = LastCheckpointPosX;
        }
    }

    public void SendInfoToStarSpawner () {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("StarSpawner");
        ObstacleSpawner spawner;
        foreach (GameObject target in gameObjects) {
            spawner = target.GetComponent("ObstacleSpawner") as ObstacleSpawner;
            spawner.playerDie = true;
            spawner.playerDiePosX = diePosX;
            spawner.LastCheckpointX = LastCheckpointPosX;
        }
    }

    void DestroyAliensAndBullets () {
        DestroyGameObjects ("AirShooterAlien");
        DestroyGameObjects ("FourSpikesAlien");
        DestroyGameObjects ("SingleEyeAlien");
        DestroyGameObjects ("Mad Runner Alien");
        DestroyGameObjects ("Small Alien");
        DestroyGameObjects ("ElectricShockAlien");
        DestroyGameObjects ("ShieldAlien");
        DestroyGameObjects ("Bone Alien");
        DestroyGameObjects ("Bomb Alien");
        DestroyGameObjects ("Bomb");
        DestroyGameObjects ("ShieldAlienBullet");
        DestroyGameObjects ("AlienBullet");
        DestroyGameObjects ("Boss1 Bullet");
        DestroyGameObjects ("SpikesAlien");
        DestroyGameObjects ("Spaceship Alien");
        DestroyGameObjects ("Spaceship Alien ball");
        DestroyGameObjects ("Ghost Alien");
        DestroyGameObjects ("Circle Spikes Alien");
        DestroyGameObjects ("PlayerBulletGreen");
        DestroyGameObjects ("PlayerBulletYellow");
    }

    public void Die () {

        die = true;

        controller.moveLeft = false;

        controller.moveRight = false;

        controller.RemoveIntraction ();  // Disable Controller Intraction

        EnableAndDisbleColliders (false); // Disable Colliders of player

        anim.SetBool ("die", true); // Play die Animation

        GetComponent<BulletSpawner>().DefaultPlayerFiring ();  // Default Player firing

        GetComponent<PlayerController>().DefaultPlayerDirection();  // Default Player Direction

    }

    void RepositioningPlayer () {

        EnableAndDisbleColliders (true); // Enable Colliders of player

        fade.playFadeIn ();  // Play Fade In Animation

        DestroyAliensAndBullets (); // Destroy Aliens or Player Bullet
        
        controller.EnableIntraction ();  // Enable Controller Intraction

        anim.SetBool ("die", false); // Stop die Animation

        SendInfoToAlienSpawner ();

        // position the player to last checkpoint position
        Vector2 temp = transform.position;
        temp.x = LastCheckpointPosX;
        temp.y = PosY;
        transform.position = temp;

        SendInfoToStarSpawner ();

    }

}
