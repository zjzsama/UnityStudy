using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public enum E_Slider_Type
{
    Horizontal,
    Vertical,
}
public class CustomGUI_Slider : CustomGUI_Control
{
    public float minValue = 0;
    public float maxValue = 1;
    private float nowValue = 0;
    // 样式
    public E_Slider_Type type = E_Slider_Type.Horizontal;
    // 小按钮的style
    public GUIStyle styleThumb;
    public event UnityAction<float> changeValue;
    private float oldValue;
    protected override void StyleOffDraw()
    {
        switch (type)
        {
            case E_Slider_Type.Horizontal:
                nowValue = GUI.HorizontalSlider(guiPos.Pos, nowValue, minValue, maxValue);
                break;
            case E_Slider_Type.Vertical:
                nowValue = GUI.VerticalSlider(guiPos.Pos, nowValue, minValue, maxValue);
                break;
            default:
                break;
        }
        if (nowValue != oldValue)
        {
            oldValue = nowValue;
            changeValue?.Invoke(nowValue);
        }
    }

    protected override void StyleOnDraw()
    {
        switch (type)
        {
            case E_Slider_Type.Horizontal:
                nowValue = GUI.HorizontalSlider(guiPos.Pos, nowValue, minValue, maxValue, style, styleThumb);
                break;
            case E_Slider_Type.Vertical:
                nowValue = GUI.VerticalSlider(guiPos.Pos, nowValue, minValue, maxValue, style, styleThumb);
                break;
            default:
                break;
        }
        if (nowValue != oldValue)
        {
            oldValue = nowValue;
            changeValue?.Invoke(nowValue);
        }
    }
}
