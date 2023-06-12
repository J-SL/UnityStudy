using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New GoodsItem",menuName ="Inventory/New GoodItem")] 
public class GoodsItem : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    public int itemHeld;
    [TextArea]
    public string itemInfo;

    public bool equip;
}
