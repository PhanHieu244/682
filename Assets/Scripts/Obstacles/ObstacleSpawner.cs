using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
    
    public GameObject Obstacle;
    private Transform mainCamera;

    public bool isStar;

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

        if (playerDie && !spawn && isStar) {
            
            if (transform.position.x < playerDiePosX + 5f && transform.position.x > LastCheckpointX) {
                spawn = true;
            }

            playerDie = false;
        }

        if (spawn && mainCamera.transform.position.x + 16f >= transform.position.x) {
            Instantiate(Obstacle, transform.position, Quaternion.identity);
            spawn = false;
        }

    }
}
