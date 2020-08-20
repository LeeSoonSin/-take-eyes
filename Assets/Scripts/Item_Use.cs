using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Use : MonoBehaviour
{
    public DataBase database;
    //public Inventory inventory;
    public int Item_id;
    // Start is called before the first frame update
    void Start()
    {
        database = FindObjectOfType<DataBase>();
        //inventory = FindObjectOfType<Inventory>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButtonDown("Jump"))
        {
            for (int i = 0; i < Inventory.instance.inventoryItemList.Count; i++)
            {
                if (Inventory.instance.inventoryItemList[i].itemID == (Item_id))//인벤토리 번호와 사용할아이템 번호를 검사
                {
                    database.UseItem(Inventory.instance.inventoryItemList[i].itemID);
                    Inventory.instance.inventoryItemList.RemoveAt(i);
                    Debug.Log("아이템 사용됨");
                    break;
                }
            }
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.name == "Player") //닿으면 작동
    //    {
    //        for (int i = 0; i < Inventory.instance.inventoryItemList.Count; i++)
    //        {
    //            if (Inventory.instance.inventoryItemList[i].itemID == (Item_id))//인벤토리 번호와 사용할아이템 번호를 검사
    //            {
    //                database.UseItem(Inventory.instance.inventoryItemList[i].itemID);
    //                Inventory.instance.inventoryItemList.RemoveAt(i);
    //                break;
    //            }
    //        }
    //    }
    //}
    void Update()
    {
        
    }
}
