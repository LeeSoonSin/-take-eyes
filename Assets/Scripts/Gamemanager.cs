using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public GameObject talkPanel;
    public TalkManager talkManager;
    public Text talkText;
    public GameObject scanObject;
    public GameObject menuSet;
    public GameObject Inventory;
    public GameObject Number_System;
    public bool isAction;
    public int talkIndex;
    public GameObject player;
    static public Gamemanager instance;

    void Start()
    {
        //GameLoad();
        if (instance != null)
        {
            Destroy(this.talkPanel);
            Destroy(this.gameObject);
            Destroy(this.talkText);
            Destroy(this.Inventory);


        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            DontDestroyOnLoad(this.talkText);
            DontDestroyOnLoad(this.Inventory);
            DontDestroyOnLoad(this.talkPanel);

            instance = this;
        }
    }
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

    public void StartAction()
    {
        isAction = false;
    }
    public void StopAction()
    {
        isAction = true;
    }
    public void Action(GameObject scanObj) //18분 33초
    {
        if(isAction)
        {
            isAction = false;
        }
        else
        {
            isAction = true;
            scanObject = scanObj;
            ObjData objData = scanObject.GetComponent<ObjData>();
            Talk(objData.id, objData.isNPC);
        }
        talkPanel.SetActive(isAction);

        //(밑에가 원래 있던거 위에는 영상보고 바꾼거)
            /*isAction = true;
            scanObject = scanObj;
            ObjData objData = scanObject.GetComponent<ObjData>();
            Talk(objData.id, objData.isNPC);
        
        talkPanel.SetActive(isAction);*/
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
    private static Gamemanager _instance;
    public static Gamemanager Instance
    {
        get
        {
            if(_instance ==null)
            {
                _instance = FindObjectOfType<Gamemanager>();
            }
            return _instance;
        }
    }

    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.Save();
        menuSet.SetActive(false);
    }

    //public void GameLoad()
    //{
    //    if(PlayerPrefs.HasKey("PlayerX"))
    //    {
    //        return;
    //    }
    //    float x =PlayerPrefs.GetFloat("PlayerX");
    //    float y= PlayerPrefs.GetFloat("PlayerY");
    //    player.transform.position = new Vector3(x, y, 0);
    //}
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
