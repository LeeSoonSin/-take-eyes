using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap : MonoBehaviour
{
    public string transferMapName;//이동할 맵 이름
    public int MapNumber;//이동할 맵의 번호
    private PlayerMove thePlayer;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")//콜라이더 에 닿은게 플레이어 라면...
        {
            thePlayer.currentMapName = transferMapName;
            thePlayer.MapNum = MapNumber;
            SceneManager.LoadScene(transferMapName);
        }
    }
}
