using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGUI_ToggleGroup : MonoBehaviour
{
    public CustomGUI_Toggle[] toggles;
    // 记录上一次选中的
    private CustomGUI_Toggle frontTurTog;

    void Start()
    {
        if (toggles.Length == 0)
        {
            return;
        }
        // 通过遍历 来为 多个 多选框 添加事件监听函数
        // 在函数中处理
        // 当一个变为true时 其他变为false
        for (int i = 0; i < toggles.Length; i++)
        {
            CustomGUI_Toggle toggle = toggles[i];
            toggle.changeValue += (value) =>
                    {
                        // 当传入的value 是true时 需要把另外的变成false
                        if (value)
                        {
                            // 意味另外的变为false
                            for (int j = 0; j < toggles.Length; j++)
                            {
                                if (toggles[j] != toggle)
                                {
                                    toggles[j].isSel = false;
                                }
                            }
                            frontTurTog = toggle;
                        }
                        // 判断当前变成false的 是不是上次的true 如果是 不能变为false 否则全部都没选中
                        else if (toggle == frontTurTog)
                        {
                            // 强制改为true
                            toggle.isSel = true;
                        }
                    };
        }
    }
}
