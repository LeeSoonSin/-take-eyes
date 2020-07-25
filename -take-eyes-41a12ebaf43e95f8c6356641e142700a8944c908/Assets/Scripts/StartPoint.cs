using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string startpoint;
    private PlayerMove thePlayer;
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
        if(startpoint == thePlayer.currentMapName)
        {
            thePlayer.transform.position = this.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
