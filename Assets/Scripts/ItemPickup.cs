using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public int itemID;
    public int _count;
    public int DataNum; 
    public DataBase dataBase;
    private void Awake()
    {
        dataBase = FindObjectOfType<DataBase>();
    }

    public void Start()
    {
        if (dataBase.switches[DataNum] == true)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
            if (Input.GetButtonDown("Jump"))
            {
                Inventory.instance.GetAnItem(itemID,_count);
                Destroy(this.gameObject);
                dataBase.switches[DataNum] = true;
            }
    }
}
