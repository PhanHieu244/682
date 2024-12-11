using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {
    
    public GameObject Player;

    public GameObject HeartsUI;
    public GameObject PauseButtonUI;
    public GameObject ControlsUI;
    public GameObject ScoreUI;
    public GameObject LevelTextUI;
    public GameObject BossHealthbarUI;

    private MoveOneDirection carMoveScript;
    private RotateLoop backTierScript;
    private RotateLoop frontTierScript;

    public bool isBoss;

    void Awake () {
        carMoveScript = GetComponent<MoveOneDirection>();
        backTierScript = gameObject.transform.GetChild (1).gameObject.GetComponent<RotateLoop>();
        frontTierScript = gameObject.transform.GetChild (2).gameObject.GetComponent<RotateLoop>();
    }    

    public void HideAppearUIAndPlayer (bool trueOrFalse) {
        Player.SetActive(trueOrFalse);
        HeartsUI.SetActive(trueOrFalse);
        PauseButtonUI.SetActive(trueOrFalse);
        ControlsUI.SetActive(trueOrFalse);
        LevelTextUI.SetActive (trueOrFalse);

        if (isBoss)
            BossHealthbarUI.SetActive (trueOrFalse);
    }

    public void HideScoreUI (bool trueOrFalse) {
        // ScoreUI.SetActive(trueOrFalse);
    }

    public void MoveAndStopCar (bool trueOrFalse) {
        carMoveScript.move = trueOrFalse;
        backTierScript.rotate = trueOrFalse;
        frontTierScript.rotate = trueOrFalse;
    }
    
}
