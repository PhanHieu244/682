using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelcomplete : MonoBehaviour {
    
    public GameObject VictoryUI;
    public GameObject scoreHighUI;
    public GameObject ControlUI;

    private bool won;

    void LevelWon () {
        VictoryUI.SetActive (true);
        scoreHighUI.SetActive(true);
        ControlUI.SetActive(false);

        int level = PlayerPrefs.GetInt("level");

        if (level == 0)
            level = 1;

        if (level <= 12) 
        {
            level += 1;
            PlayerPrefs.SetInt("level", level);
        }
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "PlayerCar" && !won) {
            Destroy(target.gameObject);
            LevelWon ();
            won = true;
        }
    }
    
}
