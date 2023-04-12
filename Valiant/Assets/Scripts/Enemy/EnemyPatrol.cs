using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 2f;

    private int currentWaypointIndex = 0;
    private Transform currentWaypoint;

    void Start()
    {
        currentWaypoint = waypoints[currentWaypointIndex];
    }

    void Update()
    {
        // Jika sudah mencapai waypoint, pindah ke waypoint selanjutnya
        if (transform.position == currentWaypoint.position)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            currentWaypoint = waypoints[currentWaypointIndex];
        }

        // Bergerak ke arah waypoint saat ini
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);

        // Putar enemy ke arah waypoint saat ini
        transform.LookAt(currentWaypoint);
    }
}
