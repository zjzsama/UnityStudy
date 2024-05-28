using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson7 : MonoBehaviour
{
    public Rect groupPos;
    public Rect scPos;
    public Rect scVPos;
    private Vector2 nowPos;
    public string[] strs = new string[] { "123", "456", "111", "222" };
    private void OnGUI()
    {
        #region 知识点一 分组
        //用于批量控制控件位置
        //可以理解为 包裹着的组件加了一个父对象
        //可以通过控制分组控制包裹控件的位置
        // GUI.BeginGroup(groupPos);
        // GUI.Button(new Rect(0, 0, 100, 50), "测试按钮");
        // GUI.EndGroup();
        #endregion

        #region 知识点二 滚动列表
        nowPos = GUI.BeginScrollView(scPos, nowPos, scVPos);
        GUI.Toolbar(new Rect(0, 0, 300, 50), 0, strs);
        GUI.Toolbar(new Rect(0, 60, 300, 50), 0, strs);
        GUI.Toolbar(new Rect(0, 120, 300, 50), 0, strs);
        GUI.Toolbar(new Rect(0, 180, 300, 50), 0, strs);
        GUI.EndScrollView();
        #endregion
    }
}
