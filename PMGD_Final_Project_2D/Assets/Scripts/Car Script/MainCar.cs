using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Declares a class by name "MainCar" which extends "MonoBehaviour", this gives "MainCar" access to "MonoBehaviour" methods and 'behaviors'
public class MainCar : MonoBehaviour
{
    // Defines a public static variable called instance of type "MainCar", this variable can be accessed anywhere in the code just by calling "MainCar.instance"
    public static MainCar instance;
    public Rigidbody2D rb;
    public float turningForce = 0.4f, forward = 25f, reverse = 15f;
    private float turningAmount, speed, direction;

    // Smoke trail
    // The code below is an array, and it will ask some input in the "Tyre Smoke" in Unity, we can input as many as we like for how many particle system that we used
    public ParticleSystem[] tyreSmoke;
    public float maxSmoke = 25f;
    private float smokeRate;
    public float power;

    // Engine sound
    public float maxSpeed;
    public AudioSource engine;

    // Tyre skid sound
    public AudioSource skidSound;
    public float skidFadeSpeed;

    // Skid trail variables
    public GameObject leftTyre;
    public GameObject rightTyre;

    // Awake comes before start
    public void Awake()
    {
        // The Awake method (is called when the object it placed in the scene) it is checking if there is already an instance for "MainCar" in the variable "instance", if there isn't any then it assigns itself to "instance"
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        // Get rigidbody2d component
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Mathf.Abs will give us a positive number. Example if we turn to the left, it will become -1. But with mathf.Abs it will become positif number
        // When the speed of the car is more than 5f, smokeRate is equal to maxSmoke
        if (Mathf.Abs(power) > .5f)
        {
            smokeRate = maxSmoke;
        }

        // When the speed of the car drop to less than or equal to 5f, smoke rate will become 0
        if (rb.velocity.magnitude <= .5f)
        {
            smokeRate = 0;
        }

        // This for loop is used to loop the array tyreSmoke
        for (int i = 0; i < tyreSmoke.Length; i++)
        {
            // emissionModule is script interface for the EmissionModule of a Particle System. (Basically the is an object named Emission in the inspector of particle system
            var emissionModule = tyreSmoke[i].emission;

            // The is rateOverTime on the inspector of Emission
            emissionModule.rateOverTime = smokeRate;
        }

        if (engine != null)
        {
            //.pitch = the pitch of the audio source (in audio source in Unity can be edit)
            // When the car moves at max spedd, the car engine will have a volume increase
            engine.pitch = 1f + ((rb.velocity.magnitude / maxSpeed) * 2f);
        }

        if (skidSound != null)
        {
            // To make the TyreSkidLeft and TyreSkidRight gameobject give the effect of tyre skid
            StartSkid();
            // Mathf.Abs will give the input a positive value
            if (Mathf.Abs(turningAmount) > 0.99f)
            {
                // Volume can be adjusted in audio source in Unity and 1f is the biggest
                skidSound.volume = 1f;
            }
            else
            {
                // Move the volumee in audio source in Unity from 1f to 0f (decrease the volume)
                skidSound.volume = Mathf.MoveTowards(skidSound.volume, 0f, skidFadeSpeed * Time.deltaTime);
                // To make the TyreSkidLeft and TyreSkidRight gameobject stop the effect of tyre skid
                StopSkid();
            }
        }
    }

    // FixedUpdate used when we use physics
    private void FixedUpdate()
    {
        // This is to turn the object horizontal(left and right). I use minus because to make it can turn to left or right
        turningAmount = -Input.GetAxis("Horizontal");
        // Assign speed value to 0
        speed = 0f;

        // If Accelelator(Accelerator is "w" key in my computer. I use "edit > project settings > input manager" to edit the name to Accelerator) is more than 0
        if (Input.GetAxis("Accelerator") > 0)
        {
            // Speed is equal to Accelelator * 25f(forward)
            speed = Input.GetAxis("Accelerator") * forward;
        }
        // Else if Reverse("s" key in my computer") is less than 0
        else if (Input.GetAxis("Reverse") < 0)
        {
            // Speed is equal to Reverse * 15f(reverse)
            speed = Input.GetAxis("Reverse") * reverse;
        }

        // "Mathf.Sign" return value is 1 when f is positive or zero, -1 when f is negative.
        // Vectors Dot returns 1 if they point in exactly the same direction; -1 if they point in completely opposite directions; and a number in between for other cases (e.g. Dot returns zero if vectors are perpendicular). Structure:"public static float Dot(Vector2 lhs, Vector2 rhs);"
        // Get relative vector and push the car "up"
        direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
        // The line below is used to get the rotation
        // rb.velocity.magnitute returns the length of this vector
        rb.rotation += turningAmount * turningForce * rb.velocity.magnitude * direction;
        // Add force to move the car upwards * speed
        rb.AddRelativeForce(Vector2.up * speed);
        // Add force and turn the car around
        rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * turningAmount / 2);
    }

    private void StartSkid()
    {
        // Make the tire skid
        leftTyre.GetComponent<TrailRenderer>().emitting = true;
        rightTyre.GetComponent<TrailRenderer>().emitting = true;
    }

    private void StopSkid()
    {
        // Stop the tire from skidding
        leftTyre.GetComponent<TrailRenderer>().emitting = false;
        rightTyre.GetComponent<TrailRenderer>().emitting = false;
    }
}
