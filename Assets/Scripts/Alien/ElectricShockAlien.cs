using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricShockAlien : MonoBehaviour
{

    private Transform Player;
    private Animator Animation;

    private ParticleSystem ElectricCurrent; 
    private ParticleSystem ElectricSpark; 

    private AudioSource electricShockAlienSfx;

    private float timeBtwSparkAndShock = 1f, sparkAndShock;
    private bool turnLeft, turnRight, move;

    private float moveSpeed = 3f, distanceBtwPlayerToChase = 9f;

    void Awake ()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Animation = GetComponent<Animator> ();

        ElectricCurrent = transform.GetChild(5).GetComponent<ParticleSystem> ();
        ElectricSpark = transform.GetChild(6).GetComponent<ParticleSystem> ();

        electricShockAlienSfx = GameObject.FindGameObjectWithTag ("AudioSources").transform.GetChild(9).GetComponent<AudioSource>();

        sparkAndShock = timeBtwSparkAndShock;

        turnLeft = true;
        turnRight = false;
        move = true;

    }

    void FixedUpdate()
    {
        sparkAndShock -= Time.deltaTime;

        if (sparkAndShock < 0)
        {
            StartCoroutine (SparkAndShock(1f));
            sparkAndShock = timeBtwSparkAndShock + 3f;
        }
    }

    void Update ()
    {

        if (Player.transform.position.x + 1.5f > transform.position.x && !turnRight)
            TurnRight ();

        if (Player.transform.position.x < transform.position.x && !turnLeft)
            TurnLeft ();


        // MOVE LEFT
        if (transform.position.x - Player.transform.position.x > distanceBtwPlayerToChase && move)
            Move (true);

        // MOVE RIGHT 
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


    private IEnumerator SparkAndShock (float waitTime)
    {
        ElectricSpark.Play ();

        yield return new WaitForSeconds(waitTime);

        // SFX
        if (PlayerPrefs.GetInt("sound") == 0)
            electricShockAlienSfx.Play ();

        ElectricCurrent.Play ();
    }


    private void OnCollisionEnter2D(Collision2D target) 
    {
        if (target.gameObject.tag == "Bone Alien" || target.gameObject.tag == "ShieldAlien")
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
        if (target.gameObject.tag == "Bone Alien" || target.gameObject.tag == "ShieldAlien")
            move = true;
    }
    

}
