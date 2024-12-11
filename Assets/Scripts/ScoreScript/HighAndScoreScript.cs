using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighAndScoreScript : MonoBehaviour {
    
    private Text scoretxt;
    private Text highScoretxt;

    private int score;
    private int scoreVal;

    private int highScore;
    private int highScoreVal;
    private bool newHighScore;
    
    void Awake () {
        scoretxt = gameObject.transform.GetChild (0).gameObject.GetComponent<Text> ();
        highScoretxt = gameObject.transform.GetChild (1).gameObject.GetComponent<Text> ();
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>().score;
    }

    void Start () {
        SaveHighScore ();
    }

    void Update () {

        if (scoreVal < score) {
            scoreVal += 5;
            scoretxt.text = "Your Score : " + scoreVal.ToString();
        }

        if (highScoreVal < highScore) {

            highScoreVal += 5;

            if (newHighScore)
                highScoretxt.text = "New High Score : " + highScoreVal.ToString();
            else
                highScoretxt.text = "High Score : " + highScoreVal.ToString();
        }

    }

    void SaveHighScore () {
        int pastHighScore = PlayerPrefs.GetInt("highScore");

        if (pastHighScore < score) {
            PlayerPrefs.SetInt("highScore", score);
            highScore = score;
            newHighScore = true;
        }

        else {
            highScore = pastHighScore;
        }
            
    }

}
