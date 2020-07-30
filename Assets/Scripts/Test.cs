using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private NumberSystem theNumber;

    public bool flag;
    public int correctNumber;
    private void Start()
    {
        theNumber = FindObjectOfType<NumberSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!flag)
        {
            StartCoroutine(ACoroutine());
        }
    }
    IEnumerator ACoroutine()
    {
        flag = true;
        theNumber.ShowNumber(correctNumber);
        yield return new WaitUntil(() => theNumber.activated);
    }
}
