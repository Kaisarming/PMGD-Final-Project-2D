using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject playerPrefab;
    public GameObject activePlayer;
    public bool isPlaying = true;
    //public ScriptableInteger coin;
    //public EnemySpawner spawner;

    public int currentLives = 3;
    public float respawnTime = 2f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
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
    public static GameManager GetInstance()
    {
        return instance;
    }

    private void spawnPlayer()
    {
        activePlayer = Instantiate(playerPrefab);
    }

    public Vector3 getPlayerPosition()
    {
        if (activePlayer != null)
        {
            return activePlayer.transform.position;
        }
        return Vector3.zero;
    }

    public void startGame()
    {
        isPlaying = true;
        spawnPlayer();
    }

    internal void restart()
    {
        SceneManager.LoadScene("GamePlay");
        Time.timeScale = 1;
    }
}
