using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question_Test : MonoBehaviour
{
    [SerializeField]
    public InputField answer;

    public bool flag;
    public int correctNumber;
    private void Start()
    {
        answer = FindObjectOfType<InputField>();
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
        answer.StartAnswer();
        yield return new WaitUntil(() => !answer.choicelng);
        Debug.Log(answer.text.text);
    }
}
