//using System.Collections;
//using System.Collections.Generic;
//using System.Runtime.InteropServices;
//using UnityEngine;

//public class MovingObject : MonoBehaviour
//{

//    public string characterName;
//    public float speed;
//    public int walkCount;
//    public int currentWalkCount;

//    protected bool npcCanMove = true ;  

//    protected Vector3 vector;

//    public Queue<string> queue;
//    //선입선출 자료.
//    public BoxCollider2D boxcollider;
//    public LayerMask layerMask;
//    public Animator animator;


//    public  void Move(string _dir, int _frequency =5)
//    {
//        StartCoroutine(MoveCoroutine(_dir, _frequency));
//    }

//    IEnumerator MoveCoroutine(string _dir,int  _frequency)
//    {
//        npcCanMove = false;
//        vector.Set(0, 0, vector.z);
//        switch(_dir)
//        {
//            case "UP":
//                vector.y = 1f;
//                break;
//            case "DOWN":
//                vector.y = -1f;
//                break;
//            case "RIGHT":
//                vector.x = 1f;
//                break;
//            case "LEFT":
//                vector.x = -1f;
//                break;
//        }
//        animator.SetFloat("DirX", vector.x);
//        animator.SetFloat("DirY", vector.y);
//        animator.SetBool("Walking", true);

//        while (currentWalkCount < walkCount)
//        {
//            transform.Translate(vector.x * speed,vector.y * speed,0);
//            currentWalkCount++;
//            yield return new WaitForSeconds(0.01f);
//        }
//        currentWalkCount = 0;
//        if(_frequency !=5)
//        {
//            animator.SetBool("Walking", false);
//        }
//        npcCanMove = true;
//    }
//} 
