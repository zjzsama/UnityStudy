using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{
    // 注册按钮
    public Button btnRegister;
    // 确定登录按钮
    public Button btnSure;

    // 账号和密码控件
    public InputField inputUser;
    public InputField inputPassword;

    // 记住密码和自动登录 多选框
    public Toggle togPassword;
    public Toggle togAuto;
    public override void Init()
    {
        // 点击注册
        btnRegister.onClick.AddListener(() =>
        {
            // 显示注册面板
            UIManager.Instance.ShowPanel<RegisterPanel>();
            // 隐藏自己
            UIManager.Instance.HidePanel<LoginPanel>();
        });
        // 点击登录 
        btnSure.onClick.AddListener(() =>
        {
            // 点击登录后 要验证用户名密码是否正确

            // 判断输入的账号密码 是否合理
            if (inputPassword.text.Length < 6 || inputUser.text.Length < 6)
            {
                // 提示不合法
                TipPanel panel = UIManager.Instance.ShowPanel<TipPanel>();
                // 改变提示面板的内容
                panel.ChangeInfo("账号和密码都必须大于或等于6位");
                return;
            }

            // 验证用户名和密码是否通过
            if (LoginMgr.Instance.CheckInfo(inputUser.text, inputPassword.text))
            {
                // 登录成功

                // 记录数据
                LoginMgr.Instance.LoginData.userName = inputUser.text;
                LoginMgr.Instance.LoginData.password = inputPassword.text;
                LoginMgr.Instance.LoginData.autoLogin = togAuto.isOn;
                LoginMgr.Instance.LoginData.remeberPassWord = togPassword.isOn;
                LoginMgr.Instance.SaveLoginData();

                // 根据服务器信息 来判断显示 哪个面板
                if (LoginMgr.Instance.LoginData.frontServerID <= 0)
                {
                    // 如果从来没有选择过服务器 id为-1时,就应该直接打开选服面板
                    UIManager.Instance.ShowPanel<ChooseServerPanel>();
                }
                else
                {
                    // 打开服务器面板
                    UIManager.Instance.ShowPanel<ServerPanel>();
                }
                // 隐藏自己
                UIManager.Instance.HidePanel<LoginPanel>();
            }
            else
            {
                // 登录失败
                UIManager.Instance.ShowPanel<TipPanel>().ChangeInfo("账号或密码错误");
            }
        });
        // 点击记住密码 逻辑
        togPassword.onValueChanged.AddListener((isOn) =>
        {
            // 取消记住密码 自动登录也取消
            if (!isOn)
            {
                togAuto.isOn = false;
            }
        });
        // 点击自动登录 逻辑
        togAuto.onValueChanged.AddListener((isOn) =>
        {
            // 选中自动登录时 记住密码也默认选中
            if (isOn)
            {
                togPassword.isOn = true;
            }
        });
    }

    public override void ShowMe()
    {
        base.ShowMe();
        // 显示自己时 根据数据 更新面板内容

        // 得到数据
        LoginData loginData = LoginMgr.Instance.LoginData;

        // 初始化面板显示
        // 更新两个多选框
        togPassword.isOn = loginData.remeberPassWord;
        togAuto.isOn = loginData.autoLogin;

        //更新账号密码
        inputUser.text = loginData.userName;
        // 如果上次勾选了记住密码
        if (togPassword.isOn)
        {
            inputPassword.text = loginData.password;
        }

        // 如果上次勾选了自动登录
        if (togAuto.isOn)
        {
            // TODO:自动验证账号密码相关
            // 验证用户名密码
            if (LoginMgr.Instance.CheckInfo(inputUser.text, inputPassword.text))
            {
                // 根据服务器信息 来判断显示 哪个面板
                if (LoginMgr.Instance.LoginData.frontServerID <= 0)
                {
                    // 如果从来没有选择过服务器 id为-1时,就应该直接打开选服面板
                    UIManager.Instance.ShowPanel<ChooseServerPanel>();
                }
                else
                {
                    // 打开服务器面板
                    UIManager.Instance.ShowPanel<ServerPanel>();
                }
                // 隐藏自己
                UIManager.Instance.HidePanel<LoginPanel>(false);
            }
            else
            {
                TipPanel panel = UIManager.Instance.ShowPanel<TipPanel>();
                panel.txtInfo.text = "账号或密码错误";
            }
        }
    }

    /// <summary>
    /// 提供给外部 快捷设置用户名和密码
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    public void SetInfo(string userName, string password)
    {
        inputUser.text = userName;
        inputPassword.text = password;
    }
}
