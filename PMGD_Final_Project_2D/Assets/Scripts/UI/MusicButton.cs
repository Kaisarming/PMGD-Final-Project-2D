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

    //private bool isMuted = false;

    private void Start()
    {
        muteIcon.SetActive(false);
        musicButton.onClick.AddListener(MusicMute);
        muteButton.onClick.AddListener(MusicOn);
    }

    private void MusicMute()
    {
        /*isMuted = !isMuted;
        if (isMuted)
        {*/
            audioSource.mute = true;
            muteIcon.SetActive(true);
            musicIcon.SetActive(false);
        /*}
        else
        {
            audioSource.mute = false;
            muteIcon.SetActive(false);
            musicIcon.SetActive(true);
        }*/
    }

    private void MusicOn()
    {
        /*isMuted = !isMuted;
        if (isMuted)
        {*/
            audioSource.mute = false;
            muteIcon.SetActive(false);
            musicIcon.SetActive(true);
        /*}
        else
        {
            audioSource.mute = true;
            muteIcon.SetActive(true);
            musicIcon.SetActive(false);
        }*/
    }
}
