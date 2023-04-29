using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    private int lifeInt;
    private string lifeString;
    public GameObject txtFromUnity;

    public void LifeFunction()
    {
        lifeInt--;
        lifeString = lifeInt.ToString();
        txtFromUnity.GetComponent<Text>().text = lifeString;
    }
}
