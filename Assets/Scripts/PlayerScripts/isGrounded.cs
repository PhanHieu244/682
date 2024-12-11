using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGrounded : MonoBehaviour {

    GameObject Player;

    void Awake () {
        Player = gameObject.transform.parent.gameObject;
    }

    void OnTriggerStay2D (Collider2D target) {
         if (target.tag == "Platform" || target.tag == "Air Platform") {
            Player.GetComponent<PlayerController>().isGrounded = true;
        }
    }

    
    void OnTriggerExit2D(Collider2D target) {
        if (target.tag == "Platform" || target.tag == "Air Platform") {
            Player.GetComponent<PlayerController>().isGrounded = false;
        }
    }

}
