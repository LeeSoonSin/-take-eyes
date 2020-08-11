using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;

    private Transform player;
    private Vector2 target;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Players").transform;

        target = new Vector2(player.position.x, player.position.y);
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyBullet();
        }
        

    }//벽에 닿았을때 지우기, 몇초뒤 지워지기, 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Players"))
        {
            DestroyBullet();
        }
    }
    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
