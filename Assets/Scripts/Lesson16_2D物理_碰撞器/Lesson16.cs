using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson16 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 碰撞器用来干嘛?
        // 碰撞器是用于在物理系统中 表示物体体积的 (形状或范围)
        // 刚体通过得到碰撞器的范围信息进行计算
        // 判断两个物体的范围是否接触
        // 如果接触 刚体就会模拟力的效果产生旋转和速度
        #endregion

        #region 知识点二 2D碰撞器
        // 1.圆形碰撞器
        // 2.盒状碰撞器
        // 3.多边形碰撞器
        // 4.边界碰撞器
        // 5.胶囊碰撞器
        // 6.复合碰撞器
        #endregion

        #region 知识点三 碰撞检测函数
        // 碰撞检测函数和3D碰撞检测出了名字不同外其他基本一致
        // 它是非常重要的知识点
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {

    }
    private void OnCollisionStay2D(Collision2D other)
    {

    }
    private void OnCollisionExit2D(Collision2D other)
    {

    }
}
