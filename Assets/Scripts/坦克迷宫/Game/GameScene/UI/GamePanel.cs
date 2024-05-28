using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel<GamePanel>
{
    // 获取控件
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnSetting;
    public CustomGUILabel labelScore;
    public CustomGUILabel labelTime;
    public CustomGUITexture texHP;
    public float hpW = 350;
    private int time;
    //用于记录该玩家的当前分数
    [HideInInspector]
    public int nowScore = 0;
    [HideInInspector]
    public float nowTime;


    void Start()
    {
        // 监听按键 处理逻辑
        btnQuit.clickEvent += () =>
        {
            Time.timeScale = 0;
            // 返回游戏界面 弹出确定退出按钮
            QuitPanel.Instance.Show();
        };
        btnSetting.clickEvent += () =>
        {
            Time.timeScale = 0;
            SettingPanel.Instance.Show();
        };
    }

    // Update is called once per frame
    void Update()
    {
        // 通过帧间隔时间 进行累加 比较准确
        nowTime += Time.deltaTime;
        time = (int)nowTime;
        labelTime.content.text = "";
        // 把秒转换成时分秒
        // 得到几个小时
        if (time / 3600 > 0)
        {
            labelTime.content.text += time / 3600 + "时";
        }
        // 得到几个分钟
        if (time / 60 > 0)
        {
            labelTime.content.text += time % 3600 / 60 + "分";
        }
        // 得到几个秒数
        labelTime.content.text += time % 60 + "秒";
    }
    //提供给外部的加分方法
    public void AddScore(int score)
    {
        nowScore = score;
        // 更新界面显示
        labelScore.content.text = nowScore.ToString();
    }
    // 更新血条方法
    public void UpdateHP(int maxHP, int HP)
    {
        texHP.guiPos.width = (float)HP / maxHP * hpW;
    }
}
