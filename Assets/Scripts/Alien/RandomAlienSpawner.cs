using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAlienSpawner : MonoBehaviour
{

    public GameObject Alien;

    public float minPosY = -.5f, maxPosY = 2.5f, timeBtwSpawn = 3f;


    void Start ()
    {
        InvokeRepeating ("SpawnAlien", timeBtwSpawn, timeBtwSpawn * 2);
    }


    void SpawnAlien ()
    {
        float randomPositionY = NextFloat(minPosY, maxPosY);

        Instantiate (Alien, new Vector3(transform.position.x, randomPositionY, 0f) ,Quaternion.identity);
    }


    static float NextFloat(float min, float max){
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }

} // Class
