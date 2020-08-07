using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnermy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retratDistance;

    private float CoolTime;
    public float startCool;

    public GameObject projectile;
    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        CoolTime = startCool;
    }

    void Update()
    {
        if(Vector2.Distance(transform.position,player.position) > stoppingDistance)//적과 캐릭터 사이의 거리
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position,player.position) <stoppingDistance && Vector2.Distance(transform.position,player.position) > retratDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position)< retratDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if(CoolTime <=0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            CoolTime = startCool;
        }
        else
        {
            CoolTime -= Time.deltaTime;
        }
    }
}
