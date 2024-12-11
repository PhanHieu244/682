using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEntry : MonoBehaviour{

    private Car car;

    public float TravelPosX;

    private bool move;

    void Awake () {
        car = GetComponent<Car>();
        move = true;
    }

    void Start () {
        car.HideScoreUI(false);
        car.HideAppearUIAndPlayer(false);
        car.MoveAndStopCar(true);
    }

    void Update () {
        if (transform.position.x >= TravelPosX && move) {
            car.HideScoreUI(true);
            car.HideAppearUIAndPlayer(true);
            car.MoveAndStopCar(false);
            move = false;
        }
    }
    
}
