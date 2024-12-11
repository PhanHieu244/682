using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreScript : MonoBehaviour {

    private ScoreScript scoreScript;

    private AudioSource StarCollectSfx;

    public int starScore;

    void Awake () {
        scoreScript = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript> ();
        StarCollectSfx = GameObject.FindGameObjectWithTag ("AudioSources").transform.GetChild(5).GetComponent<AudioSource>();
    }
    
    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Star") {

            // SFX
            if (PlayerPrefs.GetInt("sound") == 0)
                StarCollectSfx.Play ();

            scoreScript.UpdateScore (starScore);
        }
    }
    
}
