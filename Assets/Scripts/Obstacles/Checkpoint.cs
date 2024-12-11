using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    
    private Animator anim;
    private BoxCollider2D collider;

    private CheckpointText checkpointText;

    private bool checkpointSaved;

    void Awake () {
        anim = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
        checkpointText = GameObject.FindGameObjectWithTag("CheckpointText").GetComponent<CheckpointText>();
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Player" && !checkpointSaved) {
            checkPoint ();
            checkpointSaved = true;
        }
    }

    void checkPoint () {
        checkpointText.ShowCheckpointText (transform.position.x);
        
        collider.enabled = false;
        anim.Play("move");
    }

}
