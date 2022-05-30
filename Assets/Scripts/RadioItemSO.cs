using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Radio Item", fileName = "New Radio Item")]
public class RadioItemSO : ScriptableObject
{
    public string radioItemName;
    public GameObject radioItemPrefab;

    [TextArea(2,4)]
    public string itemFoundText;
    [TextArea(2,4)]
    public string itemNotFoundText;

}
