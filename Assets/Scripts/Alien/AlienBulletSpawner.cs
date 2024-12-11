using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBulletSpawner : MonoBehaviour {

    public Transform BulletSpawner;
    public GameObject Bullet;

    public int bullets;

    private int SpawnedBullet = 0;

    void Start () {
        InvokeRepeating ("SpawnBullet", 0.1f, 0.5f);
    }

    void SpawnBullet () {
        if (SpawnedBullet < bullets) {

            Instantiate(Bullet, BulletSpawner.position, Quaternion.identity);
            SpawnedBullet++;
        }
    }

}
