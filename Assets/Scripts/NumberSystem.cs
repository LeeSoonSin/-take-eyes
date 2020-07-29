﻿using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberSystem : MonoBehaviour
{
    private int count; //배열의 크기 수
    private int selectedTextBox; //선택된 자릿수
    private int result;// 플레이어가 도출해낸 값
    private int correctNumber; //비밀번호 정답

    private string tempNumber;

    public GameObject superObject; // 
    public GameObject[] panel;
    public Text[] Number_Text;

    public Animator anim;

    public bool activated; //대기
    private bool keyInput; // 키 활성화 여부
    private bool correctFlag; // 정답확인
    public int Text_line; // 텍스트 간격 설정

    private void Start()
    {

    }
    public void ShowNumber(int _correctNumber)
    {
        correctNumber = _correctNumber;
        activated = true;
        correctFlag = false;

        string temp = correctNumber.ToString(); // 문자열로 변경 count에 넣기 위함
        for (int i = 0; i < temp.Length; i++)
        {
            count = i;
            panel[i].SetActive(true);
            Number_Text[i].text = "0";
        }
        superObject.transform.position = new Vector3(
            superObject.transform.position.x + (Text_line * count),
            superObject.transform.position.y,
            superObject.transform.position.z);

        selectedTextBox = 0;
        result = 0;
        SetColor();
        anim.SetBool("Appear", true);
        keyInput = true;
    }

    public bool GetResult()
    {
        return correctFlag;
    }


    public void SetColor()
    {
        Color color = Number_Text[0].color;
        color.a = 0.3f;
        for (int i = 0; i <= count; i++)
        {
            Number_Text[i].color = color;
        }
        color.a = 1f;
        Number_Text[selectedTextBox].color = color;

    }
    public void SetNumber(string _arrow)
    {
        int temp = int.Parse(Number_Text[selectedTextBox].text);
        //선택된 자리의 수의 텍스트를 숫자형식으로 강제 형변환
        if (_arrow == "Down")
        {
            if (temp == 0)
            {
                temp = 9;
            }
            else
            {
                temp--;
            }
        }
        else if (_arrow == "Up")
        {
            if (temp == 9)
            {
                temp = 0;
            }
            else
            {
                temp++;
            }
        }
        Number_Text[selectedTextBox].text = temp.ToString();
    }
    private void Update()
    {
        if (keyInput)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SetNumber("Down");
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                SetNumber("Up");
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (selectedTextBox < count)
                {
                    selectedTextBox++;
                }
                else
                {
                    selectedTextBox = 0;//0이 첫번째 자리
                }
                SetColor();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (selectedTextBox > 0)
                {
                    selectedTextBox--;
                }
                else
                {
                    selectedTextBox = count;
                }
                SetColor();
            }
            else if (Input.GetKeyDown(KeyCode.Z))//결정키
            {
                keyInput = false;
                StartCoroutine(OXCoroutine());
            }
            else if (Input.GetKeyDown(KeyCode.X))//취소키
            {
                keyInput = false;
                StartCoroutine(ExitCoroutine());
            }

        }
    }

    IEnumerator OXCoroutine()
    {
        Color color = Number_Text[0].color;
        color.a = 1f;

        for (int i = count; i >= 0; i--)
        {
            Number_Text[i].color = color;
            tempNumber += Number_Text[i].text;
        }
        yield return new WaitForSeconds(1f);

        result = int.Parse(tempNumber);

        //정답 판별
        if (result == correctNumber)
        {
            correctFlag = true;
        }
        else
        {
            correctFlag = false;
        }
        StartCoroutine(ExitCoroutine());
    }
    IEnumerator ExitCoroutine()
    {
        result = 0;
        tempNumber = "";
        anim.SetBool("Appear", false);

        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i <= count; i++)
        {
            panel[i].SetActive(false);
        }
        superObject.transform.position = new Vector3(
            superObject.transform.position.x - (Text_line * count),
            superObject.transform.position.y,
            superObject.transform.position.z);

        activated = false;
    }
}