using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number_Check : MonoBehaviour
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
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(ACoroutine());
        }
    }
    IEnumerator ACoroutine()
    {
        theNumber.ShowNumber(correctNumber);
        yield return new WaitUntil(() => theNumber.activated);
    }
}
