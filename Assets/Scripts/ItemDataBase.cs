using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{
    public List<Item> itemList = new List<Item>();

    void Start()
    {
        itemList.Add(new Item(10001, "일기장", "누군가가 적은 일기장이다.", Item.ItemType.Use));
    }
    void Update()
    {

    }
}
