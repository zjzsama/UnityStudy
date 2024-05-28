using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginPanel : MonoBehaviour
{
    private static LoginPanel instance;
    //两个按钮
    public Rect btnPos1;
    public Rect btnPos2;
    //两个label
    public Rect labelPos1;
    public Rect labelPos2;
    //两个输入框
    public Rect inputPos1;
    public Rect inputPos2;
    private string userName = "";
    private string password = "";
    private void Awake()
    {
        instance = this;
        Hide();
    }
    private void OnGUI()
    {
        //按钮
        if (GUI.Button(btnPos1, "登录游戏"))
        {
            //登录
            if (userName == "admin" && password == "8888")
            {
                SceneManager.LoadScene("GameScene");
                Hide();
            }
            else
            {
                Debug.Log("用户名或密码错误");
            }
        }
        if (GUI.Button(btnPos2, "返回"))
        {
            Hide();
            //返回
            BeginPanel.Show();
        }

        //文本
        GUI.Label(labelPos1, "用户名:");
        GUI.Label(labelPos2, "密码:");
        //输入框
        userName = GUI.TextField(inputPos1, userName);
        password = GUI.PasswordField(inputPos2, password, '*');
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
