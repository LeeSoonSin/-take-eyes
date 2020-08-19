using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDialogue : MonoBehaviour
{
    public Dialogue dialogue_1;
    public int DataNum;
    private DialogueManager theDM;
    public DataBase thedata;
    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        thedata = FindObjectOfType<DataBase>();
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKey(KeyCode.Z) && thedata.switches[DataNum] == false)
        {
            theDM.ShowDialogue(dialogue_1);
            thedata.switches[DataNum] = true;
        }
    }
}
