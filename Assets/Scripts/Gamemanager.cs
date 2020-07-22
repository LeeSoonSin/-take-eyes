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
    public bool isAction;
    public int talkIndex;
    public GameObject player;
    static public Gamemanager instance;

    void Start()
    {
        //GameLoad();
        if (instance != null)
        {
            Destroy(this.gameObject);
            Destroy(this.talkText);

        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            DontDestroyOnLoad(this.talkText);


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
