using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonGuardManager : MonoBehaviour
{
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        List<string> guardedDoors = gameManager.GetGuardedDoors();
        foreach(string door in guardedDoors)
        {
            GameObject doorObject = GameObject.Find(door);
            doorObject.GetComponent<Door>().SetIsGuarded();
        }

        List<string> completedDoors = gameManager.GetCompletedDoors();
        foreach(string door in completedDoors)
        {
            GameObject doorObject = GameObject.Find(door);
            doorObject.GetComponent<Door>().SetIsCompleted();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
