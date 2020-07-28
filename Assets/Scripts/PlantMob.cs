using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlantMob : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed;
    bool isLeft =true;
    private void Start()
    {
    
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Border")
        {
            if(isLeft)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                isLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isLeft = true;
            }
        }
    }
}
