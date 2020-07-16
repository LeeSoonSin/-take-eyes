using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public GameObject talkPanel;
    public TalkManager talkManager;
    public Text talkText;
    public GameObject scanObject;
    public GameObject menuSet;
    public bool isAction;
    public int talkIndex;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if(menuSet.activeSelf)
            {
                menuSet.SetActive(false);
            }
            else
            {
                menuSet.SetActive(true);
            }
        }
    }

    public void Action(GameObject scanObj)
    {
            isAction = true;
            scanObject = scanObj;
            ObjData objData = scanObject.GetComponent<ObjData>();
            Talk(objData.id, objData.isNPC);
        
        talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNPC)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }
        if (isNPC)
        {
            talkText.text = talkData;
        }
        else
        {
            talkText.text = talkData;
        }

        isAction = true;
        talkIndex++;
    }

    public void GameExit()
    {
        Application.Quit();
    }

}
