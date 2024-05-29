using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson19 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 2D效应器是什么?

        // 2D效应器是配合2D碰撞器一起使用的
        // 可以让游戏对象在相互碰撞接触时 产生一些特殊的物理作用力
        // 可以通过2D效应器
        // 快捷的实现一些
        // 传送带 互斥 吸引 漂浮 单向碰撞等等效果
        #endregion

        #region 知识点二 不同种类的2D效应器的使用
        // 1.区域效应器
        // 2.浮力效应器
        // 3.点效应器 模拟磁铁
        // 4.平台效应器 可制作单向通过的跳跃平台
        // 5.表面效应器 模拟传送带
        #endregion

        #region 总结

        // 效应器其实只是Unity为我们写好的一些2D游戏中常用功能的一些代码
        // 在实际开发中我们不应该过于依赖效应器
        // 如果发现效应器与自己的游戏不太匹配时 我们完全可以自己实现符合要求的"效应器"

        #endregion

        //场景在Lesson16Exercises中
    }

    // Update is called once per frame
    void Update()
    {

    }
}
