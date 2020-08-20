using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyMob : MonoBehaviour
{
    public static FlyMob instance;
    public DataBase thedata;
    public int datanum;
    // Start is called before the first frame update
    void Start()
    {
        thedata = FindObjectOfType<DataBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if(thedata.switches[datanum] == true)
        {
            gameObject.SetActive(false);
        }
    }

    public void MopActive()
    {
        Debug.Log("작동중");
        thedata.switches[datanum] = true;
        gameObject.SetActive(false);
    }   
}
