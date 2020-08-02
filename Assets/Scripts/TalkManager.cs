using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    static public TalkManager instance;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
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
    void GernerateData()
    {
        talkData.Add(12, new string[] { "나는 빡빡이다",
            "나는 빡빡이다!!!" });
        talkData.Add(1, new string[] { "오래된 칠판이다. 분필자국이 아직 남아있다." });
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

}