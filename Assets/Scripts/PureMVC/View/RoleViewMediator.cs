using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
using UnityEngine;

public class RoleViewMediator : Mediator
{
    public new const string NAME = "RoleViewMediator";
    // 套路写法
    // 1.继承PureMVC中的Mediator脚本
    // 2.写构造函数
    public RoleViewMediator() : base(NAME)
    {

    }
    // 3.重写监听通知的方法
    public override string[] ListNotificationInterests()
    {
        return new string[] { PureNotification.UPDATE_PLAYER_INFO, };
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
                // 玩家数据更新 逻辑处理
                if (ViewComponent != null)
                {
                    (ViewComponent as PureMVC_RoleView).UpdateInfo(notification.Body as PlayerDataObj);
                }
                break;
            default:
                break;
        }
    }

    public void SetView(PureMVC_RoleView view)
    {
        ViewComponent = view;
        view.btnClose.onClick.AddListener(() =>
        {
            GameFacede.Instance.SendNotification(PureNotification.HIDE_PANEL, this);
        });
        view.btnLevUp.onClick.AddListener(() =>
        {
            // 去通知升级
            SendNotification(PureNotification.LEV_UP);
        });
    }
}
