using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{

    public GameObject Bomb;
    public Transform Bomb_Spawner;

    public float timeTakeToSpawn = 1.6f;

    void Start ()
    {
        InvokeRepeating ("SpawnBomb", 1f, Random.Range(timeTakeToSpawn, timeTakeToSpawn + 0.6f));
    }


    void SpawnBomb () {
        Instantiate(Bomb, Bomb_Spawner.position, Bomb_Spawner.rotation);
    }

}  // Class
