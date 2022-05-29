using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    bool hasBeenFound = false;
    [SerializeField] GameObject inspectPrompt;
    [SerializeField] string[] radioNeeds;
    int radioItemsNeededCount;
    int radioItemsFoundCount;
    bool allItemsFound = false;
    GameObject thisInspectPrompt;
    Vector3 inspectPromptOffset = new Vector3(0f, 2.5f, 0f);
    Vector3 inspectPromptPosition;


    void Start()
    {
        inspectPromptPosition = transform.position + inspectPromptOffset;
        radioItemsNeededCount = radioNeeds.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHasBeenFound()
    {
        hasBeenFound = true;
    }

    public bool GetHasBeenFound()
    {
        return hasBeenFound;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            if (!thisInspectPrompt)
            {
                DisplayInteractPrompt();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (inspectPrompt)
            {
                Destroy(thisInspectPrompt);
            }
        }
    }

    void DisplayInteractPrompt()
    {
        thisInspectPrompt = Instantiate(inspectPrompt, inspectPromptPosition, Quaternion.identity);
    }

    public string[] GetRadioNeeds()
    {
        return radioNeeds;
    }

    public int GetRadioItemsNeededCount()
    {
        return radioItemsNeededCount;
    }

    public int GetRadioItemsFoundCount()
    {
        return radioItemsFoundCount;
    }

    public void ItemFound()
    {
        radioItemsFoundCount++;
        if(radioItemsNeededCount == radioItemsFoundCount)
        {
            allItemsFound = true;
        }
    }

    public bool GetAllItemsFound()
    {
        return allItemsFound;
    }
}
