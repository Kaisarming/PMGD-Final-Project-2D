using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICars : MonoBehaviour
{
    public float accelelator;
    public float turnPower = 1;
    public float turnSpeed = 4;
    Rigidbody2D rb;
    // internal is like public. But internal types are only visible within the assembly they are defined in. public types are visible outside that assembly.
    internal bool isAIMovement;
    private float friction = 1.5f;
    private float currentSpeed;
    private Vector2 curSpeed;
    float currentAcc;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentAcc = accelelator;
    }

    void FixedUpdate()
    {
        // If the car is moving
        if (isMoving)
        {
            // Get the rigidbody and push the car upwards
            rb.AddForce(transform.up * currentAcc);
        }

        if (!isMoving)
        {
            // If not moving, the car will slide a little bit
            rb.drag = friction * 2;
        }
    }

    public void Movement(string turning, bool isPeddlePressed)
    {
        // if rotate to the left, it still can go forward
        if (turning == "left")
        {
            transform.Rotate(Vector3.forward * (currentSpeed + currentSpeed));
        }    
        else if (turning == "right")
        {
            // Minus because we're going the opposite direction
            transform.Rotate(Vector3.forward * -(currentSpeed + currentSpeed));
        }
            

        if (isPeddlePressed)
        {
            isMoving = true;
        }

        currentSpeed = curSpeed.magnitude / turnSpeed;
        curSpeed = new Vector2(rb.velocity.x, rb.velocity.y);
    }
        
}
