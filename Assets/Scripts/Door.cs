using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour
{

    Vector2 streetSpawn;
    Vector3 doorPromptOffset = new Vector3(0f, 2.5f, 0f);
    Vector3 doorPromptPosition;

    [SerializeField] GameObject doorPrompt;
    GameObject thisDoorPrompt;

    [SerializeField] string sceneName;
    [SerializeField] bool isExit = false;

    Vector3 buildingSpawnPosition = new Vector3(-15f, -1.5f, 0f);

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
            DisplayDoorPrompt();
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

    void DisplayDoorPrompt()
    {
        thisDoorPrompt = Instantiate(doorPrompt, doorPromptPosition, Quaternion.identity);
    }

    public Vector3 GetBuildingSpawnPosition()
    {
        return buildingSpawnPosition;
    }

    public bool GetIsExit()
    {
        return isExit;
    }

    public string GetNextSceneName()
    {
        return sceneName;
    }

}
