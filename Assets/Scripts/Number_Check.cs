using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number_Check : MonoBehaviour
{
    private Number_Check instance1;
    private NumberSystem theNumber;
    private DataBase dataBase;
    private List<Item> inventoryItemList;

    public bool flag;
    public int correctNum;
    public bool gift;
    public int itemID;
    public int _count;
    public int DataNum;
    private void Start()
    {
        //if (instance1 != null)
        //{
        //    Destroy(this.gameObject);
        //}
        //else
        //{
        //    DontDestroyOnLoad(this.gameObject);
        //    instance1 = this;
        //}
        theNumber = FindObjectOfType<NumberSystem>();
        dataBase = FindObjectOfType<DataBase>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(dataBase.switches[DataNum] == false)
        {
            if (theNumber.correctFlag == true )
                {
                    flag = true;
                    Debug.Log("작동은 잘됨");
                    if (!gift)
                    {
                    Inventory.instance.GetAnItem(itemID, _count);
                    //Inventory.instance.inventoryItemList.Add(new Item(10001, "열쇠", "어딘가의 문을 열 열쇠", Item.ItemType.Use));
                    //Inventory.instance.inventoryItemList.Add(new Item(10001, "임시 테스트 열쇠", "어딘가의 문을 열 열쇠", Item.ItemType.Use));
                }
                    gift = true;
                    dataBase.switches[DataNum] = true;

                }
                else if (collision.gameObject.name == "Player" && !flag)
                {
                    StartCoroutine(ACoroutine());
                }
        }
        else
        {
            Debug.Log("이미 사용했습니다.");
        }
    
    }
    IEnumerator ACoroutine()
    {
        theNumber.ShowNumber(correctNum);
        yield return new WaitUntil(() => theNumber.activated);
    }
}
