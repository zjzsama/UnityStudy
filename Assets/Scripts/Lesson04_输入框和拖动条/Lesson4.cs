using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson4 : MonoBehaviour
{
    private string inputStr = "请输入内容";
    private string inputPw = "";
    private float nowValue = 0.5f;
    private float nowValue2 = 0.5f;
    private void OnGUI()
    {
        #region 知识点一 输入框

        #region 普通输入
        // 重要参数 一个显示内容 string
        // 一个是 最大输入字符串长度
        inputStr = GUI.TextField(new Rect(0, 0, 100, 30), inputStr);
        #endregion

        #region 密码输入
        inputPw = GUI.PasswordField(new Rect(0, 30, 100, 30), inputPw, '*');
        #endregion

        #endregion

        #region 知识点二 拖动条

        #region 水平拖动条
        // 当前值
        // 最小值left value
        // 最大值right value
        nowValue = GUI.HorizontalSlider(new Rect(0, 60, 100, 30), nowValue, 0, 1);
        // print(nowValue);
        #endregion

        #region 竖直拖动条
        nowValue2 = GUI.VerticalSlider(new Rect(0, 90, 30, 100), nowValue, 0, 1);
        #endregion

        #endregion





    }
}
