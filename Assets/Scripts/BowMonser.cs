using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowMonser : MonoBehaviour
{
    public float distance;
    public float atkDistance;
    public float speed;
    public LayerMask isLayer;



    public GameObject bullet;
    public Transform pos;
    public float cool;
    private float current;
    private void FixedUpdate()
    {
        RaycastHit2D raycast = Physics2D.Raycast(transform.position,
            transform.right * -1, distance, isLayer);   
        if(raycast.collider != null)
        {
            if(Vector2.Distance(transform.position,
                raycast.collider.transform.position)<atkDistance)
            {
                if(current <=0)
                {
                    GameObject bulletcopy = Instantiate(bullet, pos.position, transform.rotation );
                }
                current = cool;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position,
                    raycast.collider.transform.position,
                    Time.deltaTime * speed);
            }
            current -= Time.deltaTime;
        }
    }
}
