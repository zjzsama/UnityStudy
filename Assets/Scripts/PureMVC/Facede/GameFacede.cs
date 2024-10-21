using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Facade;
using UnityEngine;

public class GameFacede : Facade
{
    // 1.继承Facade脚本
    // 2.为了方便我们使用Facade 需要自己写一个单例模式的属性
    public static GameFacede Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameFacede();
            }
            return instance as GameFacede;
        }
    }
    /// <summary>
    /// 3.初始化控制层相关的内容
    /// </summary>
    protected override void InitializeController()
    {
        base.InitializeController();
        // 这里写一些 关于命令和通知 绑定的逻辑
        RegisterCommand(PureNotification.START_UP, () =>
        {
            return new StartUpCommand();
        });
        RegisterCommand(PureNotification.SHOW_PANEL, () =>
        {
            return new ShowPanelCommand();
        });
        RegisterCommand(PureNotification.HIDE_PANEL, () =>
        {
            return new HidePanelCommand();
        });
        RegisterCommand(PureNotification.LEV_UP, () =>
        {
            return new LevUpCommand();
        });
    }
    // 4.一定有一个启动函数
    public void StartUp()
    {
        // 发送通知
        SendNotification(PureNotification.START_UP);
    }
}
