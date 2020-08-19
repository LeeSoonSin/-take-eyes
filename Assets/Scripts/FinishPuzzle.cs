using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPuzzle : MonoBehaviour
{
    public GameObject puzzle;
    private int pointsToWin;
    private int currentPoints;
    // Start is called before the first frame update
    void Start()
    {
        if(currentPoints >= pointsToWin)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
