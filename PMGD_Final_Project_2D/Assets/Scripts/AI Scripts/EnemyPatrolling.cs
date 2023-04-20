using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolling : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    public float rotationSpeed = 2f;
    public float waypointRadius = 1f;

    private int currentWaypoint = 0;

    private void Update()
    {
        // Calculate the distance to the current waypoint
        float distanceToWaypoint = Vector2.Distance(transform.position, waypoints[currentWaypoint].position);

        // If the car has reached the current waypoint, move to the next one
        if (distanceToWaypoint < waypointRadius)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }

        // Calculate the direction to the current waypoint
        Vector2 direction = waypoints[currentWaypoint].position - transform.position;

        // Rotate the car to face the direction of the waypoint
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Move the car towards the current waypoint
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
    }
}

