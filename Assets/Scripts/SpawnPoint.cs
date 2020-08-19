using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private PlayerMove thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    public void Spawn()
    {
            thePlayer.transform.position = this.transform.position;
            thePlayer.gameObject.SetActive(true);
    }
}
