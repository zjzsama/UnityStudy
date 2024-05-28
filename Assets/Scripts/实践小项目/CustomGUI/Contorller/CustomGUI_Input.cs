using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomGUI_Input : CustomGUI_Control
{
    public event UnityAction textChange;
    private string oldStr = "";
    protected override void StyleOffDraw()
    {
        content.text = GUI.TextField(guiPos.Pos, content.text);
        if (oldStr != content.text)
        {
            oldStr = content.text;
            textChange?.Invoke();
        }
    }

    protected override void StyleOnDraw()
    {
        content.text = GUI.TextField(guiPos.Pos, content.text, style);
        if (oldStr != content.text)
        {
            oldStr = content.text;
            textChange?.Invoke();
        }
    }
}
