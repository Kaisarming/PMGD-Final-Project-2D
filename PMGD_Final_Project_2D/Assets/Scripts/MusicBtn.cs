using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicBtn : MonoBehaviour
{
    public Image imageMuteButton;

    void Start()
    {

    }

    void Update()
    {

    }

    public void MuteButton()
    {
        if (Button.ButtonClickedEvent)
        {
            imageMuteButton.sprite = muteSprite[1];
        }
        else
        {
            imageMuteButton.sprite = muteSprite[0];
        }
    }
}
