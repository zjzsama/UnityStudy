using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using PureMVC.Patterns.Mediator;
using UnityEngine;

public class HidePanelCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);
        // 隐藏的目的
        // 得到mediator 再得到 mediator中的view 然后去 删除或者隐藏
        // 得到传入的mediator
        Mediator m = notification.Body as Mediator;
        if (m != null && m.ViewComponent != null)
        {
            // 删除场景上的面板对象
            GameObject.Destroy((m.ViewComponent as MonoBehaviour).gameObject);
            // 删除后置空
            m.ViewComponent = null;
        }
    }
}
