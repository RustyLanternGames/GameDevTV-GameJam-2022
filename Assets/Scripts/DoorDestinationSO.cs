using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Door Destination", fileName = "New Building")]
public class DoorDestinationSO : ScriptableObject
{
    [SerializeField] int sceneIndex;


    public int getNextSceneIndex()
    {
        return sceneIndex;
    }
}
