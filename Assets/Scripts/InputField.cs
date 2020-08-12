using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputField : MonoBehaviour
{
    public GameObject go;
    public Animator anim;
    public Text text;
    public bool choicelng;
    void Start()
    {
        
    }
    public void StartAnswer()
    {
        go.SetActive(true);
        anim.SetBool("Appear", true);
    }
    public void EndAnswer()
    {
        anim.SetBool("Appear", false);
        go.SetActive(false);
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
