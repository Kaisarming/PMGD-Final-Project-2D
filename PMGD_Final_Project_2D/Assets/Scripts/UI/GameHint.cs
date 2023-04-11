using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHint : MonoBehaviour
{
    public Text startText;

    private void Start()
    {
        // Tampilkan tulisan "Game starts in 5 seconds"
        startText.enabled = true;
        startText.text = "Reach the target destination by following the arrow before the time limit!";

        // Matikan tulisan setelah lima detik
        Invoke("HideText", 5f);
    }

    private void HideText()
    {
        startText.enabled = false;
    }
}
