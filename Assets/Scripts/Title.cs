﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public void GameStart()
    {
         SceneManager.LoadScene("3F_Hall");
    }
}
