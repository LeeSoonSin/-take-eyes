using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    bool activeInventory = false;
    List<Item> items = new List<Item>();

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;
    void Start()
    {
        inventoryPanel.SetActive(activeInventory);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
    }
    public bool AddItem(Item _item)
    {
        items.Add(_item);
        if(onChangeItem != null)
        {
            onChangeItem.Invoke();
        }    
        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("FieldItem"))
        {
            FieldItem fieldItems = collision.GetComponent<FieldItem>();
            if(AddItem(fieldItems.GetItem()))
            {
                fieldItems.DestroyItem();
            }
        }
    }
}
