using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCurrentSwitch : MonoBehaviour
{

    public int numOfCurrentPaulsToDestroy;

    public GameObject[] CurrentPauls;

    private AudioSource RemoveCurrentSwitchSfx;


    void Awake ()
    {
        RemoveCurrentSwitchSfx = GameObject.FindGameObjectWithTag("AudioSources").transform.GetChild(10).gameObject.GetComponent<AudioSource>();
    }


    void OnTriggerEnter2D(Collider2D target) 
    {
        if (target.tag == "Player") 
        {
            if (PlayerPrefs.GetInt("Sound") == 0)
                RemoveCurrentSwitchSfx.Play();

            gameObject.SetActive(false);
            DestroyCurrentPaul ();
        }
    }

    void DestroyCurrentPaul () 
    {
        for (int i = 0; i < numOfCurrentPaulsToDestroy; i++) 
        {
            Destroy (CurrentPauls[i]);
        }
    }    
    
}  // Class
