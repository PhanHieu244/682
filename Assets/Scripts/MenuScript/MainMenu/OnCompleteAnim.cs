using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCompleteAnim : MonoBehaviour {

    private MainMenuScript mainMenuScript; 

    [HideInInspector]
    public int FunctionIndex;

    void Awake () {
        mainMenuScript = GameObject.FindGameObjectWithTag("MainMenuManager").GetComponent<MainMenuScript>();
    }
    
    public void OnComplteAnimation () {

        if (FunctionIndex == 1) {
            mainMenuScript.CloseSettingsUI();
        }

        if (FunctionIndex == 5) {
            mainMenuScript.CloseResetDataPanel();
        }

        if (FunctionIndex == 8) {
            mainMenuScript.CloseCreditUI();
        }
    }
    
}
