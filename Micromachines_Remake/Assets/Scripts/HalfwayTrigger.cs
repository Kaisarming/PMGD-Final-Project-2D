using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfwayTrigger : MonoBehaviour
{
    // Create 2 game object holder in Unity
    public GameObject halfwayTrigger;
    public GameObject lapCompleteTrigger;

    //other variable can only be called and used in this void function
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If player passed through "Lap Complete Trigger" game object
        if (other.tag == "Player")
        {
            // The  "Lap Complete Trigger" game object can be triggered (By the way we can know it active or not from the checklist on the top left corner near the name of the game object)
            lapCompleteTrigger.SetActive(true);
            //The "Halfway Trigger" game object cannot be triggered
            halfwayTrigger.SetActive(false);
        }
    }
}
