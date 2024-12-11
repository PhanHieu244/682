using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour {
    
    private Transform mainCamera;

    public float numOfImages;
    public float gapBtwPosX;
    private float currentPosX;

    void Awake () {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    void Update () {

        currentPosX = transform.position.x;

        if (mainCamera.transform.position.x - (gapBtwPosX + 4f) > currentPosX) {
            Vector2 temp = transform.position;
            temp.x += gapBtwPosX * numOfImages;
            transform.position = temp;
        }

        float totalPosx = gapBtwPosX * (numOfImages -1);
        if (mainCamera.transform.position.x < currentPosX - (totalPosx - 4f) ) {
            Vector2 temp = transform.position;
            temp.x -= gapBtwPosX * numOfImages;
            transform.position = temp;
        }
    }

}
