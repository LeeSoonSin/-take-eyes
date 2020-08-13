using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNote : MonoBehaviour
{
    public GameObject Day_2;
    bool activeNote = false;

    private void Start()
    {
        //Day_2.SetActive(activeNote);
    }

    private void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.I))
        {
            activeNote = !activeNote;
            Day_2.SetActive(activeNote);
        }*/
    }
}
