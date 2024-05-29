using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson52 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 1D混合和2D混合
        // 1D混合是会用一个参数控制动画的混合 之所以叫1D是一个参数可以看做是一维线性的
        // 2D混合可以简单理解为两个参数控制动画的混合 之所以叫2D是因为两个参数可以看做二维平面
        #endregion

        #region 知识点二 2D混合的种类

        // 1.2D Simple Directional 2D简单定向模式 运动表示不同方向时使用 比如前后左右 走路
        // 2.2D Freeform Directional 2D自由形式定向模式 同上 运动表示不同方向时使用 但是可以在同一个方向有多个运动 比如向前跑和走
        // 3.2D Freeform Cartesian 2D自由形式笛卡尔坐标模式 运动不表示不同方向时使用 比如向前走不拐弯 比如向前跑不拐弯 向前走右转 向前跑右转
        // 4.Direct 直接模式 自由控制每个节点权重 一般做表情动作等
        #endregion

        #region 知识点三 2D混合的使用

        #endregion

        #region 总结

        // 前三种方式只是针对动作的不同采用不同算法来进行混合的
        // 第四种可以用多个参数进行融合

        // 混合树还可以再嵌入混合树 使用上是一致的 根据实际情况选择性使用

        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
