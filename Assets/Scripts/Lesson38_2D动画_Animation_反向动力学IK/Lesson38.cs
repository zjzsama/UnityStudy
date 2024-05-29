using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson38 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 什么是IK?
        // 在骨骼动画中 构建骨骼的方法被称为正向动力学
        // 它的表现形式是 子骨骼(关节)的位置根据父骨骼(关节)的旋转而改变
        // 用我们人体举例子
        // 当我们抬起手臂时,是肩部关节带动的整个手臂的运动,用父子骨骼理解的话就是父带动了子

        // 而IK的全称是Inverse Kinematics 翻译过来就是 反向动力学的意思
        // 它和正向动力学恰恰相反
        // 他的表现形式是 子骨骼末端的位置会带动自己以及自己的父骨骼旋转
        // 用我们人体举例子
        // 当我们拿起一个杯子的时候是用手掌去拿 以杯子为参照物 我们移动杯子的位置 手臂会随着杯子一起移动
        // 用父子骨骼理解的话就是子带动了父
        #endregion

        #region 知识点二 2D IK包引入

        #endregion

        #region 知识点三 2D IK的使用

        #endregion

        #region 知识点四 IK对于我们的意义
        // 1.瞄准功能
        // 2.头部朝向功能
        // 3.拾取物品功能
        // 等等有指向性的功能时,我们都可以通过IK来达到目的

        // 最大的作用 方便我们制作动画 
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
