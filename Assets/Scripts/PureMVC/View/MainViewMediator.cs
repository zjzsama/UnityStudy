using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
using UnityEngine;

public class MainViewMediator : Mediator
{
    public new const string NAME = "MainViewMediator";
    // 套路写法
    // 1.继承PureMVC中的Mediator脚本
    // 2.写构造函数
    public MainViewMediator() : base(NAME)
    {
        // 这里面可以去创建界面预设体等等逻辑
        // 但是界面显示应该是触发的控制的
        // 而且创建界面的代码 重复性比较高
    }
    // 3.重写监听通知的方法
    public override string[] ListNotificationInterests()
    {
        // 这是PureMVC的规则
        // 就是需要监听哪些通知 那就在这里把通知们通过字符串数组的形式返回出去
        // PureMVC就会帮助我们监听这些通知
        // 类似于 通过事件名 注册事件监听
        return new string[]
        {
            PureNotification.UPDATE_PLAYER_INFO,
        };
    }
    // 4.重写处理通知的方法
    public override void HandleNotification(INotification notification)
    {
        // INotification对象里面 包含两个对于我们重要的参数
        // 1.通知名 我们根据这个名字来做对应的处理
        // 2.通知包含的信息
        switch (notification.Name)
        {
            case PureNotification.UPDATE_PLAYER_INFO:
                // 收到更新通知的时候 做处理
                if (ViewComponent != null)
                {
                    (ViewComponent as PureMVC_MainView).UpdateInfo(notification.Body as PlayerDataObj);
                }
                break;
            default:
                break;
        }
    }
    // 5.可选:重写注册时的方法
    public override void OnRegister()
    {
        base.OnRegister();
        // 初始化进行一些处理
    }

    public void SetView(PureMVC_MainView view)
    {
        ViewComponent = view;
        view.btnRole.onClick.AddListener(() =>
        {
            SendNotification(PureNotification.SHOW_PANEL, "RolePanel");
        });
    }
}
