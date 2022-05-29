using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] GameObject dialogueTextPanel;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void SetUIText(string newText)
    {
        StartCoroutine(displayDialogue(newText));
    }

    IEnumerator displayDialogue(string newText)
    {
        dialogueTextPanel.SetActive(true);
        dialogueText.text = newText;
        yield return new WaitForSecondsRealtime(5);
        dialogueTextPanel.SetActive(false);
    }
}
