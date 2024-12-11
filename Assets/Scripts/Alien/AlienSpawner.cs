using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour {
    
    public GameObject Alien;
    private Transform mainCamera;

    [HideInInspector]
    public bool playerDie;

    [HideInInspector]
    public float playerDiePosX;

    [HideInInspector]
    public float LastCheckpointX;

    private bool spawn;

    void Awake () {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        spawn = true;
    }

    void FixedUpdate () {

        if (playerDie && !spawn) {
            
            if (transform.position.x < playerDiePosX + 20f && transform.position.x > LastCheckpointX) {
                spawn = true;
            }

            playerDie = false;
        }

        if (spawn && mainCamera.transform.position.x <= transform.position.x - 16f 
            && mainCamera.transform.position.x >= transform.position.x - 18f)
        {
            Instantiate(Alien, transform.position, Quaternion.identity);
            spawn = false;
        }

    }
    
}
