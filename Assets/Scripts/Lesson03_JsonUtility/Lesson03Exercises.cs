using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int id;
    public int num;

    public Item(int id, int num)
    {
        this.id = id;
        this.num = num;
    }
}

public class PlayerInfo
{
    public string name;
    public int atk;
    public int def;
    public float moveSpeed;
    public float rotatedSpeed;

    public Item weapon;
    public List<int> listInt;
    public List<Item> itemList;
    public Dictionary<int, Item> itemDic;
    public Dictionary<string, Item> itemDic2;
    [SerializeField] private int privateI = 1;
    [SerializeField] protected int protectedI = 2;
}
public class Lesson03Exercises : MonoBehaviour
{
    private string path;
    // Start is called before the first frame update
    void Start()
    {
        path = "/MrZhou2.json";
        PlayerInfo player = new PlayerInfo();
        player.name = "君哲";
        player.atk = 1;
        player.def = 1;
        player.moveSpeed = 1;
        player.rotatedSpeed = 1;

        player.weapon = new Item(1, 1);
        player.listInt = new List<int> { 1, 2, 3, 4 };
        player.itemList = new List<Item> { new Item(1, 99), new Item(2, 100) };
        player.itemDic = new Dictionary<int, Item> { { 1, new Item(1, 99) } };
        player.itemDic2 = new Dictionary<string, Item>() { { "1", new Item(1, 99) } };
        SaveData(player, path);

        PlayerInfo player2 = LoadData(path);
    }

    public void SaveData(PlayerInfo player, string path)
    {
        // 序列化对象
        string jsonStr = JsonUtility.ToJson(player);
        print(Application.persistentDataPath);
        File.WriteAllText(Application.persistentDataPath + path, jsonStr);
    }

    public PlayerInfo LoadData(string path)
    {
        // 反序列化对象
        string jsonStr = File.ReadAllText(Application.persistentDataPath + path);
        return JsonUtility.FromJson<PlayerInfo>(jsonStr);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
