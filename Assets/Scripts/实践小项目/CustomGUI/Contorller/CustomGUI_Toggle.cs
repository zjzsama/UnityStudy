using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomGUI_Toggle : CustomGUI_Control
{
    public bool isSel;
    public event UnityAction<bool> changeValue;
    private bool isOldSel = true;
    protected override void StyleOffDraw()
    {
        isSel = GUI.Toggle(guiPos.Pos, isSel, content);
        // 只有变化时 才执行函数 否则没有必要一直执行
        if (isOldSel != isSel)
        {
            changeValue?.Invoke(isSel);
            isOldSel = isSel;
        }
    }

    protected override void StyleOnDraw()
    {
        isSel = GUI.Toggle(guiPos.Pos, isSel, content, style);
        if (isOldSel != isSel)
        {
            changeValue?.Invoke(isSel);
            isOldSel = isSel;
        }
    }

}
