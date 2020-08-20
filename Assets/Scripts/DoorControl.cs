using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public int Door_Num;
    public string DoorName;
    public int Door_Code;
    public static DoorControl instance1;
    
    void Awake()
    {
        instance1 = this;
    }
    public void Start()
    {
        if(DataBase.instance.switches[Door_Code] == true)
        {
            gameObject.SetActive(false);
        }
    }
    public void OpenDoor(int A)
    {
        Debug.Log("이 열쇠의 번호는" + A);
        Debug.Log("이 문의 번호는 " + Door_Num);
        if(A == Door_Num)
        {
            Debug.Log("문이 열립니다.");
            gameObject.SetActive(false);
            DataBase.instance.switches[Door_Code] = true;
            Debug.Log("데이터 베이스 입력됨");

        }
        else
        {
            Debug.Log("버그 입니다."); 
        }
    }
}
