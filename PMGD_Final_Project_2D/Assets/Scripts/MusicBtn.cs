using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicBtn : MonoBehaviour
{
    public Sprite newButtonImage;
    public Sprite oldButtonImage;
    public Button button;
    void Start()
    {
        button.image.sprite = oldButtonImage;
    }

    void Update()
    {
        if (button.image.sprite == oldButtonImage)
        {
            button.image.sprite = newButtonImage;
        }

        if (button.image.sprite == newButtonImage)
        {
            button.image.sprite = oldButtonImage;
        }

    }
}
