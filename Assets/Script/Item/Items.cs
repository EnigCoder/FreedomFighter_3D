using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Items : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public int count;
    public int amount;
    public Sprite icon;
    public ItemType itemType;

    public enum ItemType
    {
        Blood,
        Bullet,
        Weapons,
    }
}
