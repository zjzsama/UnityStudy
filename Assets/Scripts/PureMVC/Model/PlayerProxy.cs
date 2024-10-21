using System.Collections;
using System.Collections.Generic;
using PureMVC.Patterns.Proxy;
using UnityEngine;

public class PlayerProxy : Proxy
{
    public new const string NAME = "PlayerProxy";
    // 1.继承Proxy父类
    // 2.写我们的构造函数

    // 写构造函数
    // 重要点
    // 1.代理名字!!!
    // 2.代理的相关数据!!!
    public PlayerProxy() : base(PlayerProxy.NAME)
    {
        // 在构造函数中 初始化一个数据 进行关联
        PlayerDataObj data = new PlayerDataObj();

        // 初始化
        data.PlayerName = PlayerPrefs.GetString("PlayerName", "君哲");
        data.Lev = PlayerPrefs.GetInt("PlayerLev", 1);
        data.Money = PlayerPrefs.GetInt("PlayerMoney", 9999);
        data.Gem = PlayerPrefs.GetInt("PlayerGem", 8888);
        data.Power = PlayerPrefs.GetInt("PlayerPower", 99);

        data.Hp = PlayerPrefs.GetInt("PlayerHp", 100);
        data.Atk = PlayerPrefs.GetInt("PlayerAtk", 20);
        data.Def = PlayerPrefs.GetInt("PlayerDef", 10);
        data.Crit = PlayerPrefs.GetInt("PlayerCrit", 20);
        data.Miss = PlayerPrefs.GetInt("PlayerMiss", 10);
        data.Luck = PlayerPrefs.GetInt("PlayerLuck", 40);
        // 赋值给自己的Data进行关联
        Data = data;
    }

    public void LevUp()
    {
        PlayerDataObj data = Data as PlayerDataObj;
        data.Lev += 1;
        data.Money += data.Lev;
        data.Atk += data.Lev;
        data.Def += data.Lev;
        data.Crit += data.Lev;
        data.Miss += data.Lev;
        data.Luck += data.Lev;

        SaveData();
    }
    // 保存
    public void SaveData()
    {
        PlayerDataObj data = Data as PlayerDataObj;
        // 把数据内容存到本地
        PlayerPrefs.SetString("PlayerName", data.PlayerName);
        PlayerPrefs.SetInt("PlayerLev", data.Lev);
        PlayerPrefs.SetInt("PlayerMoney", data.Money);
        PlayerPrefs.SetInt("PlayerGem", data.Gem);
        PlayerPrefs.SetInt("PlayerPower", data.Power);

        PlayerPrefs.SetInt("PlayerHp", data.Hp);
        PlayerPrefs.SetInt("PlayerAtk", data.Atk);
        PlayerPrefs.SetInt("PlayerDef", data.Def);
        PlayerPrefs.SetInt("PlayerCrit", data.Crit);
        PlayerPrefs.SetInt("PlayerMiss", data.Miss);
        PlayerPrefs.SetInt("PlayerLuck", data.Luck);
    }
}
