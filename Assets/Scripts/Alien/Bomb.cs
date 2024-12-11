using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    private Rigidbody2D Physics2D;

    public ParticleSystem particle;
    private PlayParticle playParticleScript;

    private MoveLeftRight BombAlienMoveLeftRightScript;
    
    private AudioSource BombExplosionSfx;

    private bool isAlienLeft;

    public float moveTowardsSpeed = 3f, moveUpSpeed = 4f, waitTimeBeforeBlast = 5f;

    public bool isBoss;
    public float BossmoveTowardsSpeed = 3f, BossmoveUpSpeed = 4f;


    void Awake ()
    {
        Physics2D = GetComponent<Rigidbody2D>();

        playParticleScript = GameObject.FindGameObjectWithTag("playParticle").GetComponent<PlayParticle>();

        if (!isBoss)
        {
            BombAlienMoveLeftRightScript = GameObject.FindGameObjectWithTag("Bomb Alien").GetComponent<MoveLeftRight>();
            isAlienLeft = BombAlienMoveLeftRightScript.left;
        }
            
        BombExplosionSfx = GameObject.FindGameObjectWithTag ("AudioSources").transform.GetChild(11).GetComponent<AudioSource>();

    }


    void Start ()
    {
        if (!isBoss)
        {
            // ADD FORCE TO LEFT
            if (isAlienLeft)
            {
                Physics2D.AddForce(new Vector2(-moveTowardsSpeed, moveUpSpeed), ForceMode2D.Impulse);
            }

            // ADD FORCE TO RIGHT
            else
            {
                Physics2D.AddForce(new Vector2(moveTowardsSpeed, moveUpSpeed), ForceMode2D.Impulse);
            }
        }

        if (isBoss)
        {
            Physics2D.AddForce(new Vector2(-BossmoveTowardsSpeed, BossmoveUpSpeed), ForceMode2D.Impulse);
        }

    }


    void FixedUpdate ()
    {
        waitTimeBeforeBlast -= Time.deltaTime;

        if (waitTimeBeforeBlast < 0)
        {
            // SFX
            if (PlayerPrefs.GetInt("Sound") == 0)
                BombExplosionSfx.Play ();

            playParticleScript.DestroyAndPlayParticles(particle, transform.position, gameObject);
        }
    
    }


} // Class
