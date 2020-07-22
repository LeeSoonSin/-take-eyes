using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Versioning;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int itemID;
    public string itemName;
    public string itemDescription;
    public int itemCount;
    public Sprite itemIcon;
    public ItemType itemType;

    public enum ItemType
    {
        Equip,
        ETC
    }

    public bool Use()
    {
        return false;
    }
}
