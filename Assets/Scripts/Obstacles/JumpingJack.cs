using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingJack : MonoBehaviour {
    
    private GameObject Player;
    private PlayerController playerController;
    private Rigidbody2D playerRigidbody;

    private EdgeCollider2D collider;
    private Animator anim;

    public float JumpForce = 7f;

    void Awake () {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerController = Player.GetComponent<PlayerController>();
        playerRigidbody = Player.GetComponent<Rigidbody2D>();
        collider = GetComponent<EdgeCollider2D>();
        anim = GetComponent<Animator>();
    }

    void OnCollisionStay2D(Collision2D target) {
        if (target.gameObject.tag == "Player" && playerController.isGrounded) {
            anim.SetBool("bounce", true);
            playerJump ();
        }

        if (target.gameObject.tag == "SingleEyeAlien") {
            collider.enabled = false;
            Invoke("EnableCollider", 0.3f);
        }
    }

    void EnableCollider () {
        collider.enabled = true;
    }

    void playerJump () {
        playerController.isGrounded = false;
        playerRigidbody.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
    }

    public void StopBounceAnim () {
        anim.SetBool("bounce", false);
    }
    
}
