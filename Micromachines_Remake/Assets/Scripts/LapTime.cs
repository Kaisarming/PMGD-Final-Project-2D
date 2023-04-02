using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Because this script is used for the UI Image of "Lap Time"
using UnityEngine.UI;

public class LapTime : MonoBehaviour
{
    // Static basically means that we can access this variable in another scripts
    public static int minCount;
    public static int secCount;
    public static float milliCount;
    public static string milliDisplay;
    public GameObject min;
    public GameObject sec;
    public GameObject milli;

    // Update is called once per frame
    void Update()
    {
        // The line below means milliCount = milliCount + Time.deltaTime * 10. Time.time update every frame, while Time.deltaTime update every seconds. So it means that every seconds, milliseconds will go from 0 to 9 because it is multiply by 10 every seconds
        milliCount += Time.deltaTime * 10;
        //Convert the decimal to whole number(f0). (So it means example f1 is 0.1, f3 is 0.001)
        milliDisplay = milliCount.ToString("f0");

        milli.GetComponent<Text>().text = "" + milliDisplay;

        // Everytime milliseconds is more than equal to 10
        if (milliCount >= 10)
        {
            // Milliseconds is equal to 0 again
            milliCount = 0;
            // Seconds will +1
            secCount += 1;
        }

        // If secCount is less than or equal to 9
        if (secCount <= 9)
        {
            // Get component from game object "Lap Time Image" child object's "named seconds. In the canvas renderer there is Text and when we open the Text for more information there is Text again(that is why it is <Text>().text). make it to 0 + the secCount value + .
            sec.GetComponent<Text>().text = "0" + secCount + ".";
        }
        else
        {
            // Else(if it is 10 or above), the 0 in the front of secons will disappear and only display secCount(11,12,13, and so on) + "."
            sec.GetComponent<Text>().text = "" + secCount + ".";
        }

        // If secCount is equal to or more than 60
        if (secCount >= 60)
        {
            // Make secCount to 0 again
            secCount = 0;
            // And the minCount +1
            minCount += 1;
        }

        // If minCount is less than or equal to 9
        if (minCount <= 9)
        {
            // We will be getting component from "min" game object that is the text, and make the text to "0 + minCount value + :"
            min.GetComponent<Text>().text = "0" + minCount + ":";
        }
        else
        {
            // Else we will be getting component from "min" game object that is the text, and make the text to "0 + minCount value + :"
            min.GetComponent<Text>().text = "" + minCount + ":";
        }
    }
}
