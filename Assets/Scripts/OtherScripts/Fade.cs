using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour {
    
    private Animator anim;

    private int loadScene;

    void Awake () {
        anim = GetComponent<Animator>();
    }

    public void playFadeIn () {
        anim.SetBool("fadeIn", true);
    }

    public void PlayFadeOutAndLoadScene (int sceneIndex) {
        loadScene = sceneIndex;
        anim.SetBool("fadeOut", true);
    }
    
    public void FadeInfalse () {
        anim.SetBool("fadeIn", false);
    }

    public void FadeOutfalse () {
        anim.SetBool("fadeOut", false);
    }

    public void OnFadeOutComplete () {
        SceneManager.LoadScene (loadScene);
    }
}
