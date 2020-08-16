using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bound : MonoBehaviour
{
    private BoxCollider2D bound;
    public string boundName;

    void Start()
    {
        bound = GetComponent<BoxCollider2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
