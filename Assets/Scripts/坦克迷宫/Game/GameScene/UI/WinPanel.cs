using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : BasePanel<WinPanel>
{
    public CustomGUIInput inputInfo;
    public CustomGUIButton btnQuit;
    // Start is called before the first frame update
    void Start()
    {
        btnQuit.clickEvent += () =>
        {
            // 取消游戏暂停
            Time.timeScale = 1;
            // 把数据记录到排行榜中 并且回到主场景
            GameDataMgr.Instance.AddRankInfo(inputInfo.content.text, GamePanel.Instance.nowScore, GamePanel.Instance.nowTime);
            // 返回开始界面
            SceneManager.LoadScene("BeginScene");
        };
        Hide();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
