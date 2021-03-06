﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;
    static public TalkManager instance;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GernerateData();

        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }

    }

    // Update is called once per frame
    public void GernerateData()
    {

        talkData.Add(1008, new string[] { "문이 열리지 않아;;:1", "열쇠 복도에 있던데:2", "그래? 한번 가보자:0" });
        talkData.Add(2000, new string[] { "문이 열리지 않아;;:1", "3층 어딘가에 있을 거야:2", "안 둘러본 곳이 있나?:0" });
        talkData.Add(3000, new string[] { "진로실 문이 잠겨있어..:3", "어:2", "그래? 한번 가보자:0" });
        talkData.Add(12, new string[] { "나는 빡빡이다","나는 빡빡이다!!!" });
        talkData.Add(11, new string[] 
        { 
            "영인아:0",
            "교실에 있었구나. 애들은 체육수업이라 다들 나간거야?:0",
            "나도 방금 일어나서 모르겠어. 일단 나가보자:2",
            "그래! 같이 가자!:0",
            "영인이와 동행하게 되었다.:5"
        });
        talkData.Add(1, new string[] { "오래된 칠판이다. 분필자국이 아직 남아있다." });


        portraitData.Add(1008 + 0, portraitArr[0]);//주인공 기본포즈
        portraitData.Add(1008 + 1, portraitArr[1]);//주인공 당황
        portraitData.Add(1008 + 2, portraitArr[2]);//친구
        portraitData.Add(2000 + 0, portraitArr[0]);//주인공 기본포즈
        portraitData.Add(2000 + 1, portraitArr[1]);//주인공 당황
        portraitData.Add(2000 + 2, portraitArr[2]);//친구
        portraitData.Add(2000 + 3, portraitArr[3]);//친구 화남
        portraitData.Add(3000 + 0, portraitArr[0]);//주인공 기본포즈
        portraitData.Add(3000 + 1, portraitArr[1]);//주인공 당황
        portraitData.Add(3000 + 2, portraitArr[2]);//친구
        portraitData.Add(3000 + 3, portraitArr[3]);//친구 화남
        portraitData.Add(11 + 0, portraitArr[0]);//주인공 기본포즈
        portraitData.Add(11 + 2, portraitArr[2]);//친구
        portraitData.Add(11 + 5, portraitArr[5]);//시스템 메세지

    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
        {
            return talkData[id][talkIndex];
        }
    }
    public Sprite GetPortrait (int id, int PortraitIndex)
    {
        return portraitData[id + PortraitIndex];
    }

}