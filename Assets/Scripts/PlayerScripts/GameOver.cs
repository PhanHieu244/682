using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameObject ControlsUI;
    public GameObject PauseButtonUI;
    public GameObject GameOverUI;
    public GameObject scoreHighUI;
    public GameObject BossHealthbarUI;

    private PlayerController controller;

    public bool isBoss;

    void Awake () {
        controller = GetComponent<PlayerController>();
    }

    public void gameOver () {
        controller.RemoveIntraction ();
        ControlsUI.SetActive (false);
        PauseButtonUI.SetActive (false);
        GameOverUI.SetActive (true);
        scoreHighUI.SetActive(true);

        if (isBoss)
            BossHealthbarUI.SetActive (false);
    }
    
}
