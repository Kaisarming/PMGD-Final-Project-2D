using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAI : MonoBehaviour
{
public float speed = 5f;
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    public float rotationSpeed = 5f;
    public float waypointRadius = 1f;
    private Vector2 direction;

    private void Update()
    {
        MoveToWaypoint();
        direction = (waypoints[currentWaypointIndex].position - transform.position).normalized;
    }

    private void MoveToWaypoint()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            Transform targetWaypoint = waypoints[currentWaypointIndex];
            transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);
            float angle = Vector2.SignedAngle(transform.right, direction);
            transform.Rotate(0f, 0f, angle * rotationSpeed * Time.deltaTime);
            if (transform.position == targetWaypoint.position)
            {
                currentWaypointIndex++;
            }
        }
        else
        {
            currentWaypointIndex = 0;
        }
    } 
} 
