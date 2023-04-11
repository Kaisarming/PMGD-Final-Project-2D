using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashLoader : MonoBehaviour
{
    private int ctr;
    private GameObject Splash;
    private GameObject Main;
    private bool Trigger;
    private bool Switch;
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
        Splash = GameObject.Find("Splash");
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
    }

    // Update is called once per frame
    void Update()
    {
        if (ctr==3){
            Splash.SetActive(false);
            Main.SetActive(true);
        }
        else{
            if (TargetImage.color.a == 0){
                Switch = false;
                Trigger = false;
                if (!Switch){
                    Invoke("FadeOutFunc", Delay);
                }
            }
            if (TargetImage.color.a == 1){
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
