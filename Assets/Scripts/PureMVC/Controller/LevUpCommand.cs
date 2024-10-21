using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using UnityEngine;

public class LevUpCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);
        // 得到数据代理 调用升级 升级完成后通知更新数据
        PlayerProxy playerProxy = Facade.RetrieveProxy(PlayerProxy.NAME) as PlayerProxy;
        if (playerProxy != null)
        {
            playerProxy.LevUp();
            SendNotification(PureNotification.UPDATE_PLAYER_INFO, playerProxy.Data);
        }
    }
}
