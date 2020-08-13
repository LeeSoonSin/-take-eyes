using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public int itemID;
    public GameObject Day_2;
    //bool activeNote = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
            if (Input.GetButtonDown("Jump"))
            {
                Day_2.SetActive(true);
            }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Day_2.SetActive(false);
        }
    }
}
