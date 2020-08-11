using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public string currentMapName; //transferMap 스크립트에 있는 transperMapName 변수의 값을 저장.
    public int MapNum;///transferMap 스크립트에 있는 맵의 변수 값 저장.
    static public PlayerMove instance;
    public bool notMove = false;

    public Gamemanager manager;
    public float Speed = 2; // 플레이어 이동 속도
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;// 애니메이션 부분1 (케이디)
    float h;
    float v;
    bool isHorizonMove;
    GameObject scanObject;
    public Vector3 dirVec;


    public AudioClip walkSound_1;
    public AudioSource audioSource;

    Animator anim; //케이디
    void Awake()//플레이어 삭제 방지
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
        spriteRenderer = GetComponent<SpriteRenderer>();//애니 2(케이디)
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //(isAction 할 경우 움직이지 못하게 해놓음.)
        //움직임 값
        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");
        //움직임 버튼 설정
        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = manager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vUp = manager.isAction ? false : Input.GetButtonUp("Vertical");

        if (!notMove)
        {
            if (hDown)
            {
                isHorizonMove = true;
            }
            else if(vDown)
            {
                isHorizonMove = false;
            }
            else if (vUp || hUp)
            {
                isHorizonMove = h != 0;
            }

            //Animation
            if(anim.GetInteger("hAxisRaw") != h)
            {
                anim.SetBool("isChange", true);
                anim.SetInteger("hAxisRaw", (int)h);
            }
            else if (anim.GetInteger("vAxisRaw") != v)
            {
                anim.SetBool("isChange", true);
                anim.SetInteger("vAxisRaw", (int)v);
            }
            else
            {
                anim.SetBool("isChange", false);
            }


        }
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
        else if (hDown && h == -1)
        {
            dirVec = Vector3.left;
        }
        else if (hDown && h == 1)
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Enermy")
        {
            Gamemanager.Instance.GameOver();
        }
    }
}
