using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAlien : MonoBehaviour
{
    // DECLARING VARIABLES
    private Transform Player;
    private Animator Animation;
    private Transform BulletSpawner;
    public GameObject Bullet;
    

    [HideInInspector] public bool turnLeft, turnRight, move;
    private float timeBtwShoot = 2f, shootTime;
    private float moveSpeed = 3f, distanceBtwPlayerToChase = 7f, playerPosYOnAir = 0f;

    void Awake ()
    {
        // ASSIGNING VARIABLES 
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Animation = GetComponent<Animator> ();

        shootTime = timeBtwShoot;
        BulletSpawner = transform.GetChild(5).GetComponent<Transform> ();

        turnLeft = true;
        turnRight = false;
        move = true;
        
    }

    void FixedUpdate ()
    {


        shootTime -= Time.deltaTime;

        // IF SHOOT TIME VARIABLE LESS THAN 0 AND PLAYER IS NOT ON PLATFORM THEN SHOOT
        if (shootTime < 0 && Player.transform.position.y < playerPosYOnAir)
        {
            Shoot ();
            shootTime = timeBtwShoot;
        }

    }


    void Update ()
    {
        // IF PLAYER POSITION GREATER THAN ALIEN POSITION THEN TURN RIGHT
        if (Player.transform.position.x + 1.5f > transform.position.x && !turnRight)
            TurnRight ();

        // IF PLAYER POSITION LESS THAN ALIEN THEN TURN LEFT
        if (Player.transform.position.x < transform.position.x && !turnLeft)
            TurnLeft ();


        // WHEN GAP BETWEEN PLAYER AND ALIEN INCREASE TO THE LEFT SIDE - ALIEN CHASE PLAYER TO LEFT
        if (transform.position.x - Player.transform.position.x > distanceBtwPlayerToChase && move)
            Move (true);

        // // WHEN GAP BETWEEN PLAYER AND ALIEN INCREASE TO THE RIGHT SIDE - ALIEN CHASE PLAYER TO RIGHT 
        else if (transform.position.x - Player.transform.position.x < -distanceBtwPlayerToChase && move)
            Move (false);

        // PLAY IDLE ANIMATION
        else 
            Animation.SetFloat ("Speed", 0f);

    }


    void TurnLeft () {
        if (turnLeft)
            return;
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        turnLeft = true;
        turnRight = false;
    }


    void TurnRight () {
        if (turnRight)
            return;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        turnLeft = false;
        turnRight = true;
    }


    void Move (bool left)
    {
        Vector2 temp = transform.position;

        // PLAY WALK ANIMATION 
        Animation.SetFloat ("Speed", 1f);

        if (left)
            temp.x -= moveSpeed * Time.deltaTime;
        else 
            temp.x += moveSpeed * Time.deltaTime;

        transform.position = temp;
    }


    void Shoot ()
    {
        Instantiate (Bullet, BulletSpawner.position, Quaternion.identity);
    }


    private void OnCollisionEnter2D(Collision2D target) 
    {
        if (target.gameObject.tag == "Bone Alien" || target.gameObject.tag == "ElectricShockAlien")
        {
            if (transform.position.x > target.gameObject.transform.position.x)
            {
                if (turnLeft)
                    move = false;
                else
                    move = true;
            }
            
            if (transform.position.x < target.gameObject.transform.position.x)
            {
                if (turnRight)
                    move = false;
                else
                    move = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D target) 
    {
        if (target.gameObject.tag == "Bone Alien" || target.gameObject.tag == "ElectricShockAlien")
            move = true;
    }

}
