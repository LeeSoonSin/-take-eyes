using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Versioning;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite itemImage;
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
