using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarExit : MonoBehaviour {    

    private Car car;

    private bool move;

    void Awake () {
        car = GetComponent<Car>();
    }

    void Start () {
        car.MoveAndStopCar(false);
    }

    void Update () {
        if (move) {
            car.HideAppearUIAndPlayer(false);
            car.MoveAndStopCar(true);
            move = false;
        }
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Player" && !move) {
            move = true;
        }
    }

}
