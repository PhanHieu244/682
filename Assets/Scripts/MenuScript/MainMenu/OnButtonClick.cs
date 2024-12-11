using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonClick : MonoBehaviour {

    private MainMenuScript mainMenuScript;
    
    private Animator anim;

    private int FuncIndex;

    void Awake () {
        mainMenuScript = GameObject.FindGameObjectWithTag("MainMenuManager").GetComponent<MainMenuScript>();
        anim = GetComponent<Animator>();
    }

    public void playPopDownAnim () {
        anim.SetBool("popdown", true);
    }

    public void playPopUpAnim (int functionIndex) {
        FuncIndex = functionIndex;
        anim.SetBool("popdown", false);
    }
    
    public void OnPopUpComplete () {

        anim.Play("idle");

        if (FuncIndex == 0) 
            mainMenuScript.OpenSettingsUI ();

        else if (FuncIndex == 1)
            mainMenuScript.CloseSettingsUI ();

        else if (FuncIndex == 2)
            mainMenuScript.SetMusic ();

        else if (FuncIndex == 3)
            mainMenuScript.SetSound ();

        else if (FuncIndex == 4)
            mainMenuScript.OpenResetDataPanel ();

        else if (FuncIndex == 6)
            mainMenuScript.PlayResetDataCloseAnim ();

        else if (FuncIndex == 7)
            mainMenuScript.OpenCreditUI ();

        else if (FuncIndex == 8)
            mainMenuScript.PlayCreditUICloseAnim ();

        else
            return;

    }

}
