using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//인벤토리의 사진, 이름, 개수를 수정하는 창
public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Text itemName_Text;
    public GameObject selected_Item; //반짝이는 효과
    
    public void Additem(Item _item)//아이템 추가하는 곳
    {
        itemName_Text.text = _item.itemName;
        icon.sprite = _item.itemIcon;


    }
    public void RemoveItem()//아이템 없애는 곳
    {
        itemName_Text.text = "";
        icon.sprite = null;

    }
}
