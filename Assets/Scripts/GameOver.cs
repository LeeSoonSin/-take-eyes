using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void Update()
    {
       if(Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("3F_Hall");
        }
    }
}
