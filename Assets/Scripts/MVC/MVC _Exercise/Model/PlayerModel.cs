using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerModel
{
    // 数据内容
    private string playerName;
    private int lev;
    private int money;
    private int gem;
    private int power;

    private int hp;
    private int atk;
    private int def;
    private int crit;
    private int miss;
    private int luck;

    public string PlayerName
    {
        get => playerName;
    }

    public int Lev
    {
        get => lev;
    }

    public int Money
    {
        get => money;
    }

    public int Gem
    {
        get => gem;
    }

    public int Power
    {
        get => power;
    }

    public int Hp
    {
        get => hp;
    }

    public int Atk
    {
        get => atk;
    }

    public int Def
    {
        get => def;
    }

    public int Crit
    {
        get => crit;
    }

    public int Miss
    {
        get => miss;
    }

    public int Luck
    {
        get => luck;
    }

    // 通知外部更新的事件
    private event UnityAction<PlayerModel> updateEvent;

    // 在外部 第一次获取这个数据
    // 通过单例模式来达到数据的唯一性和数据的获取
    private static PlayerModel instance;
    public static PlayerModel Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerModel();
                instance.Init();
            }
            return instance;
        }
    }


    // 数据相关的操作
    // 初始化
    public void Init()
    {
        playerName = PlayerPrefs.GetString("PlayerName", "君哲");
        lev = PlayerPrefs.GetInt("PlayerLev", 1);
        money = PlayerPrefs.GetInt("PlayerMoney", 9999);
        gem = PlayerPrefs.GetInt("PlayerGem", 8888);
        power = PlayerPrefs.GetInt("PlayerPower", 99);

        hp = PlayerPrefs.GetInt("PlayerHp", 100);
        atk = PlayerPrefs.GetInt("PlayerAtk", 20);
        def = PlayerPrefs.GetInt("PlayerDef", 10);
        crit = PlayerPrefs.GetInt("PlayerCrit", 20);
        miss = PlayerPrefs.GetInt("PlayerMiss", 10);
        luck = PlayerPrefs.GetInt("PlayerLuck", 40);
    }
    // 更新 升级
    public void LevUp()
    {
        // 升级 改变内容
        lev += 1;

        hp += lev;
        atk += lev;
        def += lev;
        crit += lev;
        miss += lev;
        luck += lev;

        // 改变过后保存
        SaveData();
    }
    // 保存
    public void SaveData()
    {
        // 把数据内容存到本地
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.SetInt("PlayerLev", lev);
        PlayerPrefs.SetInt("PlayerMoney", money);
        PlayerPrefs.SetInt("PlayerGem", gem);
        PlayerPrefs.SetInt("PlayerPower", power);

        PlayerPrefs.SetInt("PlayerHp", hp);
        PlayerPrefs.SetInt("PlayerAtk", atk);
        PlayerPrefs.SetInt("PlayerDef", def);
        PlayerPrefs.SetInt("PlayerCrit", crit);
        PlayerPrefs.SetInt("PlayerMiss", miss);
        PlayerPrefs.SetInt("PlayerLuck", luck);
        UpdateInfo();
    }

    public void AddEventListener(UnityAction<PlayerModel> function)
    {
        updateEvent += function;
    }
    public void RemoveEventListener(UnityAction<PlayerModel> function)
    {
        updateEvent -= function;
    }
    // 通知外部更新数据的方法
    private void UpdateInfo()
    {
        if (updateEvent != null)
        {
            updateEvent(this);
        }
    }
}
