using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Item
{
    public int id;
    public int num;
}
class Player
{
    public string name;
    public int age;
    public int atk;
    public int def;
    private string keyName;
    public List<Item> items; //拥有的装备信息

    //存储数据
    public void Save()
    {
        PlayerPrefs.SetString(keyName + "_name", name);
        PlayerPrefs.SetInt(keyName + "_age", age);
        PlayerPrefs.SetInt(keyName + "_atk", atk);
        PlayerPrefs.SetInt(keyName + "_def", def);
        //存储有多少个装备
        PlayerPrefs.SetInt(keyName + "itemsNum", items.Count);
        for (int i = 0; i < items.Count; i++)
        {
            PlayerPrefs.SetInt(keyName + "items_id" + i, items[i].id);
            PlayerPrefs.SetInt(keyName + "items_num" + i, items[i].num);
        }
    }

    //读取数据
    public void Load(string keyName)
    {
        this.keyName = keyName;
        name = PlayerPrefs.GetString(keyName + "_name", "未命名");
        age = PlayerPrefs.GetInt(keyName + "_age", 18);
        atk = PlayerPrefs.GetInt(keyName + "_atk", 10);
        def = PlayerPrefs.GetInt(keyName + "_def", 5);

        //得到有多少个装备
        int num = PlayerPrefs.GetInt(keyName + "_itemsNum", 0);
        //初始化容器
        items = new List<Item>();
        Item item;
        for (int i = 0; i < num; i++)
        {
            item = new Item();
            item.id = PlayerPrefs.GetInt(keyName + "_item_id" + i);
            item.id = PlayerPrefs.GetInt(keyName + "_item_num" + i);
            items.Add(item);
        }
    }
}

public class Lesson1_Exercises : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 练习题一
        //现在有玩家信息类,有名字,年龄.攻击力,防御力等数据
        //现在为其封装两个方法 一个用来存储数据 一个用来读取数据
        // Player p = new Player();
        // p.Load();
        // print(p.name + " " + p.age + " " + p.atk + " " + p.def);

        // p.name = "君哲";
        // p.age = 20;
        // p.atk = 100;
        // p.def = 50;
        // //改了过后存储
        // p.Save();
        #endregion

        #region 练习题二
        //现在有装备信息类,装备类有id,数量两个成员
        //上一题的玩家类包含一个List数组存储了拥有的所有装备信息
        //请在上一题的基础上,把装备信息的存储和读取加上

        Player p = new Player();
        p.Load("Player1");
        print(p.items.Count);//装备信息
        for (int i = 0; i < p.items.Count; i++)
        {
            print("道具ID:" + p.items[i].id + " 道具数量:" + p.items[i].num);
        }

        //为玩家添加一个装备
        Item item = new Item();
        item.id = 1;
        item.num = 10;
        p.items.Add(item);
        p.Save();
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
