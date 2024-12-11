using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointText : MonoBehaviour {

    private Animator anim;

    private AudioSource checkpointSfx;

    void Awake () {
        anim = GetComponent<Animator>();
        checkpointSfx = GameObject.FindGameObjectWithTag ("AudioSources").transform.GetChild(7).GetComponent<AudioSource>();
    }
    
    public void ShowCheckpointText (float posX) {

        // SFX
        if (PlayerPrefs.GetInt("sound") == 0)
            checkpointSfx.Play ();

        Vector2 temp = transform.position;
        temp.x = posX;
        transform.position = temp;
        
        anim.SetBool("zoom", true);
    }

    public void HideCheckpointText () {
        anim.SetBool("zoom", false);
    }
}
