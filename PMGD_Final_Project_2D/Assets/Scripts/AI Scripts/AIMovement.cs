using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    // Lots of game object
    List<GameObject> route;
    private Vector3 nextPoint;
    public GameObject aiPathHolder;
    private bool isAccPressed = false;
    AICars driver;
    int totalWaypoints;
    int currentIndex;
    private bool nextPos;
    private string turning;
    AIPathway waypoint;
    internal Transform currentWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        driver = GetComponent<AICars>();

        if (aiPathHolder != null)
        {
            driver.isAIMovement = true;
            waypoint = aiPathHolder.GetComponent<AIPathway>();
            route = waypoint.route;
            currentIndex = 0;
            totalWaypoints = route.Count;
            currentWaypoint = route[0].transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!driver.isAIMovement)
        {
            
        }

        if (!nextPos)
        {
            nextPoint = currentWaypoint.position;
            nextPos = true;
        }

        Vector3 relativeVector = transform.InverseTransformPoint(nextPoint);
        turning = null;

        // if we go to the right
        if (relativeVector.x > 0.5f)
        {
            turning = "right";
        }
        // else if, we go left(because -x is left)
        else if (relativeVector.x < -0.5f)
        {
            turning = "left";
        }

        // Get the distance to the next route
        float dist = Vector2.Distance(transform.position, nextPoint);
        isAccPressed = true;

        if (dist < 2)
        {
            currentIndex++;

            if (currentIndex >= totalWaypoints)
            {
                currentIndex = 0;
            }

            currentWaypoint = route[currentIndex].transform;
            nextPos = false;
        }
    }

    private void FixedUpdate()
    {
        if (driver.isAIMovement)
        {
            driver.Movement(turning, isAccPressed);
        }
    }
}
