using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public float Door_Num;
    public bool Door_Move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Door_Active()
    {
        Door_Move = true;
        if(Door_Move == true)
        {
            Debug.Log("문이 열립니다.");
        }
    }
    public void OpenDoor()
    {
        if(Door_Move == true)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        OpenDoor();
    }
}
