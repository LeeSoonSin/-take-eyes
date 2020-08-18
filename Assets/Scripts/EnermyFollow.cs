using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyFollow : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;

    private Transform target;
    Animator anim;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            anim.SetBool("isWalking", true);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, target.position) < stoppingDistance)//내가 추가한 부분
        {
            anim.SetBool("isWalking", false);
            //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

    }
}
