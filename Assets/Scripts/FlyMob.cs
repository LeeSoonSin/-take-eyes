using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMob : MonoBehaviour
{
    public static FlyMob instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MopActive()
    {
        gameObject.layer = 10;
        gameObject.tag = "Untagged";
    }   
}
