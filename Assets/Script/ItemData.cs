using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "SortingGame/Item")]
public class ItemData : ScriptableObject
{
    public Sprite itemSprite;
    public string category;
}

