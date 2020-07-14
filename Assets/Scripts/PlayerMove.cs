using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    static public PlayerMove instance;

    public string currentMapName;

    public float Speed =2;
    Rigidbody2D rigid;
    float h;
    float v;
    bool isHorizonMove;
    
    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            rigid = GetComponent<Rigidbody2D>();
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        if(hDown|| vUp)
        {
            isHorizonMove = true;
        }
        else if (vDown||hUp)
        {
            isHorizonMove = false;
        }
    }
    void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * Speed;
    }
}
