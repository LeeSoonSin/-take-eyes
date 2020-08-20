using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartCredit : MonoBehaviour
{
    public GameObject go;
    public float timer;
    private int waitTime = 10;
    void Update()
    {
        go.SetActive(true);

        timer += Time.deltaTime;
            if(timer >=waitTime)
        {
            SceneManager.LoadScene("Classroom_2");
        }
    }
}
