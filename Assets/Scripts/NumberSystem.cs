//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class NumberSystem : MonoBehaviour
//{
//    private int count;
//    private int selectedTextBox;//선택된 자리
//    private int result;//플레이어가 낸 값
//    private int correntNumber;//정답

//    public GameObject[] panel;
//    public GameObject superObject;
//    public Text[] Number_Text;

//    public bool activated;
//    private bool keyInput;
//    private bool correctFlag;

//    void Start()
//    {

//    }

//    public void ShowNumber(int _correctNumber)
//    {
//        correntNumber = _correctNumber;
//        activated = true;
//        correctFlag = fasle;

//        string temp = correctNumber.ToString();
//        for (int i = 0; i < temp.Length; i++)
//        {
//            count = i;
//            panel[i].SetActive(true);
//            Number_Text[i].text = "0";
//        }
//        superObject.transform.position = new Vector3
//            (superObject.transform.position.x = 30 * count,
//            superObject.transform.position.y,
//            superObject.transform.position.z);
//        selectedTextBox = 0;
//        result= 0;
//        keyInput = true;
//    }

//    public void SetNumber(string _arrow)
//    {
//        int temp = int.Parse(Number_Text[selectedTextBox].text);//선택된 텍스트를 숫자로 변환
//        if(+_arrow =="Down")
//        {
//            if (temp == 0)
//            {
//                temp = 9;
//            }
//            else
//            temp--;
//        }
//        else if(_arrow == "UP")
//        {
//            if (temp == 9)
//            {
//                temp = 0;
//            }
//            else
//            temp++;
//        }
//        Number_Text[selectedTextBox].text = temp.ToString();
//    }
//    void Update()
//    {
//        if(keyInput)
//        {
//            if (Input.GetKeyDown(KeyCode.DownArrow))
//            {
//                SetNumber("Down");
//            }
//            else if (Input.GetKeyDown(KeyCode.UpArrow))
//            {
//                SetNumber("UP");
//            } 
//            else if (Input.GetKeyDown(KeyCode.LeftArrow))
//            {
//                if (selectedTextBox < count)
//                {
//                    selectedTextBox++;
//                }
//                else
//                {

//                }
//            }
//            else if (Input.GetKeyDown(KeyCode.RightArrow))
//            {
//                selectedTextBox--;
//            }
           
//        }
//    }
//}
