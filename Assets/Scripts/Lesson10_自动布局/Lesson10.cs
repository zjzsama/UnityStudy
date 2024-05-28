using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson10 : MonoBehaviour
{
    private void OnGUI()
    {
        #region 知识点一 GUILayout自动布局
        // 主要用于编辑器开发,如果用来做游戏UI不太合适
        GUILayout.BeginHorizontal();

        GUILayout.Button("123", GUILayout.Width(300));
        GUILayout.Button("1234");
        GUILayout.Button("12345");
        GUILayout.Button("123456", GUILayout.ExpandWidth(false));

        GUILayout.EndHorizontal();
        #endregion

        #region 知识点二 GUILayoutOption自动布局
        // 控件的固定宽高
        GUILayout.Width(300);
        GUILayout.Height(200);
        // 允许控件的最小宽高
        GUILayout.MinWidth(50);
        GUILayout.MinHeight(50);
        // 允许控件的最大宽高
        GUILayout.MaxWidth(100);
        GUILayout.MaxHeight(100);
        // 允许或禁止水平拓展
        GUILayout.ExpandHeight(true); //允许
        GUILayout.ExpandWidth(true); //禁止
        #endregion
    }
}
