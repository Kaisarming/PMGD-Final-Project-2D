using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    private Vector3 angle;
    public float wheelAngle, maxWheelAngle = 30f;

    // Update is called once per frame
    void Update()
    {
        // We're using this script to flip the wheel by using minus(-)
        wheelAngle = -Input.GetAxis("Horizontal") * maxWheelAngle;
    }

    // Late update is called when all ipdate function has been called
    private void LateUpdate()
    {
        // This code is to make the wheel turn left and right
        // localEulerAngle represend 3 dimensional rotation around an individual axis.
        angle = transform.localEulerAngles;
        angle.z = wheelAngle;
        transform.localEulerAngles = angle;
    }
}
