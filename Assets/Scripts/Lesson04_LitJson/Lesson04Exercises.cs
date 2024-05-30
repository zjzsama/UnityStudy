using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;
public class Item2
{
    public int id;
    public int num;

    public Item2()
    {
    }

    public Item2(int id, int num)
    {
        this.id = id;
        this.num = num;
    }
}

public class PlayerInfo2
{
    public string name;
    public int atk;
    public int def;
    public float moveSpeed;
    public float rotatedSpeed;

    public Item2 weapon;
    public List<int> listInt;
    public List<Item2> itemList;
    public Dictionary<int, Item2> itemDic;
    public Dictionary<string, Item2> itemDic2;
    private int privateI = 1;
    protected int protectedI = 2;
}
public class Lesson04Exercises : MonoBehaviour
{
    private string path;
    // Start is called before the first frame update
    void Start()
    {
        print(Application.persistentDataPath);
        path = "/MrZhou4.json";
        PlayerInfo2 player = new PlayerInfo2();
        player.name = "君哲";
        player.atk = 1;
        player.def = 1;
        player.moveSpeed = 1;
        player.rotatedSpeed = 1;

        player.weapon = new Item2(1, 1);
        player.listInt = new List<int> { 1, 2, 3, 4 };
        player.itemList = new List<Item2> { new Item2(1, 99), new Item2(2, 100) };
        //player.itemDic = new Dictionary<int, Item2> { { 1, new Item2(1, 99) } };
        player.itemDic2 = new Dictionary<string, Item2>() { { "1", new Item2(1, 99) } };
        SaveData(player, path);

        PlayerInfo2 player2 = LoadData(path);
    }

    public void SaveData(PlayerInfo2 player, string path)
    {
        string jsonStr = JsonMapper.ToJson(player);
        File.WriteAllText(Application.persistentDataPath + path, jsonStr);
    }

    public PlayerInfo2 LoadData(string path)
    {
        string jsonStr = File.ReadAllText(Application.persistentDataPath + path);
        return JsonMapper.ToObject<PlayerInfo2>(jsonStr);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
