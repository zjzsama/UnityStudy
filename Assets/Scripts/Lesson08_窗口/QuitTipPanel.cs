using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitTipPanel : MonoBehaviour
{
    private static QuitTipPanel instance;
    public Rect windowPos;
    public Rect labPos;
    public Rect btnPos1;
    public Rect btnPos2;



    private void Awake()
    {
        instance = this;
        Hide();
    }
    private void OnGUI()
    {
        GUI.ModalWindow(1, windowPos, QuitTipPanelWindow, "提示");
    }

    private void QuitTipPanelWindow(int id)
    {
        switch (id)
        {
            case 1:
                GUI.Label(labPos, "是否退出游戏？");
                if (GUI.Button(btnPos1, "确定"))
                {
                    Application.Quit();
                }
                if (GUI.Button(btnPos2, "取消"))
                {
                    Hide();
                    BeginPanel.Show();
                }
                break;
            default:
                break;
        }

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
