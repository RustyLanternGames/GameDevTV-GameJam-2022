using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    GameManager gameManager;
    int finalScore;
    int maxPoints;
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        slider = FindObjectOfType<Slider>();
        finalScore = gameManager.GetScore();
        maxPoints = gameManager.GetMaxPoints();

        slider.maxValue = maxPoints;
        if(finalScore <= maxPoints)
        {
            slider.value = finalScore;
        }
        else
        {
            slider.value = maxPoints;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        gameManager.ClearDataAndReload();
    }
}
