using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//인벤토리의 사진, 이름, 개수를 수정하는 창
public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Text itemName_Text;
    public Text itemCount_Text;
    public GameObject selected_Item; //반짝이는 효과
    
    public void Additem(Item _item)//아이템 추가하는 곳
    {
        itemName_Text.text = _item.itemName;
        icon.sprite = _item.itemIcon;
        if(Item.ItemType.Use == _item.itemType)//소모품일 경우 아이템 수량 표시
        {
            if(_item.itemCount > 0)
            {
                itemCount_Text.text = "x " + _item.itemCount.ToString();
            }
            else
            {
                itemCount_Text.text = ""; //한개가 없으면 빈 목록
            }
        }

    }
    public void RemoveItem()//아이템 없애는 곳
    {
        itemCount_Text.text = "";
        itemName_Text.text = "";
        icon.sprite = null;

    }
}
