using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson8 : MonoBehaviour
{
    private Rect dragWindowPos = new Rect(400, 400, 200, 150);
    private void OnGUI()
    {
        #region 知识点一 窗口
        //第一个参数 id 是窗口唯一的id
        //委托参数 是用于 绘制窗口用的函数 传入即可
        GUI.Window(1, new Rect(300, 100, 200, 100), DrawWindow, "测试窗口1");
        //id对于我们来说 有一个重要作用 除了区分不同窗户 还可以在一个函数中去处理多个窗口的逻辑
        //通过id来区分它们
        GUI.Window(2, new Rect(300, 300, 200, 100), DrawWindow, "测试窗口2");

        #endregion

        #region 知识点二 模态窗口
        //模态窗口 可以让该其他控件不再有用
        //可以理解该窗口在最上层 其他按钮点击不到了
        //只能点击该 窗口 上的控件
        // GUI.ModalWindow(3, new Rect(300, 500, 200, 100), DrawWindow, "模态窗口");
        #endregion

        #region 知识点三 拖动窗口
        // 位置赋值是前提
        dragWindowPos = GUI.Window(4, dragWindowPos, DrawWindow, "拖动窗口");
        #endregion
    }
    private void DrawWindow(int id)
    {
        switch (id)
        {
            case 1:
                GUI.Button(new Rect(30, 20, 30, 20), "1");
                break;
            case 2:
                GUI.Button(new Rect(30, 20, 30, 20), "2");
                break;
            case 3:
                GUI.Button(new Rect(30, 20, 30, 20), "3");
                break;
            case 4:
                // 该API写在窗口函数中调用 可以让窗口被拖动
                // 传入Rect参数的作用
                // 是决定窗口的那一部分可以被拖动
                // 默认不填是所有位置可以被拖动
                GUI.DragWindow();
                break;
            default:
                break;
        }
    }
}
