using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameBtn : MonoBehaviour
{
    public GameObject car;
    private Vector3 carInitialPosition;

   
    // Start is called before the first frame update
    public void Restart()
    {
        SceneManager.LoadScene("GamePlay");

    }

    
}
