using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    public Image characterSprite;
    public Sprite[] characterSprites;
    public string[] dialogueLines;
    public int currentLine;
    public Button continueButton;
    public GameObject speedometerUI;
    public GameObject TimeLimitTxt;
    public GameObject NPC;


    private bool isTyping;
    private string currentText;
    private Coroutine typingCoroutine;
    public float typingSpeed = 1f;


    void Start()
    {
        continueButton.onClick.AddListener(ContinueDialogue);
        speedometerUI.SetActive(false);
        TimeLimitTxt.GetComponent<GameTimeLimit>().enabled = false;
        NPC.SetActive(true);
    }

    void Update()
    {
        if (currentLine >= dialogueLines.Length)
        {
            dialogueBox.SetActive(false);
            speedometerUI.SetActive(true);
            TimeLimitTxt.GetComponent<GameTimeLimit>().enabled = true;
            NPC.SetActive(false);
            return;
        }

        if (isTyping)
        {
            dialogueText.text = currentText;
        }
        else
        {
            currentText = dialogueLines[currentLine];
            characterSprite.sprite = characterSprites[currentLine];
            dialogueText.text = currentText;
            typingCoroutine = StartCoroutine(TypingEffect(currentText));
            currentLine++;
        }
    }

    void ContinueDialogue()
    {
        if (isTyping)
        {
            StopCoroutine(typingCoroutine);
            dialogueText.text = currentText;
            isTyping = false;
        }
        else
        {
            isTyping = true;
        }
    }


    IEnumerator TypingEffect(string text)
    {
        dialogueText.text = "";
        isTyping = true;
        foreach (char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }
}