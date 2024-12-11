using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {
    
    public GameObject SettingsUI;
    public GameObject popupPanel;
    public GameObject resetDataPanel;
    public GameObject MainMenuUI;
    public GameObject LevelSelectUI;
    public GameObject CreditUI;

    public GameObject SettingButton;
    public GameObject CreditButton;

    public Text MusicOnOrOffTxt;
    public Text SoundOnOrOffTxt;

    private OnCompleteAnim popupPanelScript;
    private OnCompleteAnim resetDataPanelScript;
    public OnCompleteAnim CreditUIPanelScript;

    private Animator popupPanelAnim;
    private Animator resetDataPanelAnim;
    public Animator CreditUIPanelAnim;

    private Fade fade;

    public GameObject [] levelButtons;
    public Sprite LevelButtonImage;
    public Sprite LockButtonImage;
    private GameObject LevelButtonText;

    public GameObject MainMenuMusic;
    public GameObject ResetDataMessage;

    void Awake () {
        popupPanelScript = popupPanel.GetComponent<OnCompleteAnim>();
        resetDataPanelScript = resetDataPanel.GetComponent<OnCompleteAnim>();
        popupPanelAnim = popupPanel.GetComponent<Animator>();
        resetDataPanelAnim = resetDataPanel.GetComponent<Animator>();
        fade = GameObject.FindGameObjectWithTag("Fade").GetComponent<Fade>();

        // REMOVE THIS LINE
        // PlayerPrefs.SetInt ("level", 12);

        // MUSIC = 0 MEANS TRUE, 1 MEANS FALSE
        // SOUND = 0 MEANS TRUE, 1 MEANS FALSE

        // MAIN MENU MUSIC
        if (PlayerPrefs.GetInt ("music") == 0)
        {
            MusicOnOrOffTxt.text = "ON";
            MainMenuMusic.SetActive (true);
        } 
        
        else 
        {
            MusicOnOrOffTxt.text = "OFF";
            MainMenuMusic.SetActive (false);
        }


        // SOUND
        if (PlayerPrefs.GetInt("sound") == 0)
            SoundOnOrOffTxt.text = "ON";
        else 
            SoundOnOrOffTxt.text = "OFF";

    }

    void Start ()
    {
        int level = PlayerPrefs.GetInt("level");

        if (level == 0)
            level = 1;

        for (int i = 0; i < level; i++)
        {
            levelButtons[i].GetComponent<Button>().interactable = true;

            // IF LEVEL BUTTON IS NOT EQUAL TO BOSS BUTTON 
            if (i != 5 && i != 11) {
                levelButtons[i].GetComponent<Image>().sprite = LevelButtonImage;
                levelButtons[i].transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(255,255,255,255);
            }
        }
    }

    void ResetLevelSelect ()
    {
        for (int i = 1; i < 12; i++)
        {
            // IF LEVEL BUTTON IS NOT EQUAL TO BOSS BUTTON 
            if (i != 5 && i != 11) {
                levelButtons[i].GetComponent<Image>().sprite = LockButtonImage;
            }
            
            levelButtons[i].transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(255,255,255,0);
            levelButtons[i].GetComponent<Button>().interactable = false;
        }
    }

    public void OpenSettingsUI () {  // Index 0
        if (!SettingsUI.activeSelf)
        {
            CreditButton.SetActive (false);
            SettingsUI.SetActive(true);
        }
    }

    public void CloseSettingsUI () {  // Index 01
        SettingsUI.SetActive(false); 
        CreditButton.SetActive (true);
    }

    public void SetMusic () {  // Index 02
        switch (MusicOnOrOffTxt.text) {
            case "ON":
                MusicOnOrOffTxt.text = "OFF";
                PlayerPrefs.SetInt ("music", 1);
                MainMenuMusic.SetActive (false);
                break;

            case "OFF":
                MusicOnOrOffTxt.text = "ON";
                PlayerPrefs.SetInt ("music", 0);
                MainMenuMusic.SetActive (true);
                break;
        }
    }

    public void SetSound () {   // Index 03
        switch (SoundOnOrOffTxt.text) {
            case "ON":
                SoundOnOrOffTxt.text = "OFF";
                PlayerPrefs.SetInt ("sound", 1);
                break;

            case "OFF":
                SoundOnOrOffTxt.text = "ON";
                PlayerPrefs.SetInt ("sound", 0);
                break;
        }
    }

    public void OpenResetDataPanel () { // Index 04
        if (!resetDataPanel.activeSelf) {
            resetDataPanel.SetActive(true);
        }
    }

    public void CloseResetDataPanel () { // Index 05
        resetDataPanel.SetActive(false);
    }

    public void PlayResetDataCloseAnim () {  // Index 06
        resetDataPanelScript.FunctionIndex = 5;
        resetDataPanelAnim.SetBool("close", true);
    }

    public void OpenCreditUI () {  // Index 7
        if (!CreditUI.activeSelf)
        {   
            SettingButton.SetActive (false);
            CreditUI.SetActive(true);
        }
            
    }

    public void CloseCreditUI () {  // Index 08
        CreditUI.SetActive(false); 
        SettingButton.SetActive (true);
    }

    public void PlayCreditUICloseAnim () { 
        CreditUIPanelScript.FunctionIndex = 8;
        CreditUIPanelAnim.SetBool("popdown", true);
    }

    public void ResetData () {
        PlayerPrefs.SetInt ("level", 1);
        PlayerPrefs.SetInt ("music", 0);
        PlayerPrefs.SetInt ("sound", 0);

        MusicOnOrOffTxt.text = "ON";
        SoundOnOrOffTxt.text = "ON";

        ResetLevelSelect ();

        ResetDataMessage.SetActive (true);
    }

    public void PlayPopDownAnim (int functionIndex) {
        popupPanelScript.FunctionIndex = functionIndex;
        popupPanelAnim.SetBool("popdown", true);
    }
    
    public void StartGame () {
        MainMenuUI.SetActive (false);
        LevelSelectUI.SetActive (true);
    }

    public void Exitgame ()
    {
        Application.Quit();
    }

    public void LoadScene (int sceneIndex) {
        fade.PlayFadeOutAndLoadScene (sceneIndex);  // Play Fade Out Animation
    }

}
