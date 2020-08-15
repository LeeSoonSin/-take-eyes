using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Use : MonoBehaviour
{
    public int Item_id;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            for (int i = 0; i < Inventory.instance.inventoryItemList.Count; i++)
            {
                if (Inventory.instance.inventoryItemList[i].itemID == /*Item.instance.itemID*/(Item_id))
                {
                    DataBase.instance.UseItem(Inventory.instance.inventoryItemList[i].itemID);
                        Inventory.instance.inventoryItemList.RemoveAt(i);
                    break;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
