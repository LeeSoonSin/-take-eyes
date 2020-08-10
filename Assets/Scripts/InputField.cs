using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputField : MonoBehaviour
{
    public Text text;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log(text.text);
            Destroy(this.gameObject);
             
        }
    }
}
