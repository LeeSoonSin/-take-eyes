using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string startpoint; //이동되어온 맵 이름 체크
    private PlayerMove thePlayer; // 캐릭터 객체를 가져옴
    public int StartNum;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
        if (startpoint == thePlayer.currentMapName)
        {
            if (StartNum == thePlayer.MapNum)
            {
                thePlayer.transform.position = this.transform.position;
            }
        }
    }
}
