using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour
{

    Vector2 streetSpawn;
    Vector3 doorPromptOffset = new Vector3(0f, 2.5f, 0f);
    Vector3 doorPromptPosition;

    [SerializeField] GameObject doorOpenPrompt;
    GameObject thisDoorPrompt;

    // Start is called before the first frame update
    void Start()
    {
        doorPromptPosition = transform.position + doorPromptOffset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D other)
     {
        if(other.gameObject.tag == "Player")
        {
            DisplayDoorOpenPrompt();
        }    
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            if(thisDoorPrompt)
            {
                Destroy(thisDoorPrompt);
            }
        }
    }

    void DisplayDoorOpenPrompt()
    {
        thisDoorPrompt = Instantiate(doorOpenPrompt, doorPromptPosition, Quaternion.identity);
    }   

}
