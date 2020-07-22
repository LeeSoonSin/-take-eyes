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
//        for(int i=0; i< temp.Length;i++)
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
//        result;T = 0;
//    }
//    void Update()
//    {
        
//    }
//}
