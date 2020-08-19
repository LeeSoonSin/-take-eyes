using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleFinish : MonoBehaviour
{
    public int pointsToWin;
    private int currentpoint;
    public GameObject puzzle;
    // Start is called before the first frame update
    void Start()
    {
        pointsToWin = puzzle.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentpoint >= pointsToWin)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void AddPoints()
    {
        currentpoint++;
    }
}
