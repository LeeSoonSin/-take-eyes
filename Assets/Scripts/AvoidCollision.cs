using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidCollision : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    void Update()
    {
        this.transform.position += transform.up * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Border"))
        {
            this.transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z - 90);
        }
    }
}
