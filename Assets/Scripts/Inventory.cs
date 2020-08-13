using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Build.Reporting;
using UnityEngine ;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    private OkOrCancel theOOC;
    static public Inventory instance;
    private DataBase dataBase;
    private Gamemanager manager;
    private InventorySlot[] slots;//인벤토리 슬롯들
    public List<Item> inventoryItemList;//플레이어가 소지한 아이템 리스트
    private List<Item> inventoryTabList; //선택한 탭에 따라 다르게 보여질 아이템 리스트

    public Text Description_Text; //부연설명
    public string[] tabDescription;// 탭 부연 설명

    public Transform tf; //slot 부모객체 (Grid Slot)

    public GameObject go; //인벤토리 활성화/ 비활성화
    public GameObject[] selectedTabImages;
    public GameObject go_OOC; //선택지 활성화 비활성화

    private int selectedItem; //선택된 아이템.
    private int selectedTab; //선택된 탭.

    private bool activated; //인벤토리 활성화시 true
    private bool tabActivated; //탭 활성화시 true
    private bool itemActivated; //아이템 활성화시 true 
    private bool stopKeyInput; //키 입력 제한(소비할 때 질문나온다. 그때 키 입력방지)
    private bool preventExec; //중복실행 제한.

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);


    //싱글턴 
    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
            dataBase = FindObjectOfType<DataBase>();
            manager = FindObjectOfType<Gamemanager>();
            stopKeyInput = false;
            theOOC = FindObjectOfType<OkOrCancel>();

            inventoryItemList = new List<Item>();
            inventoryTabList = new List<Item>();
            slots = tf.GetComponentsInChildren<InventorySlot>();
        }

        //여기에 시작하자마자 쓸 수 있는 아이템을 추가할 수 있다.
        // ex) inventoryItemList.Add(new Item(10001, "열쇠", "어딘가의 문을 열 열쇠", Item.ItemType.Use));
    }//완벽(1)

    // Update is called once per frame

    public void GetAnItem(int _itemID, int _count = 1)
    {
        for(int i=0; i < dataBase.itemList.Count; i++)//데이터베이스 아이템 검색
        {
            if(_itemID == dataBase.itemList[i].itemID)//데이터베이스에 아이템 발견
            {
                for(int j=0; j<inventoryItemList.Count; j++)//소지품에 같은 아이템이 있는지 검색
                {
                    if(inventoryItemList[j].itemID == _itemID)//소지품에 같은 아이템이 있다. ->개수만 증감시켜줌
                    {
                        if(inventoryItemList[i].itemType == Item.ItemType.Use)
                        {
                            inventoryItemList[j].itemCount += _count;
                            return;
                        }
                        else
                        {
                            inventoryItemList.Add(dataBase.itemList[i]);
                        }
                        return;
                    }
                }
                inventoryItemList.Add(dataBase.itemList[i]);//소지품에 해당아이템 추가
                inventoryItemList[inventoryItemList.Count - 1].itemCount = _count;
                return;
            }
        }
        Debug.LogError("데이터베이스에 해당 ID값을 가진 아이템이 존재하지 않습니다.");//데이터베이스에 itemID없음
    }
    public void RemoveSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveItem();// 아이템창에 빈 아이템이 안보이게 하는 역할이다.
            slots[i].gameObject.SetActive(false);
        }
    }//인벤토리 슬롯 초기화 완벽(2)

    public void ShowTab()
    {
        RemoveSlot();
        SelectedTab();
    } //탭 활성화

    public void SelectedTab()
    {
        StopAllCoroutines(); //이거 
        Color color = selectedTabImages[selectedTab].GetComponent<Image>().color;
        color.a = 0f;
        for(int i=0;i<selectedTabImages.Length; i++)
        {
            selectedTabImages[i].GetComponent<Image>().color = color;
        }
        Description_Text.text = tabDescription[selectedTab];//이걸 통해서 소모품 같은것들의 설명이 출력
        StartCoroutine(SelectedTabEffectCoroutine());
    } //선택된 탭을 제외하고 다른 모든 탭의 컬러 알파값을 0으로 조정. 완벽(3)
    IEnumerator SelectedTabEffectCoroutine()
    {
        while(tabActivated)
        {
            Color color = selectedTabImages[0].GetComponent<Image>().color;
            while(color.a<0.5f)
            {
                color.a += 0.03f;
                selectedTabImages[selectedTab].GetComponent<Image>().color = color;
                yield return waitTime;
            }
            while (color.a > 0f)
            {
                color.a -= 0.03f;
                selectedTabImages[selectedTab].GetComponent<Image>().color = color;
                yield return waitTime;
            }
            yield return new WaitForSeconds(0.3f);
        }
    } //선택된 탭 반짝임 효과  완벽(3-1)

    public void ShowItem()
    {
        inventoryTabList.Clear();
        RemoveSlot();
        selectedItem = 0;

        switch(selectedTab)
        {
            case 0: //소모품의 경우
                for(int i=0; i< inventoryItemList.Count;i++)
                {
                    if(Item.ItemType.Use==inventoryItemList[i].itemType)
                    {
                        inventoryTabList.Add(inventoryItemList[i]);
                    }
                }
                break;
            case 1: //장비의 경우
                for (int i = 0; i < inventoryItemList.Count; i++)
                {
                    if (Item.ItemType.Equip == inventoryItemList[i].itemType)
                    {
                        inventoryTabList.Add(inventoryItemList[i]);
                    }
                }
                break;
            case 2: //퀘스트의 경우
                for (int i = 0; i < inventoryItemList.Count; i++)
                {
                    if (Item.ItemType.Quest == inventoryItemList[i].itemType)
                    {
                        inventoryTabList.Add(inventoryItemList[i]);
                    }
                }
                break;
            case 3: //기타의 경우
                for (int i = 0; i < inventoryItemList.Count; i++)
                {
                    if (Item.ItemType.ETC == inventoryItemList[i].itemType)
                    {
                        inventoryTabList.Add(inventoryItemList[i]);
                    }
                }
                break;
        }//탭에 따른 아이템 분류, 그것을 인벤토리 탭 리스트에 추가
        for(int i =0; i<inventoryTabList.Count;i++)
        {
            slots[i].gameObject.SetActive(true);
            slots[i].Additem(inventoryTabList[i]);
        }//인벤토리 탭 리스트의 내용을 인벤토리 슬롯에 추가
        SelectedItem(); //선택된것만 반짝거릴수 있게
    }  //아이템 활성화 (InventoryTabList에 조건에 맞는 아이템들만 넣어주고, 인벤토리 슬롯에 출력)
    public void SelectedItem()
    {
        StopAllCoroutines();
        if(inventoryTabList.Count > 0)
        {
            Color color = slots[0].selected_Item.GetComponent<Image>().color;
            color.a = 0f;
            for(int i=0;i<inventoryTabList.Count;i++)
            {
                slots[i].selected_Item.GetComponent<Image>().color = color;
            }
            Description_Text.text = inventoryTabList[selectedItem].itemDescription;
            StartCoroutine(SelectedItemEffectCoroutine());
        }
        else
        {
            Description_Text.text = "해당 타입의 아이템을 소유하고 있지 않습니다.";
        }
    }//선택된 아이템을 제외하고, 다른 모든 탭의 컬러 알파값을 0으로 조정.

    IEnumerator SelectedItemEffectCoroutine()
    {
        while (itemActivated)
        {
            Color color = slots[0].GetComponent<Image>().color;
            while (color.a < 0.5f)
            {
                color.a += 0.03f;
                slots[selectedItem].selected_Item.GetComponent<Image>().color = color;
                yield return waitTime;
            }
            while (color.a > 0f)
            {
                color.a -= 0.03f;
                slots[selectedItem].selected_Item.GetComponent<Image>().color = color;
                yield return waitTime;
            }
            yield return new WaitForSeconds(0.3f);
        }
    } //선택된 아이템 반짝임 효과.

    void Update()
    {
        if (!stopKeyInput)
        {
            
            if(Input.GetKeyDown(KeyCode.S))//S키를 누를경우 
            {
                activated = !activated; //true면 false로 false면 true로 바꿔줌
                if (activated)
                {
                    manager.StopAction();
                    go.SetActive(true);
                    selectedTab = 0;
                    tabActivated = true;
                    itemActivated = false;
                    ShowTab();
                }
                else
                {
                    manager.StartAction();
                    StopAllCoroutines();
                    go.SetActive(false);
                    tabActivated = false;
                    itemActivated = false;
                }
            }

            if (activated)
            {
                if (tabActivated)
                {
                    if(Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        if(selectedTab < selectedTabImages.Length -1)
                        {
                            selectedTab++;
                        }
                        else
                        {
                            selectedTab = 0;
                        }
                        SelectedTab();
                    }//38분 30초 
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        if (selectedTab >0)
                        {
                            selectedTab--;
                        }
                        else
                            selectedTab = selectedTabImages.Length - 1;
                        SelectedTab();
                    }
                    else if (Input.GetButtonDown("Jump")) //결정키
                    {
                        Color color = selectedTabImages[selectedTab].GetComponent<Image>().color;
                        color.a = 0.25f;
                        selectedTabImages[selectedTab].GetComponent<Image>().color = color;
                        itemActivated = true;
                        tabActivated = false;
                        preventExec = true;
                        ShowItem();
                    }
                }//탭 활성화시 키입력처리.
               
                else if(itemActivated)
                {
                    if (Input.GetKeyDown(KeyCode.DownArrow))//53분
                    {
                        if (selectedItem < inventoryTabList.Count - 2)
                        {
                            selectedItem+=2;
                        }
                        else
                        {
                            selectedItem %= 2;
                        }
                        SelectedItem();
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        if (selectedItem < 1)
                        {
                            selectedItem -= 2;
                        }
                        else
                        {
                            selectedItem =inventoryTabList.Count - 1 - selectedItem;
                        }
                        SelectedItem();
                    }
                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        if(selectedItem < inventoryTabList.Count -1)
                        {
                            selectedItem ++;
                        }
                        else
                        {
                            selectedItem = 0;   
                        }
                        SelectedItem();
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
                        SelectedItem();
                    }
                    else if (Input.GetKeyDown(KeyCode.Z) && !preventExec)
                    {
                        if(selectedTab ==0)//소모품
                        {
                            stopKeyInput = true;
                            StartCoroutine(OOCCoroutine());
                            //물약을 마실거냐? 같은 선택지 호출
                        }
                        else if(selectedTab ==1)
                        {
                            //장비 장착
                        }
                        else//비프음 출력
                        {
                            Debug.Log("음악이 업서요 ㅜㅜ");
                        }
                        
                    }
                    else if (Input.GetKeyDown(KeyCode.X))
                    {
                        StopAllCoroutines();
                        itemActivated = false;
                        tabActivated = true;
                        ShowTab();
                    }
                } //아이템 활성화시 키입력 처리

                if (Input.GetButtonDown("Jump"))
                {
                    preventExec = false;
                    ShowItem();
                }
            }
        }
    }

    IEnumerator OOCCoroutine()
    {
        go_OOC.SetActive(true);
        theOOC.ShowTwoChoice("사용한다", "취소한다");
        yield return new WaitUntil(() => !theOOC.activated);
        if (theOOC.GetResult())
        {
            for (int i = 0; i < inventoryItemList.Count; i++)
            {
                if (inventoryItemList[i].itemID == inventoryTabList[selectedItem].itemID)
                {
                    dataBase.UseItem(inventoryItemList[i].itemID);
                    if (inventoryItemList[i].itemCount > 1)
                    {
                        inventoryItemList[i].itemCount--;
                    }
                    else
                    {
                        inventoryItemList.RemoveAt(i);
                    }
                    ShowItem();
                    break;
                }
            }
        }
        stopKeyInput = false;
        go_OOC.SetActive(false);
    }
}
