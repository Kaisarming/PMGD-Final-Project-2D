using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolling : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    public int index = 0;

    private bool isTurning = false;
    private Vector3 targetRotation;

    void Update()
    {
        if (!isTurning)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[index].position, speed * Time.deltaTime);

            if (transform.position == waypoints[index].position)
            {
                index = (index + 1) % waypoints.Length;
                isTurning = true;
                targetRotation = transform.eulerAngles + new Vector3(0, 0, -90);
            }
        }
        else
        {
            float rotationSpeed = 90.0f / speed;
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetRotation, rotationSpeed * Time.deltaTime);
            if (Mathf.Abs(transform.eulerAngles.z - targetRotation.z) < 0.01f)
            {
                transform.eulerAngles = targetRotation;
                isTurning = false;
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            targetRotation = transform.eulerAngles + new Vector3(0, 0, -90);
            isTurning = false;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
    }
}

