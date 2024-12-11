using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneAlien : MonoBehaviour
{

    private Transform Player;
    private Animator Animation;

    private bool turnLeft, turnRight, move;

    private float moveSpeed = 3f, distanceBtwPlayerToChase = 1f;


    void Awake ()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Animation = GetComponent<Animator> ();

        turnLeft = true;
        turnRight = false;

        move = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x + 1.5f > transform.position.x && !turnRight)
            TurnRight ();

        if (Player.transform.position.x < transform.position.x && !turnLeft)
            TurnLeft ();


        // MOVE LEFT
        if (transform.position.x - Player.transform.position.x > distanceBtwPlayerToChase && Player.transform.position.y < 0 && move)
            Move (true);

        // MOVE RIGHT 
        else if (transform.position.x - Player.transform.position.x < -distanceBtwPlayerToChase && Player.transform.position.y < 0 && move)
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


    private void OnCollisionEnter2D(Collision2D target) 
    {
        if (target.gameObject.tag == "ShieldAlien" || target.gameObject.tag == "ElectricShockAlien")
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
        if (target.gameObject.tag == "ShieldAlien" || target.gameObject.tag == "ElectricShockAlien")
            move = true;
    }

}  // Class
