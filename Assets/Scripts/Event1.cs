using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

public class Event1 : MonoBehaviour
{

    public Dialogue dialogue_1;
    public Dialogue dialogue_2;

    private DialogueManager theDM;
    private PlayerMove thePlayer; //플레이어 애니방향을 통해 애니이벤트 ㄱ
    private Gamemanager theOrder;

    private bool flag;
    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        theOrder = FindObjectOfType<Gamemanager>();
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!flag && Input.GetKey(KeyCode.Z))
        {
            flag = true;
            StartCoroutine(EventCoroutine());
        }
    }

    IEnumerator EventCoroutine()
    {
        //theOrder.PreLoadCharactor();
        theOrder.StopAction();
        yield return new WaitUntil(() => theDM.talking);//조건만족할때까지 안넘긴다.
        theDM.ShowDialogue(dialogue_1);
        //thePlayer.Update("hDown"); //움직임 구현 ㅠㅠㅠ
        yield return new WaitForSeconds(1f);

        theDM.ShowDialogue(dialogue_2);
        theOrder.StartAction();
    }
}
