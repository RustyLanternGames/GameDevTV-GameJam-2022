using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject dialogueTextPanel;
    [TextArea(2, 4)]
    [SerializeField] string startingAreaText;
    [SerializeField] float startingDisplayTime;
    GameManager gameManager;
    
    Coroutine dialogueCo;
    bool dialogueCoIsRunning = false;

    void Start()
    {
        SetUIText(startingAreaText, startingDisplayTime);
        gameManager = FindObjectOfType<GameManager>();
    }


    void Update()
    {
        scoreText.text = gameManager.GetScore().ToString();
    }

    public void SetUIText(string newText, float displayTime)
    {
        if(dialogueCoIsRunning)
        {
            StopCoroutine(dialogueCo);
            dialogueCoIsRunning = false;
        }
        dialogueCo = StartCoroutine(displayDialogue(newText, displayTime));
    }

    IEnumerator displayDialogue(string newText, float displayTime)
    {
        dialogueCoIsRunning = true;
        dialogueTextPanel.SetActive(true);
        dialogueText.text = newText;
        yield return new WaitForSecondsRealtime(displayTime);
        dialogueTextPanel.SetActive(false);
        dialogueCoIsRunning = false;
    }
}
