using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SaveNLoad : MonoBehaviour
{

    public static SaveNLoad instance;
    [System.Serializable]
   public class Data
   {
        public float playerX;
        public float playerY;
        public float playerZ;

        public int playerCurrentHP;

        public List<int> playerItemInventory;
        public List<int> playerItemInventoryCount;

        public string mapName;
        public string sceneName;

        public List<bool> swList;
        public List<string> swNameList;
        public List<string> varNameList;
        public List<float> varNumberList;
   }

    private Player player;
    private DataBaseManager database;
    private Inventory inventory;

    public Data data;

    private Vector3 vector;

    public void callSave()
    {
        database = FindObjectOfType<DataBaseManager>();
        player = FindObjectOfType<Player>();
        inventory = FindObjectOfType<Inventory>();
        data.playerX = player.transform.position.x;
        data.playerY = player.transform.position.y;
        data.playerZ = player.transform.position.z;
        data.playerCurrentHP = player.curHealth;

        data.mapName = player.currentMapName;
        data.sceneName = player.currentSceneName;

        Debug.Log("basic datas suceeed");
        data.playerItemInventory.Clear();
        for(int i = 0; i < database.var_name.Length;i++)
        {
            data.varNameList.Add(database.var_name[i]);
            data.varNumberList.Add(database.var[i]);
        }

        for (int i = 0; i < database.switch_name.Length; i++)
        {
            data.swNameList.Add(database.switch_name[i]);
            data.swList.Add(database.switches[i]);
        }

        List<Item> itemList = inventory.SaveItem();
        for(int i = 0; i < itemList.Count; i++)
        {
            Debug.Log("saved inventory item : " + itemList[i].itemID);
            data.playerItemInventory.Add(itemList[i].itemID);
            data.playerItemInventoryCount.Add(itemList[i].itemCount);
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/SaveFile.dat");

        bf.Serialize(file,data);
        file.Close();

        Debug.Log(Application.dataPath + " <- saved this all objects");

    }
    public void callLoad()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.dataPath + "/SaveFile.dat", FileMode.Open);
    
        if(file != null && file.Length >0)
        {
            data = (Data)bf.Deserialize(file);

            database = FindObjectOfType<DataBaseManager>();
            player = FindObjectOfType<Player>();
            inventory = FindObjectOfType<Inventory>();


            player.currentMapName = data.mapName;
            player.currentSceneName = data.sceneName;

            vector.Set(data.playerX, data.playerY, data.playerZ);
            player.transform.position = vector;

            player.curHealth = data.playerCurrentHP;
            database.var = data.varNumberList.ToArray();
            database.var_name = data.varNameList.ToArray();
            database.switches = data.swList.ToArray();
            database.switch_name = data.swNameList.ToArray();

            List<Item> itemList = new List<Item>();

            for(int i = 0; i < data.playerItemInventory.Count; i++)
            {
                for(int x = 0; x < database.itemList.Count; x++)
                {
                    if (data.playerItemInventory[i] == database.itemList[x].itemID)
                    {
                        itemList.Add(database.itemList[x]);
                        Debug.Log("Items are loaded in inventory: " + database.itemList[x].itemID);
                        break;
                    }
                }
            }

            for(int i = 0; i < data.playerItemInventoryCount.Count; i++)
            {
                itemList[i].itemCount = data.playerItemInventoryCount[i];
            }

            inventory.LoadItem(itemList);

            GameManager gm = FindObjectOfType<GameManager>();
            gm.LoadStart();
            SceneManager.LoadScene(data.sceneName);
        }
        else
        {
            Debug.Log("No saved files are exist");
        }
        file.Close();
    }
}
