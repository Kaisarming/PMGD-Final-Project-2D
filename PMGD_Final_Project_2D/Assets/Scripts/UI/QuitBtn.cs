using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitBtn : MonoBehaviour
{
    public void Exit()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }
}
