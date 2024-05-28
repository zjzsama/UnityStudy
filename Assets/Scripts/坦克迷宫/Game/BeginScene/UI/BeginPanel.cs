using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : BasePanel<BeginPanel>
{
    // 首先声明公共的成员变量 来关联各个控件
    public CustomGUIButton btnBegin;
    public CustomGUIButton btnSetting;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnRank;
    // Start is called before the first frame update
    void Start()
    {
        // 目的是方便控制坦克头部转向 所以鼠标锁定在窗口内 避免移出去
        Cursor.lockState = CursorLockMode.Confined;
        // 监听一次点击要做什么
        btnBegin.clickEvent += () =>
        {
            //切换场景
            SceneManager.LoadScene("GameScene");
        };
        btnSetting.clickEvent += () =>
        {
            // 隐藏自己 防止穿透
            Hide();
            //打开设置面板
            SettingPanel.Instance.Show();
        };
        btnQuit.clickEvent += () =>
        {
            //退出游戏
            Application.Quit();
        };
        btnRank.clickEvent += () =>
        {
            Hide();
            //打开排行榜面板
            RankPanel.Instance.Show();
        };
    }

    // Update is called once per frame
    void Update()
    {

    }
}
