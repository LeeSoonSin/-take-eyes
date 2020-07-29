using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int itemID; //아이템 고유 ID값, 중복 불가능. (50001, 50002)
    public string itemName; //아이템 이름, 중복 가능 (고대유물, 고대유물)
    public string itemDescription; //아이템 설명
    public int itemCount; //소지개수
    public Sprite itemIcon; //아이템의 아이콘
    public ItemType itemType; //4가지 값중 하나만 가지게 됨,

    public enum ItemType //열거
    {
        Use,//소모품
        Equip,//장비
        Quest,//퀘스트아이템
        ETC//기타 아이템
    }

    public Item(int _itemID, string _itemName, string _itemDes, ItemType _itemType, int _itemCount = 1)
    {
        itemID = _itemID;
        itemName = _itemName;
        itemDescription = _itemDes;
        itemType = _itemType;
        itemCount = _itemCount;
        itemIcon = Resources.Load("ItemIcon/" + itemID.ToString(), typeof(Sprite)) as Sprite;
    }
}
