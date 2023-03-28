using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    public AudioSource audioSource;
    public Button musicButton;
    public Button muteButton;
    public GameObject musicIcon;
    public GameObject muteIcon;

    private bool isMuted = false;

    private void Start()
    {
        muteIcon.SetActive(false);
        musicButton.onClick.AddListener(MusicMute);
        muteButton.onClick.AddListener(MusicOn);
    }

    private void MusicMute()
    {
        isMuted = !isMuted;
        if (isMuted)
        {
            audioSource.mute = true;
            muteIcon.SetActive(true);
        }
        else
        {
            audioSource.mute = false;
            muteIcon.SetActive(false);
        }
    }

    private void MusicOn()
    {
        isMuted = !isMuted;
        if (isMuted)
        {
            audioSource.mute = false;
            muteIcon.SetActive(false);
        }
        else
        {
            audioSource.mute = true;
            muteIcon.SetActive(true);
        }
    }
}
