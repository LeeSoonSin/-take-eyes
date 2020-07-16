using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public string currentMapName; //transferMap 스크립트에 있는 transperMapName 변수의 값을 저장.

    static public PlayerMove instance;

    public Gamemanager manager;
    public float Speed = 2; // 플레이어 이동 속도
    Rigidbody2D rigid;
    float h;
    float v;
    bool isHorizonMove;
    GameObject scanObject;
    Vector3 dirVec;


    public AudioClip walkSound_1;
    public AudioSource audioSource;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            Destroy(this.manager);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            DontDestroyOnLoad(this.manager);
            instance = this;
        }
        rigid = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        //움직임 값
        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");
        //움직임 버튼 설정
        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = manager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vUp = manager.isAction ? false : Input.GetButtonUp("Vertical");
        //수평 이동 
        if (hDown || vUp)
        {
            isHorizonMove = true;
        }
        else if (vDown || hUp)
        {
            isHorizonMove = false;
        }
        //감지 방향
        if (vDown && v == 1)
        {
            dirVec = Vector3.up;
        }
        else if (vDown && v == -1)
        {
            dirVec = Vector3.down;
        }
        else if (hDown && v == -1)
        {
            dirVec = Vector3.left;
        }
        else if (hDown && v == 1)
        {
            dirVec = Vector3.right;
        }
        //오브젝트 스캔
        if (Input.GetButtonDown("Jump") && scanObject != null)
        {
            manager.Action(scanObject);
        }
    }
    void FixedUpdate()
    {
        //움직임
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * Speed;

        //레이
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }
}
