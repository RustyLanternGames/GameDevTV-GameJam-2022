using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int score;
    int maxPoints = 200;
    int allBuildings = 5;
    int buildingsComplete;
    Vector3 streetSpawnLocation = new Vector3(-16f, -3.8f, 0f);
    Vector3 nextSpawnLocation = new Vector3(-16f, -3.8f, 0f);

    [SerializeField] string currentBuilding;

    List<string> guardedDoors;
    List<string> completedDoors;

    bool gameOver = false;

    void Awake()
    {
        int numGameManagers = FindObjectsOfType<GameManager>().Length;
        if(numGameManagers > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        
    }

    void Start()
    {
        guardedDoors = new List<string>();
        completedDoors = new List<string>();
    }

    void Update()
    {
        if(!gameOver)
        {
            if(buildingsComplete >= allBuildings)
            {
                StartCoroutine(EndGame());
            }
        }
        
    }

    IEnumerator EndGame()
    {
        gameOver = true;
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene("GameOver");
    }

    public void BuildingComplete()
    {
        buildingsComplete++;
    }

    public int GetMaxPoints()
    {
        return maxPoints;
    }

    public void AddToWinList(string door)
    {
        completedDoors.Add(door);
    }

    public List<string> GetCompletedDoors()
    {
        return completedDoors;
    }

    public string GetCurrentBuilding()
    {
        return currentBuilding;
    }

    public List<string> GetGuardedDoors()
    {
        return guardedDoors;
    }

    public void SetCurrentBuilding(string building)
    {
        currentBuilding = building;
    }

    public void AddToGuardList(string door)
    {
        guardedDoors.Add(door);
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

    public void ClearDataAndReload()
    {
        score = 0;
        buildingsComplete = 0;
        gameOver = false;
        guardedDoors = new List<string>();
        completedDoors = new List<string>();
        streetSpawnLocation = new Vector3(-16f, -3.8f, 0f);
        SceneManager.LoadScene("MainMenu");
    }
}
