using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int currentLives = 3;
    public float respawnTime = 2f;

    private void Awake()
    {
        instance = this;
    }
    public void KillPlayer()
    {
        // currentLives -1
        currentLives--;

        // If currentLives is more than 0
        if (currentLives > 0)
        {
            // Coroutine deliberately slow down a function or make it wait for longer than the split second duration that it runs. (Example we want to make a square that changes its color between red and blue in 1-second intervals.)
            StartCoroutine(RespawnCo());
        }
    }

    // IEnumerator allows to stop the process at a specific moment, return that part of object (or nothing) and gets back to that point whenever you need it.This until the MoveNext method from IEnumerator returns false indicating we reached the end of the collection/file.
    public IEnumerator RespawnCo()
    {
        // Respawn car after 2f
        yield return new WaitForSeconds(respawnTime);
        // Call "Respawn()" from HealthManager script
        HealthManager.instance.Respawn();
    }
}
