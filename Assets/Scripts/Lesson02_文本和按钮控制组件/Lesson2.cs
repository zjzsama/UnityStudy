using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson2 : MonoBehaviour
{

    public Texture image;
    public GUIStyle style;
    public Rect rect;
    public Rect rect1;
    public GUIContent gUIContent;
    public Rect btnRect;
    public string btnText;
    public GUIStyle btnStyle;
    public GUIContent btnContent;
    private void OnGUI()
    {

        #region 知识点一 GUI控件绘制的共同点
        // 1. 它们都是GUI公共类中提供的静态函数,直接使用即可 

        // 2. 它们的参数大同小异
        // 位置参数: Rect参数 xy位置 wh尺寸
        // 显示文本: string参数
        // 图片信息: Texture参数
        // 综合信息: GUIcontent参数
        // 自定义样式: GUIStyle参数

        // 3. 每一种控件都有多种重载,都是各个参数的排列组合
        // 必备的参数内容 是 位置信息和显示信息

        #endregion

        #region 知识点二 文本控件
        // 基本使用
        GUI.Label(new Rect(0, 0, 100, 20), "Hello World");
        GUI.Label(rect, image);
        // 综合使用
        GUI.Label(rect1, gUIContent);
        print(GUI.tooltip);//获取当前鼠标或者键盘选中的GUI控件 对应的 tooltip信息
        // 自定义样式
        GUI.Label(new Rect(200, 200, 100, 20), "Hello World", style);

        #endregion

        #region 知识点三 按钮控件
        // 基本使用
        // 综合使用
        // 自定义样式

        //只能在按钮范围内将鼠标按下和抬起 才会返回一次true
        // if (GUI.Button(btnRect, btnContent, btnStyle))
        // {
        //     //处理点击按钮的逻辑
        //     print("点击了按钮");
        // }

        //只要在按钮范围内按下 就会返回一次true
        if (GUI.RepeatButton(btnRect, btnContent))
        {
            print("长按了按钮");
        }
        #endregion
    }
}


