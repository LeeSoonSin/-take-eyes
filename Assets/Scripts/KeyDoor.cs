using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    //[SerializeField] private Key.KeyType keyType;
    public Key.KeyType keyType;

    public Key.KeyType GetKeyType()
    {
        Debug.Log("문이 열렸습니다.");
        System.Threading.Thread.Sleep(300);
        return keyType;
    }
    public void OpenDoor()
    {
        gameObject.SetActive(false);
    }
}
