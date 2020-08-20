using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer_Test : MonoBehaviour
{
    [SerializeField]
    public Choice choice;
    private ChoiceManager theChoice;

    public bool flag;
    public int correctNumber;
    private void Start()
    {
        theChoice = FindObjectOfType<ChoiceManager>();
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
        theChoice.ShowChoice(choice);
        yield return new WaitUntil(() => !theChoice.choicelng);
        Debug.Log(theChoice.GetResult());
    }
}
