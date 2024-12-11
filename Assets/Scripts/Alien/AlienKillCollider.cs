using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienKillCollider : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "AirShooterAlien" || target.tag == "AlienBullet"
            || target.tag == "FourSpikesAlien" || target.tag == "SingleEyeAlien"
            || target.tag == "SpikesAlien" || target.tag == "Mad Runner Alien" || target.tag == "Small Alien" || target.tag == "Ghost Alien" || target.tag == "Bomb Alien" || target.tag == "Circle Spikes Alien")
        {
            Destroy(target.gameObject);
        } 
    }
    
}
