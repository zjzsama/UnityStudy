using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPTest : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            // 显示主面板
            UIManager.GetInstance().ShowPanel<MP_MainPanel>("MainPanel");
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            // 隐藏主面板和角色面板
            UIManager.GetInstance().HidePanel("MainPanel");
            UIManager.GetInstance().HidePanel("RolePanel");
        }
    }
}
