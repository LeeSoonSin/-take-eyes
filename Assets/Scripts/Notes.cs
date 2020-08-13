using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public int itemID;
    public GameObject Day_2;
    bool activeNote = false;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            activeNote = !activeNote;
            Day_2.SetActive(activeNote);
        }
    }

}
