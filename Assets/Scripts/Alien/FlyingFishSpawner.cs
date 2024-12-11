using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingFishSpawner : MonoBehaviour
{
    public GameObject FlyingFishPrefab;

    private Transform Player;
    
    public float playerMinPosX, playerMaxPosX, timeBtwSpawnFish = 2f;
    private float timeTakenToSpawnFish;


    void Awake ()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timeTakenToSpawnFish = timeBtwSpawnFish;
    }


    void FixedUpdate ()
    {
        if (Player.transform.position.x > playerMinPosX && Player.transform.position.x < playerMaxPosX)
        {
            timeTakenToSpawnFish -= Time.deltaTime;

            if (timeTakenToSpawnFish < 0)
            {
                SpawnFish ();
                timeTakenToSpawnFish = timeBtwSpawnFish;
            }
        }
    }


    void SpawnFish ()
    {
        float randomPosX = Random.Range(Player.transform.position.x + 2.5f, Player.transform.position.x + 15f);
        var position = new Vector3(randomPosX, -6f, 0);

        Instantiate(FlyingFishPrefab, position, Quaternion.identity);
    }

}
