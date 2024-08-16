using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Inventory",menuName ="Inventory/New Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> items = new List<Item>();
    public Vector2 OriginalPos;
}
