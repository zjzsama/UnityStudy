using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnContinue;
    public CustomGUIButton btnClose;


    private void Start()
    {
        btnQuit.clickEvent += () =>
        {
            // 回到主界面
            SceneManager.LoadScene("BeginScene");
        };
        btnContinue.clickEvent += () =>
        {
            // 关闭面板
            Hide();
        };
        btnClose.clickEvent += () =>
        {
            // 关闭面板
            Hide();
        };
        Hide();
    }
    public override void Hide()
    {
        base.Hide();
        Time.timeScale = 1;
    }
}
