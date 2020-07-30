using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    private int randomSpot;//랜덤값
    private float waitTime;
    public float startWaitTime;//몬스터가 대기하는 시간
    public Transform[] moveSpots;//몬스터가 움직일 곳
    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);   
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,
            moveSpots[randomSpot].position, 
            speed * Time.deltaTime);
        if(Vector2.Distance(transform.position,moveSpots[randomSpot].position)<0.2f)
        {
            if(waitTime<=0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;//대기 시간이 줄어든다.
            }
        }
    }
}
