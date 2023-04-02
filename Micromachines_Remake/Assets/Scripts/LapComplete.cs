using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Because this script is used for the UI Image of "Best Time"
using UnityEngine.UI;

public class LapComplete : MonoBehaviour
{
    public GameObject trackComplete;
    public GameObject halfway;
    public GameObject minBest;
    public GameObject secBest;
    public GameObject milliBest;

    // "Laps image" game object variable
    public GameObject lapCounter;
    public int lapsComplete;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // +1 to lapsComplete everytime the player pass through the complete lap line
        lapsComplete += 1;

        // LapTime is a name of a scripts, while secCount is a name of a variable in LapTime script. secCount can be access in this script because it use static
        if (LapTime.secCount <= 9)
        {
            // If setCount is less than or equal to 9, set text to "0 + secCount value + ."
            secBest.GetComponent<Text>().text = "0" + LapTime.secCount + ".";
        }
        else
        {
            // Else set text to "secCount value + ."
            secBest.GetComponent<Text>().text = "" + LapTime.secCount + ".";
        }

        if (LapTime.minCount <= 9)
        {
            // If minCount is less than or equal to 9, set text to "0 + minCount value + ."
            minBest.GetComponent<Text>().text = "0" + LapTime.minCount + ".";
        }
        else
        {
            // Else set text to "minCount value + ."
            minBest.GetComponent<Text>().text = "" + LapTime.minCount + ".";
        }

        // Change the text in milli best time to "milliCount"
        milliBest.GetComponent<Text>().text = "" + LapTime.milliCount;

        // When player collide with the "Lap Complete Trigger" game object in Unity, minCount, secCount, and millicount will be reset to 0. "Halfway Trigger" game object will be active again in Unity" and "Lap Complete Trigger" game object will not be active again in Unity"
        LapTime.minCount = 0;
        LapTime.secCount = 0;
        LapTime.milliCount = 0;

        lapCounter.GetComponent<Text>().text = "" + lapsComplete;

        halfway.SetActive(true);
        trackComplete.SetActive(false);
    }
}
