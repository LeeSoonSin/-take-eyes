using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public SpawnPoint spawn;

    public void Start()
    {
        spawn = FindObjectOfType<SpawnPoint>();
    }
    public void GameStart()
    {
         SceneManager.LoadScene("Classroom_2");



        spawn.Spawn();
    }
}
