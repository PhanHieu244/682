using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
    
    private Animator anim;
    private Text scoreUI;

    [HideInInspector]
    public int score;
    
    private float timeToHide;
    public float startTimeToHide;
    private bool hide;

    void Awake () {
        anim = GetComponent<Animator>();
        scoreUI = GetComponent<Text>();
        timeToHide = startTimeToHide;
    }

    void Start () {
        UpdateScore (0);
    }

    void FixedUpdate () {
        timeToHide -= Time.deltaTime;

        if (timeToHide <= 0 && hide) {
            anim.SetBool("hide", true);
            hide = false;
        }
    }

    public void UpdateScore (int val) {

        timeToHide = startTimeToHide;
        hide = true;

        score += val;
        scoreUI.text = "Score : " + score.ToString ();

        if (scoreUI.color.a < 200) {
            anim.SetBool("hide", false);
        }

    } 
    
}
