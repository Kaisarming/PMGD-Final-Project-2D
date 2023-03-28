using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    public AudioSource audioSource;
    public Button musicButton;
    public Sprite musicIcon;
    public Sprite muteIcon;

    private bool isMuted = false;

    private void Start()
    {
        musicButton.onClick.AddListener(ToggleSound);
    }

    private void ToggleSound()
    {
        isMuted = !isMuted;
        if (isMuted)
        {
            audioSource.mute = true;
            musicButton.image.sprite = muteIcon;
        }
        else
        {
            audioSource.mute = false;
            musicButton.image.sprite = musicIcon;
        }
    }
}
