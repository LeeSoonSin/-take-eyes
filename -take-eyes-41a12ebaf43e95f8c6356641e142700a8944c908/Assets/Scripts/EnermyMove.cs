using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Invoke("Think", 3);
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        Vector2 frontVec = new Vector2(rigid.position.x + nextMove, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Floor"));
        if(rayHit.collider == null)
        {

        }
    }
    void Think()
    {
        nextMove = Random.Range(-1, 2);
        Invoke("Think", 3);
    }
}
