using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewTestPanel : MonoBehaviour
{
    public Rect svPos;
    public Rect showPos;
    private Vector2 nowPos;
    public string[] strs;
    private void OnGUI()
    {
        //绘制之前通过字符串数组 动态的计算出 内部显示内容的 尺寸
        showPos.height = strs.Length * 30;

        nowPos = GUI.BeginScrollView(svPos, nowPos, showPos);
        for (int i = 0; i < strs.Length; i++)
        {
            GUI.Label(new Rect(0, i * 30, 100, 30), strs[i]);
        }

        GUI.EndScrollView();
    }
}
