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
    public GameObject itemPick;
    public GameObject NumberSystem;
    public GameObject NumCheck;
    public FlyMob thefly;
    public static DataBase instance;

    #region Singleton
    public static DataBase Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<DataBase>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newObj = new GameObject().AddComponent<DataBase>();
                    instance = newObj;
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        var objs = FindObjectsOfType<DataBase>();
        thefly = FindObjectOfType<FlyMob>();
        if (objs.Length != 1)
        {
            Destroy(gameObject);
            Destroy(this.itemPick);
            Destroy(this.NumberSystem);
            Destroy(this.NumCheck);
            return;
        }
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(this.itemPick);
        DontDestroyOnLoad(this.NumberSystem);
        DontDestroyOnLoad(this.NumCheck);
    }
#endregion Singleton
    public void UseItem(int _itemID)
    {
        switch(_itemID)
        {
            case 10002:
                Debug.Log("제초제를 사용했습니다.");
                break;

            case 10003:
                Debug.Log("물이 담긴 페트병을 사용했습니다.");
                Inventory.instance.inventoryItemList.Add(new Item(10009, "가위", "식물줄기를 자를 수 있을 것 같다", Item.ItemType.Use));
                break;

            case 10004:
                Debug.Log("페트병을 사용했습니다.");
                Inventory.instance.inventoryItemList.Add(new Item(10003, "물이 담긴 페트병", "식물에게 줄까?", Item.ItemType.Use));
                break;

            case 10008:
                Debug.Log("대걸레 봉을 사용했습니다.");
                thefly.MopActive();
                break;

            case 10009:
                Debug.Log("가위를 사용했습니다.");
                break;

            case 10010:
                Debug.Log("이 종이를 사용해도 아무일이 일어나지 않습니다..");
                break;

        }
    }
    void Start()//아이템을 여기에 추가
    {
        itemList.Add(new Item(10001, "임시 테스트 열쇠", "어딘가의 문을 열 열쇠", Item.ItemType.Use));
        itemList.Add(new Item(10002, "제초제", "식물들을 한번에 보낼수 있다.", Item.ItemType.Use));
        itemList.Add(new Item(10003, "물이 담긴 페트병", "식물에게 줄까?", Item.ItemType.Use));
        itemList.Add(new Item(10004, "페트병", "무언가를 담기 위해 가져왔다", Item.ItemType.Use));
        itemList.Add(new Item(10005, "가정실 열쇠", "가정실 문을 열 열쇠", Item.ItemType.Use));
        itemList.Add(new Item(10006, "진로실 열쇠", "진로실 문을 열 열쇠", Item.ItemType.Use));
        itemList.Add(new Item(10007, "옥상 열쇠", "옥상 문을 열 열쇠", Item.ItemType.Use));
        itemList.Add(new Item(10008, "대걸레 봉", "매우 길다.", Item.ItemType.Use));
        itemList.Add(new Item(10009, "가위", "식물줄기를 자를 수 있을 것 같다", Item.ItemType.Use));
        itemList.Add(new Item(10010, "교무실 금고 비밀번호 종이", "종이에는 202020라고 적혀있다.", Item.ItemType.Use));
        
    }
}
