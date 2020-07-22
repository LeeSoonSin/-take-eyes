using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Button : MonoBehaviour
{
    public MainButton currentType;
    public void OnBtnClick()
    {
        switch (currentType)
        {
            case MainButton.New:
                print("새게임");
                break;
            case MainButton.Continue:
                print("이어하기");
                break;
            case MainButton.Quit:
                print("끝내기");
                break;

        }
    }
}
