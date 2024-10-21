using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using UnityEngine;

public class ShowPanelCommand : SimpleCommand
{
    // 1.继承Command相关脚本
    // 2.重写里面的执行函数
    public override void Execute(INotification notification)
    {
        base.Execute(notification);
        // 写面板创建逻辑
        string panelName = notification.Body.ToString();
        switch (panelName)
        {
            case "MainPanel":
                // 显示面板相关内容

                // 如果要使用Mediator 一定也要在Facade中注册
                // command和proxy都是一样的 要用就要注册
                // 可以在命令中 直接使用Facade 代表的就是唯一的Facade

                //如果没有mediator就new一个
                if (!Facade.HasMediator(MainViewMediator.NAME))
                {
                    Facade.RegisterMediator(new MainViewMediator());
                }
                //有mediator 下一步就是创建界面 创建预设体

                // Facade有得到Mediator的方法
                MainViewMediator mv = Facade.RetrieveMediator(MainViewMediator.NAME) as MainViewMediator;
                // 实例化面板对象
                if (mv.ViewComponent == null)
                {
                    GameObject res = Resources.Load<GameObject>("UI/MainPanel");
                    GameObject obj = GameObject.Instantiate(res);

                    // 设置父对象是Canvas
                    obj.transform.SetParent(GameObject.Find("Canvas").transform, false);
                    // 得到预设体上的view脚本 关联到mediator上
                    mv.SetView(obj.GetComponent<PureMVC_MainView>());
                }

                // 往往显示了面板之后 需要在这里进行第一次更新
                // 需要把数据 一起通过参数传出去
                SendNotification(PureNotification.UPDATE_PLAYER_INFO, Facade.RetrieveProxy(PlayerProxy.NAME).Data);
                break;

            case "RolePanel":
                // 显示面板相关内容
                if (!Facade.HasMediator(RoleViewMediator.NAME))
                {
                    Facade.RegisterMediator(new RoleViewMediator());
                }
                RoleViewMediator rv = Facade.RetrieveMediator(RoleViewMediator.NAME) as RoleViewMediator;
                if (rv.ViewComponent == null)
                {
                    GameObject res = Resources.Load<GameObject>("UI/RolePanel");
                    GameObject obj = GameObject.Instantiate(res);

                    // 设置父对象是Canvas
                    obj.transform.SetParent(GameObject.Find("Canvas").transform, false);
                    // 得到预设体上的view脚本 关联到mediator上
                    rv.SetView(obj.GetComponent<PureMVC_RoleView>());
                }
                SendNotification(PureNotification.UPDATE_PLAYER_INFO, Facade.RetrieveProxy(PlayerProxy.NAME).Data);
                break;
            default:
                break;
        }
    }
}
