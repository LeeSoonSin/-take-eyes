using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public float Door_Num;
    public int Door_Code;
    public bool Door_Lock;
    public DataBase thedata;
    // Start is called before the first frame update
    void Awake()
    {
        thedata = FindObjectOfType<DataBase>();
    }
    public void Start()
    {
        if(thedata.switches[Door_Code] == true)
        {
            gameObject.SetActive(false);
        }
    }

    //public void Door_Active()
    //{
    //    Door_Move = true;
    //    if(Door_Move == true)
    //    {
    //        Debug.Log("문이 열립니다.");
    //    }
    //}
    public void OpenDoor(int A)
    {
        if( A == Door_Num)
        {
            Debug.Log("문이 열립니다.");
            gameObject.SetActive(false);
            thedata.switches[Door_Code] = true;
        }
    }

    //void Update()
    //{
    //    OpenDoor();
    //}
}
