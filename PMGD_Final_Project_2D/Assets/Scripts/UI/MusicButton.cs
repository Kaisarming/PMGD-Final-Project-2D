using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    public GameObject audioSource;
    public GameObject musicIcon;
    public GameObject muteIcon;

    public void Start()
    {
        audioSource.SetActive(true);
        muteIcon.SetActive(false);
    }

    public void MusicMute()
    {
        audioSource.SetActive(false);
        muteIcon.SetActive(true);
        musicIcon.SetActive(false);
    }

    public void MusicOn()
    {
        audioSource.SetActive(true);
        muteIcon.SetActive(false);
        musicIcon.SetActive(true);
    }
}
