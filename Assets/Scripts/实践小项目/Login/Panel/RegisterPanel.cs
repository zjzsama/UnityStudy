using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : BasePanel
{
    // 取消按钮
    public Button btnCancel;
    // 确定登录按钮
    public Button btnSure;

    // 账号和密码控件
    public InputField inputUser;
    public InputField inputPassword;


    public override void Init()
    {
        btnCancel.onClick.AddListener(() =>
        {
            // 隐藏自己
            UIManager.Instance.HidePanel<RegisterPanel>();
            // 显示登录面板
            UIManager.Instance.ShowPanel<LoginPanel>();
        });
        btnSure.onClick.AddListener(() =>
        {
            // 判断输入的账号密码 是否合理
            if (inputPassword.text.Length < 6 || inputUser.text.Length < 6)
            {
                // 提示不合法
                TipPanel panel = UIManager.Instance.ShowPanel<TipPanel>();
                // 改变提示面板的内容
                panel.ChangeInfo("账号和密码都必须大于或等于6位");
                return;
            }

            // 去注册账号密码
            if (LoginMgr.Instance.RegisterUser(inputUser.text, inputPassword.text))
            {
                // 清理登录数据 用于新账号的注册数据重置 不然会残留上一个账号的数据
                LoginMgr.Instance.ClearLoginData();

                // 注册成功
                //显示 登录面板
                LoginPanel loginPanel = UIManager.Instance.ShowPanel<LoginPanel>();
                // 更新登录面板数据
                loginPanel.SetInfo(inputUser.text, inputPassword.text);

                // 隐藏自己
                UIManager.Instance.HidePanel<RegisterPanel>();
            }
            else
            {
                // 提示 用户名已经存在
                TipPanel panel = UIManager.Instance.ShowPanel<TipPanel>();
                // 修改提示内容
                panel.ChangeInfo("用户名已存在");

                // 方便重新输入
                inputUser.text = "";
                inputPassword.text = "";
            }
        });
    }
}
