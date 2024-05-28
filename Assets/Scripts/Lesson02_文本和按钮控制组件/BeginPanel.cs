using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : MonoBehaviour
{
    //面板的显示隐藏 所有地方都可以快速使用
    //静态方法 和 静态变量 就可以直接通过类名使用了
    private static BeginPanel instance;

    public Rect labelPos;
    public GUIContent labelContent;
    public GUIStyle labelStyle;

    public Rect buttonPos1;
    public Rect buttonPos2;
    public Rect buttonPos3;
    public GUIStyle buttonStyle;
    private void Awake()
    {
        instance = this;
    }
    private void OnGUI()
    {
        //游戏标题
        GUI.Label(labelPos, labelContent, labelStyle);
        //游戏按钮:开始 退出 设置
        if (GUI.Button(buttonPos1, "开始游戏", buttonStyle))
        {
            // SceneManager.LoadScene("GameScene");
            LoginPanel.Show();
            Hide();
        }
        if (GUI.Button(buttonPos2, "退出游戏", buttonStyle))
        {
            Hide();
            QuitTipPanel.Show();
        }
        if (GUI.Button(buttonPos3, "设置游戏", buttonStyle))
        {
            Hide();
            SettingPanel.Show();
        }
    }
    //面板的显示和隐藏
    public static void Show()
    {
        if (instance != null)
        {
            instance.gameObject.SetActive(true);
        }

    }
    public static void Hide()
    {
        if (instance != null)
        {
            instance.gameObject.SetActive(false);
        }
    }
}
