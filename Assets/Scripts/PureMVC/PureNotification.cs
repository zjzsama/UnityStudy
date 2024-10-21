using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 这个是PureMVC中的通知名类
/// 主要是用来声明各个通知的名字
/// 方便使用和管理
/// </summary>
public class PureNotification
{
    // 显示面板通知
    public const string SHOW_PANEL = "ShowPanel";
    // 代表玩家数据更新的通知名
    public const string UPDATE_PLAYER_INFO = "UpdatePlayerInfo";
    // 启动通知
    public const string START_UP = "StartUp";
    // 隐藏面板通知
    public const string HIDE_PANEL = "HidePanel";
    // 升级通知
    public const string LEV_UP = "LevUp";
}
