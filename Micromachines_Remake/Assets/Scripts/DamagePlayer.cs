using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        // When there is a collision with an object that has the tag "Player"
        if (other.gameObject.tag == "Player")
        {
            // Activate "DamagePlayer()" function from "HealthManager" scripts
            HealthManager.instance.DamagePlayer();
        }
    }
}
