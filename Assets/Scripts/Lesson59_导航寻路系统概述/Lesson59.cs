﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson59 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 什么是导航寻路系统
        // Unity中的导航寻路系统是能够让我们在游戏世界当中
        // 让角色能够从一个起点准确的到达另一个终点
        // 并且能够自动避开两个点之间的障碍物选择最近最合理的路径进行前往

        // Unity中的导航寻路系统的本质
        // 就是在A星寻路算法的基础上进行了拓展和优化
        #endregion

        #region 知识点二 我们要学习哪些内容

        //1.导航网格(NavMesh)的生成-要想角色能够在场景中自动寻路产生行进路径 那么必须得要有场景地形数据 导航网格生成就是用于生产导航的地形数据
        //2.导航网格寻路组件(NavMesh Agent)--寻路组件就是帮助我们根据地形数据计算路径让角色动起来的关键
        //3.导航网络连接组件(Off-Mesh Link)--当地形中间有断层 想让角色从一个平面跳到另一个平面 网格连接组件是关键
        //4.导航网格动态障碍物组件(NavMesh Obstacle)--地形中可能存在的可以移动或动态销毁的障碍物需要挂载的组件

        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
