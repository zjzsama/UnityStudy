using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class SettingPanel : BasePanel<SettingPanel>
{
    // 1.声明成员变量
    public CustomGUISlider sliderMusic;
    public CustomGUISlider sliderSound;
    public CustomGUIToggle togMusic;
    public CustomGUIToggle togSound;
    public CustomGUIButton btnClose;

    // Start is called before the first frame update
    void Start()
    {
        // 2.监听对应的事件 处理逻辑
        sliderMusic.changeValue += (value) =>
        {
            // 处理音乐变化
            GameDataMgr.Instance.ChangeBKValue(value);
        };
        sliderSound.changeValue += (value) =>
        {
            // 处理音效变化
            GameDataMgr.Instance.ChangeSoundValue(value);
        };
        togMusic.changeValue += (value) =>
        {
            // 处理音乐开关
            GameDataMgr.Instance.OpenOrCloseBKMusic(value);
        };
        togSound.changeValue += (value) =>
        {
            // 处理音效开关
            GameDataMgr.Instance.OpenOrCloseBKSound(value);
        };
        btnClose.clickEvent += () =>
        {
            // 关闭设置面板
            Hide();
            // 判断当前所在场景
            if (SceneManager.GetActiveScene().name == "BeginScene")
                BeginPanel.Instance.Show(); // 打开开始界面
        };
        Hide();
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void UpdatePanelInfo()
    {
        // 我们面板上的信息都是根据 音效数据更新的
        MusicData data = GameDataMgr.Instance.musicData;

        // 设置面板内容
        sliderMusic.nowValue = data.bkValue;
        sliderSound.nowValue = data.soundValue;
        togMusic.isSel = data.isOpenBK;
        togSound.isSel = data.isOpenSound;
    }
    public override void Show()
    {
        base.Show();
        // 每次显示时顺便更新数据
        UpdatePanelInfo();
    }
    public override void Hide()
    {
        base.Hide();
        Time.timeScale = 1;
    }
}
