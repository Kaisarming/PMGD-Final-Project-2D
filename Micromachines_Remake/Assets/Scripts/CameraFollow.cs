using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Get the car transform (I have to attach the game object later to the script in Unity)
    public Transform car;

    // Update is called once per frame
    void Update()
    {
        //Transform the position of the main camera x and y as the same position of the car while z make it equal to -10f because if I make it =0f, the car cannot be seen
        transform.position = new Vector3(car.position.x, car.position.y, -10f);
    }
}
