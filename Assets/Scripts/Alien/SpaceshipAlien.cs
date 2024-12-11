using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipAlien : MonoBehaviour
{   

    public GameObject Ball;
    public Transform BallSpawner;
    
    private Transform Player;

    public float moveSpeed = 4.5f, distanceBtwPlayerToChase = 5f, timeBtwAddForce = 6f, thrustmoveForwardSpeed = 4f, timeTakeToSpawnBall = 1.6f;
    private float addForceTime, timeTakenToSpawnBall;
    private bool thrustOnLiefSide;


    void Awake ()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        timeTakenToSpawnBall = timeTakeToSpawnBall;
    }


    void Update ()
    {

        // MOVE LEFT
        if (transform.position.x - Player.transform.position.x > distanceBtwPlayerToChase)
            Move (true);

        // MOVE RIGHT 
        else if (transform.position.x - Player.transform.position.x < -distanceBtwPlayerToChase)
            Move (false);
    }


    void FixedUpdate () 
    {
    
        timeTakenToSpawnBall -= Time.deltaTime;

        if (timeTakenToSpawnBall < 0 && Player.transform.position.y < -1f)
        {
            SpawnBall ();
            timeTakenToSpawnBall = timeTakeToSpawnBall;
        }

    }


    void Move (bool left)
    {
        Vector2 temp = transform.position;

        if (left)
            temp.x -= moveSpeed * Time.deltaTime;
        else 
            temp.x += moveSpeed * Time.deltaTime;

        transform.position = temp;
    }


    void SpawnBall () {
        Instantiate(Ball, BallSpawner.position, BallSpawner.rotation);
    }

    
}  // Class
