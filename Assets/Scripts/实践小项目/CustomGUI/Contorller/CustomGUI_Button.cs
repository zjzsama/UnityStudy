using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomGUI_Button : CustomGUI_Control
{
    public event UnityAction clickEvent;
    protected override void StyleOffDraw()
    {
        if (GUI.Button(guiPos.Pos, content))
        {
            clickEvent?.Invoke();
        }
    }

    protected override void StyleOnDraw()
    {
        if (GUI.Button(guiPos.Pos, content, style))
        {
            clickEvent?.Invoke();
        }
    }
}
