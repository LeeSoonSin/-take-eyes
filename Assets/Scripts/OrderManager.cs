//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class OrderManager : MonoBehaviour
//{
//    private PlayerMove thePlayer;
//    private List<MovingObject> characters;
//    void Start()
//    {
//        thePlayer = FindObjectOfType<PlayerMove>();
//    }

//    void PreLoadCharacter()
//    {
//        characters = ToList();
//    }
//    public void NotMove()
//    {

//    }

//    public void Move()
//    {
//        thePlayer.notMove = false;
//    }
//    public List<MovingObject> ToList()
//    {
//        List<MovingObject> tempList = new List<MovingObject>();
//        MovingObject[] temp = FindObjectsOfType<MovingObject>();

//        for(int i =0; i < temp.Length; i++)
//        {
//            tempList.Add(temp[i]);
//        }
//        return tempList;
//    }

//    public void Move(string _name,string _dir)
//    {
//     for(int i = 0; i < characters.Count; i++)
//        {
//            if (_name == characters[i].characterName)
//            {
//                characters[i].Move(_dir);
//            }
//        }
//    }
//    void Update()
//    {
        
//    }
//}
