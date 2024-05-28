using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson16 : MonoBehaviour
{
    #region 知识点回顾
    //1.如何让两个物体相互碰撞(至少一个刚体和两个碰撞器)
    //2.如何让两个物体碰撞时产生不同效果(物理材质)
    //3.触发器的作用是什么(让两个物体碰撞没有物理效果,只进行碰撞处理)
    #endregion

    #region 注意:碰撞和触发响应函数 属于 特殊的生命周期函数 也是通过反射调用

    #endregion
    #region 知识点一 物理碰撞检测响应函数
    //碰撞触发接触时会 自动执行这个函数
    private void OnCollisionEnter(Collision other)
    {
        //Collision类型的参数 包含了 碰撞自己的对象的相关信息

        //关键参数
        //1.碰撞到的对象碰撞器的信息
        // other.collider

        //2.碰撞对象的依附对象(GameObject)
        // other.gameObject

        //3.碰撞对象的依附对象的位置信息
        // other.transform

        //4.碰撞点数相关
        // other.contactCount
        //接触点的具体坐标
        // ContactPoint[] pos = other.contacts;

        //只要得到了碰撞到的对象的任何信息 就可以得到它的所有信息

        print(this.name + "被" + other.gameObject.name + "碰撞到了");
    }

    //碰撞结束分离时会自动执行的函数
    private void OnCollisionExit(Collision other)
    {
        print(this.name + "被" + other.gameObject.name + "结束碰撞");
    }
    //两个物体相互接触摩擦时会 不停地调用这个函数
    private void OnCollisionStay(Collision other)
    {
        print(this.name + "被" + other.gameObject.name + "接触了");
    }
    #endregion

    #region 知识点二 触发器检测响应函数
    //第一次接触时会自动调用
    private void OnTriggerEnter(Collider other)
    {

    }
    //结束接触时会自动调用
    private void OnTriggerExit(Collider other)
    {

    }
    //接触时就会调用
    private void OnTriggerStay(Collider other)
    {

    }
    #endregion

    #region 知识点三 要明确什么时候会响应函数
    //1.只要挂载的对象 能和别的物体产生碰撞或者触发 那么对应的6个函数 就能相应
    //2.6个函数不是说都要写 要根据需求选择性的写
    //3.如果是一个异形物体,刚体在父对象上,如果你想通过子对象上挂脚本检测碰撞是不行的 必须挂载到这个刚体的父对象上才行
    //4.要明确 物理碰撞和触发器响应的区别
    #endregion

    #region 知识点四 碰撞和触发器可以写成虚函数 在子类重写逻辑
    //一般会把想要重写的 碰撞和触发函数 写成保护类型的 没有必要写成public 因为不要手动调用 都是通过Unity通过反射帮我们自动调用的
    #endregion
}
