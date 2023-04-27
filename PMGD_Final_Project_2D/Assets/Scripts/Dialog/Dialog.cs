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

    private bool isTyping;
    private string currentText;
    private Coroutine typingCoroutine;
    public float typingSpeed = 0.05f;


    void Start()
    {
        continueButton.onClick.AddListener(ContinueDialogue);
       
    }

    void Update()
    {
        if (currentLine >= dialogueLines.Length)
        {
            dialogueBox.SetActive(false);
            return;
        }

        if (isTyping)
        {
            dialogueText.text = currentText;
        }
        else
        {
            currentText = dialogueLines[currentLine];
            typingCoroutine = StartCoroutine(TypingEffect(currentText));
            characterSprite.sprite = characterSprites[currentLine];
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

