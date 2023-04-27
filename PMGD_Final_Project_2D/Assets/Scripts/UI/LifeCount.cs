using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    private int lifeInt;
    private string lifeString;
    HealthManager lifeFromHealthManager;
    public GameObject txtFromUnity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LifeFunction()
    {
        lifeInt--;
        lifeString = lifeInt.ToString();
        txtFromUnity.GetComponent<Text>().text = lifeString;
    }
}
