using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class CustomGUI_Root : MonoBehaviour
{
    private CustomGUI_Control[] allControls;
    void Start()
    {
        allControls = this.GetComponentsInChildren<CustomGUI_Control>();
    }

    //在这统一绘制子对象控件的内容
    private void OnGUI()
    {
        // 通过每次绘制之前 得到所有子对象控件的 父类脚本
        // 这句代码 浪费性能 因为每次 GUI都会获取所有的控件 对应的脚本
        // 因此 需要优化 让其 只获取一次
        // 编辑状态下 才会一直执行
        if (!Application.isPlaying)
        {
            allControls = this.GetComponentsInChildren<CustomGUI_Control>();
        }

        // 遍历每一个控件 让其 执行绘制
        for (int i = 0; i < allControls.Length; i++)
        {
            allControls[i].DrawGUI();
        }
    }
}
