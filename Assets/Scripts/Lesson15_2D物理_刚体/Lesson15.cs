using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson15 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 学习2D物理系统的前提
        // 学习2D物理系统之前先学习Unity入门中的3D物理系统
        // 因为他们非常相似
        #endregion

        #region 知识点二 2D物理系统中的刚体组件
        // 刚体是物理系统中用于帮助我们进行模拟物理碰撞中力的效果的

        // 2D物理系统中的刚体和3D中的刚体基本是一样的
        // 最大的区别是对象只会在XY平面中进行移动 并且只在垂直于该平面的轴上旋转
        #endregion

        #region 知识点三 参数相关

        #endregion

        #region 知识点四 如何选择不同类型的刚体
        // Dynamic动态刚体:受力的作用,要动要碰撞的对象
        // Kinematic运动学刚体:通过刚体API移动的对象,不受力的作用,但是想要进行碰撞检测
        // Static静态刚体:不动不受力的静态物体,但是想要进行碰撞检测
        #endregion

        #region 知识点五 刚体API
        // 加力
        Rigidbody2D rigidbody2D = this.GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(new Vector2(100, 0));
        // 速度
        rigidbody2D.velocity = new Vector2(1, 0);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
