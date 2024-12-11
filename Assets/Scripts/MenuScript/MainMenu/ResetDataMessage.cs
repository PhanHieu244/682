using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDataMessage : MonoBehaviour
{

    private Animator Animation;

    void Awake ()
    {
        Animation = GetComponent<Animator>();
    }

    public void PlayCloseAnim ()
    {
        Animation.Play ("close");
    }

    public void SetActiveFalse ()
    {
        gameObject.SetActive(false);
    }

}  // Class
