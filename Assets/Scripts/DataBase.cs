using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    public string[] var_name;
    public float[] var;

    public string[] switch_name;
    public bool[] switches;

    public List<Item> itemList = new List<Item>();
    
    public void UseItem(int _itemID)
    {
        switch(_itemID)
        {
            case 10001:
                Debug.Log("문이 열렸습니다.");
                break;
            case 10002:
                Debug.Log("제초제를 사용했습니다.");
                break;

        }
    }
    void Start()//아이템을 여기에 추가
    {
        itemList.Add(new Item(10001, "열쇠", "어딘가의 문을 열 열쇠", Item.ItemType.Use));
        itemList.Add(new Item(10002, "제초제", "식물들을 한번에 보낼수 있다.", Item.ItemType.Use));
    }
}
