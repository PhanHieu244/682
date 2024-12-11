using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayMenu : MonoBehaviour {
    
    public GameObject GamePauseUI;
    public GameObject ControlsUI;
    public GameObject PauseButtonUI;
    public GameObject Hearts;
    public GameObject BossHealthbarUI;

    private GameObject GamePlayMusic;

    private PlayerController playerController;

    private Admob AdmobScript;

    private Fade fade;
    private int loadScene;

    public bool isBoss;
    private bool hideControlUI;
    private bool rewardedAdShown;


    void Awake () {
        fade = GameObject.FindGameObjectWithTag("Fade").GetComponent<Fade>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        GamePlayMusic = GameObject.FindGameObjectWithTag ("AudioSources").transform.GetChild(0).gameObject;
        AdmobScript = GameObject.FindGameObjectWithTag ("Admob").GetComponent<Admob>();

        if (PlayerPrefs.GetInt ("music") == 0)
            GamePlayMusic.SetActive(true);
        else 
            GamePlayMusic.SetActive(false);
    }


    public void PauseAndResumeGame () {

        if (GamePauseUI.activeSelf) {
            Time.timeScale = 1f;
            GamePauseUI.SetActive(false);
            ControlsUI.SetActive(true);
            PauseButtonUI.SetActive(true);
            Hearts.SetActive(true);
            
            if (isBoss)
                BossHealthbarUI.SetActive (true);
        }
        
        else {
            Time.timeScale = 0f;
            GamePauseUI.SetActive(true);
            ControlsUI.SetActive(false);
            PauseButtonUI.SetActive(false);
            Hearts.SetActive(false);

            playerController.moveLeft = false;
            playerController.moveRight = false;

            if (isBoss)
                BossHealthbarUI.SetActive (false);
        }

    }

    
    void Update () 
    {
        if (hideControlUI)
            ControlsUI.SetActive (false);

        if (rewardedAdShown)
        {
            hideControlUI = true;
            Time.timeScale = 1f;
            fade.PlayFadeOutAndLoadScene (loadScene);  // Play Fade Out Animation

            rewardedAdShown = false;
        }

    }


    public void LoadScene (int sceneIndex) {

        // WHEN SCENE INDEX IS NOT MAIN MENU
        if (sceneIndex != 0)
        {
            //AdmobScript.ShowRewardedAd ();
            loadScene = sceneIndex;
            rewardedAdShown = true;
        }

        else 
        {
            hideControlUI = true;
            Time.timeScale = 1f;
            fade.PlayFadeOutAndLoadScene (sceneIndex);  // Play Fade Out Animation
        }

    }


    public void OpenMainMenu ()
    {
        Time.timeScale = 1f;
        fade.PlayFadeOutAndLoadScene (0);
    }

    
}  // Class
 