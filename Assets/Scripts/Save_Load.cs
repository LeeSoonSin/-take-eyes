using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class Save_Load : MonoBehaviour
{
    [System.Serializable] //직렬화
    //직렬화를 사용하면 Vector를 사용 불가
   public class Data
    {
        //기록해야되는 데이터들
        public float playerX;
        public float playerY;
        public float playerZ;

        
        public List<int> playerItemInventory;//풀레이어가 소지한 아이템

        public string mapName;
        public string SceneName;

        public List<bool> swList;
        public List<string> swNameList;
        public List<string> varNameList;
        public List<float> varNumberList;
        //기록 끝
    }

    private PlayerMove thePlayer;
    private DataBase theDatabase;
    private Inventory theInven;

    public Data data;

    private Vector3 vector;
   
    public void CallSave()
    {
        //플레이어 정보 저장
        theDatabase = FindObjectOfType<DataBase>();
        thePlayer = FindObjectOfType<PlayerMove>();
        theInven = FindObjectOfType<Inventory>();

        data.playerX = thePlayer.transform.position.x;
        data.playerY = thePlayer.transform.position.y;
        data.playerZ = thePlayer.transform.position.z;

        data.mapName = thePlayer.currentMapName;
        data.SceneName = thePlayer.currentSceneName;
        Debug.Log("플레이어 저장됨.");

        for (int i =0; i < theDatabase.var_name.Length;i++)
        {
            data.varNameList.Add(theDatabase.var_name[i]);
            data.varNumberList.Add(theDatabase.var[i]);
        }
        for (int i = 0; i < theDatabase.switch_name.Length; i++)
        {
            data.swNameList.Add(theDatabase.switch_name[i]);
            data.swList.Add(theDatabase.switches[i]);
        }

        //인벤토리 저장
        List<Item> itemList = theInven.SaveItem();
        for(int i=0; i < itemList.Count; i++)
        {
            data.playerItemInventory.Add(itemList[i].itemID);
        }
        Debug.Log("인벤토리 저장됨.");

        //게임 저장
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/SaveFile.dat");

        bf.Serialize(file, data);
        file.Close();

        Debug.Log(Application.dataPath + "의 위치에 저장됨");
        

    }
    public void CallLoad()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.dataPath + "/SaveFile.dat", FileMode.Open);

        if(file != null&& file.Length > 0)
        {
            data = (Data)bf.Deserialize(file);

            theDatabase = FindObjectOfType<DataBase>();
            thePlayer = FindObjectOfType<PlayerMove>();
            theInven = FindObjectOfType<Inventory>();

            thePlayer.currentMapName = data.mapName;
            thePlayer.currentSceneName = data.SceneName;

            vector.Set(data.playerX, data.playerY, data.playerZ);
            thePlayer.transform.position = vector;

            theDatabase.var = data.varNumberList.ToArray();
            theDatabase.var_name = data.varNameList.ToArray();
            theDatabase.switches = data.swList.ToArray();
            theDatabase.switch_name = data.swNameList.ToArray();

            List<Item> itemList = new List<Item>();
            for(int i =0; i < data.playerItemInventory.Count; i++)
            {
                for(int x =0; x< theDatabase.itemList.Count;x++)
                {
                    if (data.playerItemInventory[i] == theDatabase.itemList[x].itemID)
                    {
                        itemList.Add(theDatabase.itemList[x]);

                        break;
                    }
                }
            }

            theInven.LoadItem(itemList);

            Gamemanager theGM = FindObjectOfType<Gamemanager>();
            theGM.LoadStart();
            SceneManager.LoadScene(data.SceneName);


        }
        else
        {
            Debug.Log("저장된 데이터가 없습니다.");
        }
        file.Close();
    }
}
