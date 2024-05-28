using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMgr
{
    private static GameDataMgr instance = new GameDataMgr();
    public static GameDataMgr Instance { get => instance; }
    public MusicData musicData;
    // 排行榜数据对象
    public RankList rankData;

    // 防止外部new
    private GameDataMgr()
    {
        // 可以初始化游戏数据
        musicData = PlayerPrefsMgr.Instance.LoadData(typeof(MusicData), "Music") as MusicData;
        // 如果第一次进入游戏 没有音效数据 那么所有数据要么是false 要么是0
        if (!musicData.notFirst)
        {
            musicData.notFirst = true;
            musicData.isOpenBK = true;
            musicData.isOpenSound = true;
            musicData.bkValue = 1;
            musicData.soundValue = 1;
            PlayerPrefsMgr.Instance.SaveData(musicData, "Music");
        }
        // 初始化读取排行榜数据
        rankData = PlayerPrefsMgr.Instance.LoadData(typeof(RankList), "Rank") as RankList;
    }
    // 提供一些API给外部 方便数据的改变存储

    // 提供一个在排行榜添加数据的方法
    public void AddRankInfo(string name, int score, float time)
    {
        rankData.rankList.Add(new RankInfo(name, score, time));
        // 排序
        rankData.rankList.Sort((a, b) => { return a.time < b.time ? -1 : 1; });
        // 排序过后移除十条以外的信息
        // 尾部往前遍历 移除
        for (int i = rankData.rankList.Count - 1; i >= 10; i--)
        {
            rankData.rankList.RemoveAt(i);
        }
        // 存储改变后的数据
        PlayerPrefsMgr.Instance.SaveData(rankData, "Rank");
    }
    // 开启或者关闭背景音乐
    public void OpenOrCloseBKMusic(bool isOpen)
    {
        musicData.isOpenBK = isOpen;

        // 控制开关
        BKMusic.Instance.ChangeOpen(isOpen);
        // 存储改变后的数据
        PlayerPrefsMgr.Instance.SaveData(musicData, "Music");
    }
    // 开启或者关闭背景音效
    public void OpenOrCloseBKSound(bool isOpen)
    {
        musicData.isOpenSound = isOpen;
        // 存储改变后的数据
        PlayerPrefsMgr.Instance.SaveData(musicData, "Music");
    }

    public void ChangeBKValue(float value)
    {
        musicData.bkValue = value;
        BKMusic.Instance.ChangeValue(value);
        // 存储改变后的数据
        PlayerPrefsMgr.Instance.SaveData(musicData, "Music");
    }

    public void ChangeSoundValue(float value)
    {
        musicData.soundValue = value;
        // 存储改变后的数据
        PlayerPrefsMgr.Instance.SaveData(musicData, "Music");
    }
}
