using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class RankListInfo
{
    public List<RankInfo> rankList;
    public RankListInfo()
    {
        Load();
    }
    public void Add(string name, int score, float time)
    {
        rankList.Add(new RankInfo(name, score, time));
    }
    public void Save()
    {
        PlayerPrefs.SetInt("rankListNum", rankList.Count); //存储多少条数据
        for (int i = 0; i < rankList.Count; i++)
        {
            RankInfo rankInfo = rankList[i];
            PlayerPrefs.SetString("rankName" + i, rankInfo.playerName);
            PlayerPrefs.SetInt("rankScore" + i, rankInfo.playerScore);
            PlayerPrefs.SetFloat("rankTime" + i, rankInfo.playerTime);
        }
    }
    public void Load()
    {
        int num = PlayerPrefs.GetInt("rankListNum");
        rankList = new List<RankInfo>();
        for (int i = 0; i < num; i++)
        {
            RankInfo rankInfo = new RankInfo(PlayerPrefs.GetString("rankName" + i)
            , PlayerPrefs.GetInt("rankScore" + i)
         , PlayerPrefs.GetFloat("rankTime" + i));
            rankList.Add(rankInfo);
        }
    }
}

class RankInfo
{
    public string playerName;
    public int playerScore;
    public float playerTime;
    public RankInfo(string name, int score, float time)
    {
        this.playerName = name;
        this.playerScore = score;
        this.playerTime = time;
    }
}
public class Lesson2Exercises : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 练习题一
        //将知识点一中的练习题 改为可以支持存储多个玩家信息
        #endregion

        #region 练习题二
        //在游戏中做一个排行榜的功能
        //排行榜主要记录玩家名(可重复),玩家得分,玩家通关时间
        //请用PlayerPrefs存储排行榜相关信息
        RankListInfo rankListInfo = new RankListInfo();
        print(rankListInfo.rankList.Count);
        rankListInfo.Add("张三", 100, 100);
        rankListInfo.Save();
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
