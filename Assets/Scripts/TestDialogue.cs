using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogue : MonoBehaviour
{
    [SerializeField]
    public Dialogue dialogue;
    public int DataNum;
    private DialogueManager theDM;
    public DataBase thedata;
    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        thedata = FindObjectOfType<DataBase>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && thedata.switches[DataNum] == false)
        {
            theDM.ShowDialogue(dialogue);
            thedata.switches[DataNum] = true;
        }
    }
}
