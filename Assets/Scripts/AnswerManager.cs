using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerManager : MonoBehaviour
{
    public GameObject go;
    public Animator anim;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
