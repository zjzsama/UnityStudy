using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson6 : MonoBehaviour
{
    private int toolbarIndex = 0;
    private string[] toolbarInfos = { "工具栏1", "工具栏2", "工具栏3" };
    private int selectGridIndex = 0;
    private string[] selectGridInfos = { "选择网格1", "选择网格2", "选择网格3" };
    private void OnGUI()
    {
        #region 知识点一 工具栏
        toolbarIndex = GUI.Toolbar(new Rect(10, 10, 200, 20), toolbarIndex, toolbarInfos);
        // 工具栏可以根据不同的索引 来处理不同的逻辑
        switch (toolbarIndex)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            default:
                break;
        }
        #endregion

        #region 知识点二 选择网格
        // 相对于toolbar多了一个参数 xCount 代表水平方向最多显示的按钮数量
        selectGridIndex = GUI.SelectionGrid(new Rect(10, 50, 200, 100), selectGridIndex, selectGridInfos, 1);
        #endregion


    }
}
