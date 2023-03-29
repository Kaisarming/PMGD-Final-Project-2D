using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayStart : MonoBehaviour
{
    public GameObject start;
    public AudioSource go;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartUp");

    }

    // I use IEnumerator because there is some wait/delay in 3,2,1,go
    IEnumerator StartUp()
    {
        // This code below is to freeze the game so nothing work before 3,2,1,go finish counting
        // timeScale can be used for slow motion effects or to speed up your application. When timeScale is 1.0, time passes as fast as real time. When timeScale is 0.5 time passes 2x slower than realtime.
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 4f;
        go.Play();

        while (Time.realtimeSinceStartup < pauseTime)
        {
            yield return 0;
        }

        start.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
