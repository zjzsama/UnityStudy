using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    // 1.关联public控件对象
    public CustomGUIButton btnClose;
    // 因为控件多 工作量太大 通过代码找
    private List<CustomGUILabel> labelName = new List<CustomGUILabel>();
    private List<CustomGUILabel> labelScore = new List<CustomGUILabel>();
    private List<CustomGUILabel> labelTime = new List<CustomGUILabel>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 10; i++)
        {
            // 小知识应用 找子对象的子对象 可以通过/ 来区分父子关系
            labelName.Add(this.transform.Find("RankList/Name/labName " + "(" + i + ")").GetComponent<CustomGUILabel>());
            labelScore.Add(this.transform.Find("RankList/Score/labScore " + "(" + i + ")").GetComponent<CustomGUILabel>());
            labelTime.Add(this.transform.Find("RankList/Time/labTime " + "(" + i + ")").GetComponent<CustomGUILabel>());
        }
        // 2.处理事件监听逻辑
        btnClose.clickEvent += () =>
        {
            // 关闭面板
            Hide();
            BeginPanel.Instance.Show();
        };
        Hide();
    }
    public override void Show()
    {
        base.Show();
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        // 处理数据 更新面版
        // 获取GameDataMgr数据 用于更新
        List<RankInfo> rankList = GameDataMgr.Instance.rankData.rankList;
        for (int i = 0; i < rankList.Count; i++)
        {
            // 名字
            labelName[i].content.text = rankList[i].name;
            // 分数
            labelScore[i].content.text = rankList[i].score.ToString();
            // 时间
            // 秒数 转换成 时 分 秒
            int time = (int)rankList[i].time;
            labelTime[i].content.text = "";
            // 得到几个小时
            if (time / 3600 > 0)
            {
                labelTime[i].content.text += time / 3600 + "时";
            }
            // 得到几个分钟
            if (time / 60 > 0)
            {
                labelTime[i].content.text += time % 3600 / 60 + "分";
            }
            // 得到几个秒数
            labelTime[i].content.text += time % 60 + "秒";
        }
    }
}
