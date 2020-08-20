using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartCredit : MonoBehaviour
{
    public GameObject go;
    void Update()
    {
        go.SetActive(true);
        new WaitForSeconds(10000f);
        SceneManager.LoadScene("Classroom_2");
    }
}
