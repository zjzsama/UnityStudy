using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson3 : MonoBehaviour
{
    private bool isSel;
    private bool isSel2;
    public GUIStyle myStyle;
    private int nowSelIndex = 1;
    private void OnGUI()
    {
        #region 知识点一 多选框

        #region 普通样式
        isSel = GUI.Toggle(new Rect(0, 0, 100, 20), true, "效果开关");
        #endregion

        #region 自定义样式 显示问题
        //修改固定宽高 fixedWidth和fixedHeight
        //修改从GUIStyle边缘到内容起始处的空间 padding
        isSel2 = GUI.Toggle(new Rect(100, 100, 100, 20), true, "效果开关", myStyle);
        #endregion

        #endregion

        #region 知识点二 单选框
        //单选框是基于多选框的实现
        //关键:通过int标识 来确定是否选中
        if (GUI.Toggle(new Rect(200, 200, 100, 20), nowSelIndex == 1, "选项一"))
        {
            nowSelIndex = 1;
        }
        if (GUI.Toggle(new Rect(200, 250, 100, 20), nowSelIndex == 2, "选项二"))
        {
            nowSelIndex = 2;
        }
        if (GUI.Toggle(new Rect(200, 300, 100, 20), nowSelIndex == 3, "选项三"))
        {
            nowSelIndex = 3;
        }

        #endregion
    }
}
