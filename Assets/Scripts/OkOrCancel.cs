using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OkOrCancel : MonoBehaviour //4분 50초
{

    public GameObject up_Panel;
    public GameObject dowm_Panel;

    public Text up_Text;
    public Text down_Text;

    public bool activated;
    private bool keyInput;
    private bool result = true; //소비했는데 선택하겠냐 true 아니다 false





    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Selected()
    {
        result = !result;
        if (result)
        {
            up_Panel.gameObject.SetActive(false);
            dowm_Panel.gameObject.SetActive(true);
        }
        else
        {
            up_Panel.gameObject.SetActive(true);
            dowm_Panel.gameObject.SetActive(false);
        }
    }

    public void ShowTwoChoice(string _upText, string _downText)
    {
        activated = true;
        result = true;
        up_Text.text = _upText;
        down_Text.text = _downText; 

        up_Panel.gameObject.SetActive(false);
        dowm_Panel.gameObject.SetActive(true);

        StartCoroutine(ShowTwoChoiceCoroutine());
    }

    public bool GetResult()
    {
        return result;
    }

    IEnumerator ShowTwoChoiceCoroutine()
    {
        yield return new WaitForSeconds(0.01f);
        keyInput = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (keyInput)
        {
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                Selected();
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Selected();
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                keyInput = false;
                activated = false;
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                keyInput = false;
                activated = false;
                result = false;
            }
        }
    }
}
