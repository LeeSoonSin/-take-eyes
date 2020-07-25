using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap : MonoBehaviour
{
    //이동할 맵의 이름 설정
    public string transferMapName;

    private PlayerMove thePlayer;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            thePlayer.currentMapName = transferMapName;
            SceneManager.LoadScene(transferMapName);
        }
    }
}
