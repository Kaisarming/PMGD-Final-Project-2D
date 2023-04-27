using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadCount : MonoBehaviour
{
    public string deathCountTxt;
    private int deathCount;
    public GameObject canvas;

    //void Start()
    //{
    //    DiedIntTxt.text = deathCount.ToString();
    //}

    // Update is called once per frame
    //void Update()
    //{
    //    if (HealthManager.Respawn())
    //    {
    //        deathCount++;
    //        DiedIntTxt.text = deathCount.ToString();
    //    }
    //}

    public void DeathCount()
    {
        deathCount++;
        deathCountTxt = deathCount.ToString();
        canvas.GetComponent<Text>().text = deathCountTxt;
    }
}
