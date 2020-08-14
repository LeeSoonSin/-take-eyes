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

    private void Start()
    {
        if (instance1 != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance1 = this;
        }
        theNumber = FindObjectOfType<NumberSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (theNumber.correctFlag == true)
        {
            flag = true;
            Debug.Log("작동은 잘됨");
            if (!gift)
            {
                Inventory.instance.inventoryItemList.Add(new Item(10001, "임시 테스트 열쇠", "어딘가의 문을 열 열쇠", Item.ItemType.Use));
            }
            gift = true;


        }
        else if (collision.gameObject.name == "Player" && !flag)
        {
            StartCoroutine(ACoroutine());
        }
    }
    IEnumerator ACoroutine()
    {
        theNumber.ShowNumber(correctNum);
        yield return new WaitUntil(() => theNumber.activated);
    }
}
