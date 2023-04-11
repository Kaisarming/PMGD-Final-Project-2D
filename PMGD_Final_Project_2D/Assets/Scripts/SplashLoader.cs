using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashLoader : MonoBehaviour
{
    private int ctr;
    private GameObject Main;
    private bool Trigger;
    private bool Switch;
    public Image BG;
    public Image TargetImage;
    public Image Logo1;
    public Image Logo2;
    public float FadeSpeed;
    public float Delay;

    void Awake()
    {
        TargetImage.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
        Logo1.enabled = true;
        Logo2.enabled = false;
        Main = GameObject.Find("Main Menu");
        ctr=0;
    }

    void FadeInFunc()
    {
        TargetImage.color = Color.Lerp(TargetImage.color, Color.clear, FadeSpeed * Time.deltaTime);
    }
    void FadeOutFunc()
    {
        TargetImage.color = Color.Lerp(TargetImage.color, Color.black, FadeSpeed * Time.deltaTime);
    }

    void Start()
    {
        Trigger = false;
        Main.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ctr==3){
            BG.enabled = false;
            Logo2.enabled = false;
            Invoke("FadeInFunc", Delay);
            Main.SetActive(true);
        }
        else if (ctr<3){
            if (TargetImage.color.a <= 0.1f){
                Switch = false;
                Trigger = false;
                if (!Switch){
                    Invoke("FadeOutFunc", Delay);
                }
            }
            if (TargetImage.color.a >= 0.9f){
                Switch = true;
                if (ctr==2){
                Logo1.enabled = false;
                Logo2.enabled = true;
                }
                if (!Trigger){
                ctr++;
                Trigger = true;
                }
                if (Switch){
                    Invoke("FadeInFunc", Delay);
                }
            }
        }
    }
}
