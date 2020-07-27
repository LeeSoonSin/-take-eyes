using System.Collections;
using System.Collections.Generic;
using UnityEngine ;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    //private InventorySlot[] slots;//인벤토리 슬롯들인데 사용안함
    private List<Item> inventoryItemList;//플레이어가 소지한 아이템 리스트
    private List<Item> inventoryTabList; //선택한 탭에 따라 다르게 보여질 아이템 리스트

    public Text Description_Text; //부연설명
    public string[] tabDescription;// 탬 부연 설명

    public Transform tf; //slot 부모객체 (Grid Slot)
    public GameObject go; //인벤토리 활성화/ 비활성화
    private int selectedItem; //선택된 아이템.

    private bool activated; //인벤토리 활성화시 true
    private bool itemActivated; //아이템 활성화시 true 
    private bool stopKeyInput; //키 입력 제한(소비할 때 질문나온다. 그때 키 입력방지)
    private bool preventExec; //중복실행 제한.

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);



    // Start is called before the first frame update
    void Start()
    {
        stopKeyInput = false;
        inventoryTabList = new List<Item>();
    }

    // Update is called once per frame
    public void ShowItem()
    {
        selectedItem = 0;

        for (int i = 0; i < inventoryItemList.Count; i++)
        {
            if (Item.ItemType.Use == inventoryItemList[i].itemType)
            {
                inventoryTabList.Add(inventoryItemList[i]);
            }
        }
        
    }//탭에 따른 아이템 분류. 그것을 인벤ㅌ리 탭 리슽트에 추가
    



    void Update()
    {
        Debug.Log("하이");
        if (!stopKeyInput)
        {
            
            if(Input.GetKeyDown(KeyCode.S))//S키를 누를경우 인벤토리 열림
            {
                activated = !activated; //true면 false로 바꿔주고 false면 true로 바꿔줌

                if(activated)
                {
                    go.SetActive(true);
                    itemActivated = true;
                }
                else
                {
                    StopAllCoroutines();
                    go.SetActive(false);
                    itemActivated = false;
                }
            }

            if (activated)
            {
                if (itemActivated)
                {
                    
                }
                else if(itemActivated)
                {
                    
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        if(selectedItem < inventoryTabList.Count -1)
                        {
                            selectedItem ++;
                        }
                        else
                        {
                            selectedItem = 0;   
                        }
                    }
                    else if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        if (selectedItem > 0)
                        {
                            selectedItem --;
                        }
                        else
                        {
                            selectedItem = inventoryTabList.Count - 1;
                        }
                    }
                    else if (Input.GetKeyDown(KeyCode.Space))
                    {
                        stopKeyInput = true;
                        //물약을 마실거냐? 같은 선택지 호출
                        
                    }
                    else if (Input.GetKeyDown(KeyCode.X))
                    {
                        itemActivated = false;
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                preventExec = true;
                ShowItem();
            }
        }
    }
}
