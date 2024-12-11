using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnceMovablePlatform : MonoBehaviour
{

    private GameObject SetPlayerChildren, SetPlayerParent;
    private Health PlayerHealthScript;

    public float moveSpeed = 3f, distance = 6;
    private float totalDistance, defaultPosX;
    private bool move;


    void Awake ()
    {
        SetPlayerChildren = gameObject.transform.GetChild(1).gameObject;
        SetPlayerParent = GameObject.FindGameObjectWithTag("SetPlayerParent");
        PlayerHealthScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();

        totalDistance = transform.position.x + distance;
        defaultPosX = transform.position.x;
    }


    void Update ()
    {
        if (move && transform.position.x < totalDistance)
        {
            Vector2 temp = transform.position;
            temp.x += moveSpeed * Time.deltaTime;
            transform.position = temp;
        }


        if (PlayerHealthScript.die)
        {
            Vector2 temp = transform.position;
            temp.x = defaultPosX;
            transform.position = temp;

            move = false;

            gameObject.SetActive (false);
        }

    }


    void OnTriggerStay2D(Collider2D target) 
    {
        if (target.tag == "Player" && !move)
            move = true;  

        else if (target.tag == "Player")
            GameObject.FindGameObjectWithTag("Player").transform.SetParent(SetPlayerChildren.transform.parent);
    }


    void OnTriggerExit2D(Collider2D target) 
    {
        if (target.tag == "Player")
            GameObject.FindGameObjectWithTag("Player").transform.SetParent(SetPlayerParent.transform.parent);
    }


}  // Class
