using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    int score;
    Vector3 streetSpawnLocation = new Vector3(-16f, -3.8f, 0f);
    Vector3 nextSpawnLocation = new Vector3(-16f, -3.8f, 0f);

    void Awake()
    {
        int numGameManagers = FindObjectsOfType<GameManager>().Length;
        if(numGameManagers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public int GetScore()
    {
        return score;
    }
    public void AddToScore(int points)
    {
        score += points;
    }

    public void SetStreetSpawnLocation(Vector3 spawnLocation)
    {
        streetSpawnLocation = spawnLocation;
    }

    public Vector3 GetStreetSpawnLocation()
    {
        return streetSpawnLocation;
    }

    public Vector3 GetNextSpawnLocation()
    {
        return nextSpawnLocation;
    }

    public void SetNextSpawnLocation(Vector3 spawnLocation)
    {
         nextSpawnLocation = spawnLocation;
    }

    
}
