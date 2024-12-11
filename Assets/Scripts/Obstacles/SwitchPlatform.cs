using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlatform : MonoBehaviour
{

    private Health PlayerHealthScript;

    public GameObject BlueSwitch, RedPlatform, BluePlatform;

    private SpriteRenderer RedSwitch;

    private AudioSource SwitchSfx;

    private bool playSfxOnce;


    void Awake ()
    {
        PlayerHealthScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();

        BluePlatform.SetActive (false);

        RedSwitch = GetComponent<SpriteRenderer>();

        SwitchSfx = GameObject.FindGameObjectWithTag ("AudioSources").transform.GetChild(10).GetComponent<AudioSource>();
    }


    void Update ()
    {
        if (PlayerHealthScript.die)
        {
            RedSwitch.enabled = true;
            RedPlatform.SetActive(true);
            playSfxOnce = false;
        }
    }


    void OnTriggerEnter2D(Collider2D target) 
    {
        if (target.tag == "Player")
        {
            // SFX
            if (PlayerPrefs.GetInt("Sound") == 0 && !playSfxOnce)
            {
                SwitchSfx.Play ();
                playSfxOnce = true;
            }

            BlueSwitch.SetActive (true);

            BluePlatform.SetActive(true);
            RedPlatform.SetActive(false);

            RedSwitch.enabled = false;
        }
    }

    
}  // Class
