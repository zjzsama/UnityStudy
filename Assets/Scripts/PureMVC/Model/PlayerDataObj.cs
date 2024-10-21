using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 玩家数据结构
/// </summary>
public class PlayerDataObj
{
    // 声明一堆玩家属性相关的变量
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
        set => playerName = value;
    }

    public int Lev
    {
        get => lev;
        set => lev = value;
    }

    public int Money
    {
        get => money;
        set => money = value;
    }

    public int Gem
    {
        get => gem;
        set => gem = value;
    }

    public int Power
    {
        get => power;
        set => power = value;
    }

    public int Hp
    {
        get => hp;
        set => hp = value;
    }

    public int Atk
    {
        get => atk;
        set => atk = value;
    }

    public int Def
    {
        get => def;
        set => def = value;
    }

    public int Crit
    {
        get => crit;
        set => crit = value;
    }

    public int Miss
    {
        get => miss;
        set => miss = value;
    }

    public int Luck
    {
        get => luck;
        set => luck = value;
    }
}
