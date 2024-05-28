using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_Style_OnOff
{
    On,
    Off,
}
public abstract class CustomGUI_Control : MonoBehaviour
{
    //提取控件的共同表现
    //位置信息
    public CustomGUI_Pos guiPos;
    //显示内容信息
    public GUIContent content;
    // 自定义样式
    public GUIStyle style;
    //自定义样式是否启动的开关
    public E_Style_OnOff styleOnOff = E_Style_OnOff.Off;

    // 提供给外部绘制GUI的方法
    public void DrawGUI()
    {
        switch (styleOnOff)
        {
            case E_Style_OnOff.On:
                StyleOnDraw();
                break;
            case E_Style_OnOff.Off:
                StyleOffDraw();
                break;
            default:
                break;
        }
    }
    protected abstract void StyleOnDraw();

    protected abstract void StyleOffDraw();

}
