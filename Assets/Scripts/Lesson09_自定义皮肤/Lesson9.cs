using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson9 : MonoBehaviour
{
    public GUIStyle style;
    public GUISkin skin;
    private void OnGUI()
    {
        #region 知识点一 全局颜色
        //全局的着色颜色 影响背景和文本颜色 建议不用
        //GUI.color = Color.red;

        //文本着色颜色 会和 全局颜色相乘
        // GUI.contentColor = Color.yellow;
        // GUI.Button(new Rect(100, 100, 200, 100), "按钮1");

        // //背景着色颜色 会和 全局颜色相乘
        // GUI.backgroundColor = Color.red;
        // GUI.Label(new Rect(100, 200, 200, 100), "按钮2");

        // GUI.color = Color.white;
        // GUI.Button(new Rect(100, 300, 200, 100), "按钮3", style);
        #endregion

        #region 知识点二 整体皮肤样式
        GUI.skin = skin;
        // 虽然设置了皮肤 但是绘制时 使用了GUIStyle参数 皮肤就没用
        GUI.Button(new Rect(100, 100, 200, 100), "按钮1");
        #endregion
    }
}
