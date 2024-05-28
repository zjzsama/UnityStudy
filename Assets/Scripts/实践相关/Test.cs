using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerInfo
{
    public int age;
    public string name;
    public float height;
    public bool sex;
    public List<int> list;
    public Dictionary<int, string> dic;
    public ItemInfo itemInfo;
    public List<ItemInfo> itemInfos;
    public Dictionary<int, ItemInfo> itemDic;
}

public class ItemInfo
{
    public int id;
    public int num;

    public ItemInfo()
    {
    }

    public ItemInfo(int id, int num)
    {
        this.id = id;
        this.num = num;
    }
}


public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //读取数据
        PlayerInfo p = PlayerPrefsMgr.Instance.LoadData(typeof(PlayerInfo), "Player1") as PlayerInfo;

        //游戏逻辑中会修改玩家数据
        p.age = 18;
        p.name = "君哲";
        p.height = 1000f;
        p.sex = true;

        p.itemInfos.Add(new ItemInfo(1, 99));
        p.itemInfos.Add(new ItemInfo(2, 199));

        p.itemDic.Add(3, new ItemInfo(3, 299));
        p.itemDic.Add(4, new ItemInfo(4, 399));

        //游戏数据存储
        PlayerPrefsMgr.Instance.SaveData(p, "Player1");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
