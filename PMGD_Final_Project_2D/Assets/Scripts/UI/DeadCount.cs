using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadCount : MonoBehaviour
{
    public string deathCountTxt;
    private int deathCount;
    public GameObject canvas;

    public void DeathCount()
    {
        deathCount++;
        deathCountTxt = deathCount.ToString();
        canvas.GetComponent<Text>().text = deathCountTxt;
    }
}
