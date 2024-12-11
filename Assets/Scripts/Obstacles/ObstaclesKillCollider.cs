using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesKillCollider : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Star" || target.tag == "PlayerBulletYellow"
            || target.tag == "PlayerBulletRed" || target.tag == "PlayerCar" || target.tag == "ShieldAlienBullet" || target.tag == "Boss1 Bullet" || target.tag == "Tope Bullet")
        {
            Destroy(target.gameObject);
        } 
    }
    
}
