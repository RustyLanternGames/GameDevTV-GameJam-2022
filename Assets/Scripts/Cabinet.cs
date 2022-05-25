using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour
{

    // GameObject interactPrompt;
    [SerializeField] GameObject inspectPrompt;
    GameObject thisInspectPrompt;
    Vector3 inspectPromptOffset = new Vector3(0f, 2.5f, 0f);
    Vector3 inspectPromptPosition;

    [SerializeField] bool hasItem;
    [SerializeField] RadioItem radioItem;


    // Start is called before the first frame update
    void Start()
    {
        inspectPromptPosition = transform.position + inspectPromptOffset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            if(!thisInspectPrompt)
            {
                DisplayInteractPrompt();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            if(inspectPrompt)
            {
                Destroy(thisInspectPrompt);
            }
        }
    }

    void DisplayInteractPrompt()
    {
        thisInspectPrompt = Instantiate(inspectPrompt, inspectPromptPosition, Quaternion.identity);
    }

    public bool GetHasItem()
    {
        return hasItem;
    }

    public RadioItem GetRadioItem()
    {
        hasItem = false;
        return radioItem;
    }
}
