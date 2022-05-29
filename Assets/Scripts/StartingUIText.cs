using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingUIText : MonoBehaviour
{
    DialogueManager dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            dialogueManager.SetUIText("I need to get my music out there before these demons claim my soul!\n" +
                "That's what I get for making a deal with the devil...");
        }
    }
}
