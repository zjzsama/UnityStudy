using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 GUI是什么
        //全称 即时模式游戏用户交互界面(IMGUI)
        //一个代码驱动的UI系统
        #endregion

        #region 知识点二 GUI的主要作用
        //1.程序员的调试工具 创建游戏内调试工具
        //2.为脚本组件创建自定义监视面板
        //3.创建新的编辑器窗口和工具以拓展Unity本身(一般用作内置游戏工具)

        //注意:不要用它为玩家制作UI功能
        #endregion

        #region 知识点三 GUI的工作原理
        //在继承MonoBehaviour的脚本的特殊函数里
        //调用GUI提供的方法
        //类似生命周期函数
        #endregion

    }
    private void OnGUI()
    {
        //在其中书写 GUI相关代码 即可显示GUI内容
    }
    // Update is called once per frame
    void Update()
    {

    }
}
