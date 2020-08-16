using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject go;
    private bool activated;

    public Gamemanager manager;

    public void Start()
    {
        manager= FindObjectOfType<Gamemanager>();
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Continue()
    {
        activated = false;
        go.SetActive(false);    
    }
    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
        {
            activated = !activated;
            if(activated)
            {
                go.SetActive(true);
                manager.StopAction();
            }
            else
            {
                go.SetActive(false);
                manager.StartAction();
            }

        }
    }
}
