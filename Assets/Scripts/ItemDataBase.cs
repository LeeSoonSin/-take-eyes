using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{
    public static ItemDataBase instance;
    private void Awake()
    {
        instance = this;
    }
    public List<Item> itemDB = new List<Item>();
    [Space(20)]
    public GameObject FieldItemPrefab;
    public Vector3[] pos;
    private void Start()
    {
        for(int i = 0; i<6; i++)
        {
            GameObject go = Instantiate(FieldItemPrefab, pos[i], Quaternion.identity);
            go.GetComponent<FieldItem>().SetItem(itemDB[Random.Range(0,1)]);
        }
    }
}
