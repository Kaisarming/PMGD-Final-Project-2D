using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSpeed : MonoBehaviour
{
    public GameObject powerUp;
    private MainCar mainCar;
    private SpeedoMeter speedoMeter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            powerUp.SetActive(false);
            mainCar = GameObject.FindObjectOfType<MainCar>();
            speedoMeter = GameObject.FindObjectOfType<SpeedoMeter>();
            mainCar.forward += 10;
            speedoMeter.maxSpeedAngle = -100f;
        }
    }
}
