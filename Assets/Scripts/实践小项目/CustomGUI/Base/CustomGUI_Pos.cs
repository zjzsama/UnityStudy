using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_Alignment_Type
{
    Up,
    Down,
    Left,
    Right,
    Center,
    Left_Up,
    Left_Down,
    Right_Up,
    Right_Down,
}
[System.Serializable]
public class CustomGUI_Pos
{
    //主要是处理 控件位置相关的内容
    //要完成 分辨率自适应的相关计算
    private Rect rPos = new Rect(0, 0, 100, 100); //该位置信息返回给外部 用于绘制控件 需要对它进行计算

    //屏幕九宫格对齐方式
    public E_Alignment_Type screen_Alignment_Type = E_Alignment_Type.Center;
    //控件中心对齐方式
    public E_Alignment_Type control_Center_Alignment_Type = E_Alignment_Type.Center;
    //偏移位置
    public Vector2 pos;
    //宽高
    public float width = 100;
    public float height = 50;
    //用于计算中心点的成员变量
    private Vector2 centerPos;

    //计算中心点偏移的方法
    private void CalcCenterPos()
    {
        switch (control_Center_Alignment_Type)
        {
            case E_Alignment_Type.Up:
                centerPos.x = -width / 2;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.Down:
                centerPos.x = -width / 2;
                centerPos.y = -height;
                break;
            case E_Alignment_Type.Left:
                centerPos.x = 0;
                centerPos.y = -height / 2;
                break;
            case E_Alignment_Type.Right:
                centerPos.x = -width;
                centerPos.y = -height / 2;
                break;
            case E_Alignment_Type.Center:
                centerPos.x = -width / 2;
                centerPos.y = -height / 2;
                break;
            case E_Alignment_Type.Left_Up:
                centerPos.x = 0;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.Left_Down:
                centerPos.x = 0;
                centerPos.y = -height;
                break;
            case E_Alignment_Type.Right_Up:
                centerPos.x = -width;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.Right_Down:
                centerPos.x = -width;
                centerPos.y = -height;
                break;
        }
    }
    //计算最终位置的方法
    private void CalcPos()
    {
        switch (screen_Alignment_Type)
        {
            case E_Alignment_Type.Up:
                rPos.x = Screen.width / 2 + centerPos.x + pos.x;
                rPos.y = 0 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Down:
                rPos.x = Screen.width / 2 + centerPos.x + pos.x;
                rPos.y = Screen.height + centerPos.y - pos.y;
                break;
            case E_Alignment_Type.Left:
                rPos.x = 0 + centerPos.x + pos.x;
                rPos.y = Screen.height / 2 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Right:
                rPos.x = width + centerPos.x - pos.x;
                rPos.y = Screen.height + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Center:
                rPos.x = Screen.width / 2 + centerPos.x + pos.x;
                rPos.y = Screen.height / 2 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Left_Up:
                rPos.x = 0 + centerPos.x + pos.x;
                rPos.y = 0 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Left_Down:
                rPos.x = 0 + centerPos.x + pos.x;
                rPos.y = Screen.height + centerPos.y - pos.y;
                break;
            case E_Alignment_Type.Right_Up:
                rPos.x = Screen.width + centerPos.x - pos.x;
                rPos.y = 0 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Right_Down:
                rPos.x = Screen.width + centerPos.x - pos.x;
                rPos.y = Screen.height + centerPos.y - pos.y;
                break;
            default:
                break;
        }
    }

    public Rect Pos
    {
        get
        {
            //进行计算
            //计算中心点偏移
            CalcCenterPos();
            //计算 屏幕坐标点
            CalcPos();
            //宽高直接赋值 返回给外部 别人直接使用来绘制控件
            rPos.width = width;
            rPos.height = height;
            return rPos;
        }
    }
}

