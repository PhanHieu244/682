using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    
    private Rigidbody2D myBody;
    private Animator anim;

    public GameObject DustParticle;
    public Transform DustParticleSpawner;

    public float moveSpeed = 4.5f;
    public float JumpForce = 7f;
    public bool left, right;
    public bool moveLeft, moveRight;
    private bool Intraction;
    private bool IntractionMoveLeft;

    [HideInInspector]
    public bool isGrounded, onPlatform;

    private bool PlayDustParticle;


    void Awake () {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isGrounded = false;
        right = true;
        Intraction = true;
        IntractionMoveLeft = true;

    }
    
    void Update () {

        if (Input.GetButtonDown("Jump"))
            Jump ();

        MoveKeyboard ();

        Move ();


        if (!isGrounded && !PlayDustParticle)
            PlayDustParticle = true;

        if (isGrounded && PlayDustParticle)
        {
            Instantiate (DustParticle, DustParticleSpawner.position, Quaternion.identity);
            PlayDustParticle = false;
        }


    }

    public void MoveLeft (bool move) {
        if (Intraction)
            moveLeft = move;
    }

    public void MoveRight (bool move) {
        if (Intraction)
            moveRight = move;
    }

    public void Jump () {

        if (isGrounded && Intraction) {
            myBody.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            anim.SetBool("jump", true);
            isGrounded = false;
        }   

    }

    void Move () {

        if (moveLeft && Intraction && IntractionMoveLeft) {
            Vector2 temp = transform.position;
            temp.x -= moveSpeed * Time.deltaTime;
            transform.position = temp; 

            anim.SetFloat("speed", 1f);

            TurnLeft ();
        }
            
        if (moveRight && Intraction) {
            Vector2 temp = transform.position;
            temp.x += moveSpeed * Time.deltaTime;
            transform.position = temp; 

            anim.SetFloat("speed", 1f);

            TurnRight ();
        }

        if (!moveLeft && !moveRight) {
            anim.SetFloat("speed", 0f);
        }

        if (isGrounded)
            anim.SetBool("jump", false);

    }


    void MoveKeyboard () {
        
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput < 0 && Intraction && IntractionMoveLeft) {

            Vector2 temp = transform.position;
            temp.x -= moveSpeed * Time.deltaTime;
            transform.position = temp;

            TurnLeft ();
        }

        if (moveInput > 0 && Intraction) {
            
            Vector2 temp = transform.position;
            temp.x += moveSpeed * Time.deltaTime;
            transform.position = temp;

            TurnRight ();
        }

    }

    void TurnLeft () {
        if (left)
            return;
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        left = true;
        right = false;
    }

    void TurnRight () {
        if (right)
            return;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        left = false;
        right = true;
    }

    public void DefaultPlayerDirection () {
        if (left) {
            TurnRight ();
        }
    }

    public void RemoveIntraction () {
        Intraction = false;
    }

    public void EnableIntraction () {
        Intraction = true;
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "LeftCollider") {
            IntractionMoveLeft = false;
        }
    }

    void OnTriggerExit2D(Collider2D target) {
        if (target.tag == "LeftCollider") {
            IntractionMoveLeft = true;
        }
    }

    private void OnCollisionStay2D(Collision2D target) 
    {
        if (target.gameObject.tag == "Air Platform")
        {
            onPlatform = true;
        }    

    }

    private void OnCollisionExit2D(Collision2D target) 
    {
        if (target.gameObject.tag == "Air Platform")
        {
            StartCoroutine (FalseOnPlatformVariable (1.5f));
        }  
    }

    IEnumerator FalseOnPlatformVariable (float waitTime)
    {
        yield return new WaitForSeconds (waitTime);

        onPlatform = false;
    }

}
