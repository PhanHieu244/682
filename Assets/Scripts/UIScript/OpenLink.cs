using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{    

    // https://www.zapsplat.com/
    // https://soundimage.org/
    // https://freesound.org/

    public void OpenUrl (string Url)
    {
        Application.OpenURL(Url);
    }

}
