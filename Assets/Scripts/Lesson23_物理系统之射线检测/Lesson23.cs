using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson23 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 什么是射线检测
        // 物理系统中
        // 目前我们学习的物体相交判断
        // 1.碰撞检测--必备条件 1.刚体 2.碰撞器
        // 2.范围检测--必备条件 碰撞器

        // 如果想要这样的碰撞检测呢?
        // 1.鼠标选择场景上一物体
        // 2.FPS设计游戏(无弹道-不产生实际的子弹对象进行移动)
        // 等等 需要判断一条线和物体的碰撞情况

        // 射线检测 就是来解决这些问题的
        // 它可以在指定点发射一个指定方向的射线
        // 判断该射线与哪些碰撞器相交
        #endregion

        #region 知识点二 射线对象
        // 1.3D世界中的射线
        // 假设有一条
        // 起点为坐标(1,0,0)
        // 方向为世界坐标Z轴正方向的射线
        // 注意:
        // 理解参数含义
        // 参数一:起点
        // 参数二:方向(一定记住 不是两点决定射线方向 第二个参数直接代表方向向量)
        // Ray中的参数
        // 目前只是声明了一个 射线对象 没有任何用处
        Ray r = new Ray(Vector3.right, Vector3.forward);

        // Ray的参数
        print(r.origin);// 起点
        print(r.direction);// 方向

        // 2.摄像机发出的射线
        // 得到一条从屏幕位置作为起点
        // 摄像机视口方向为 方向的射线
        Ray r2 = Camera.main.ScreenPointToRay(Input.mousePosition);

        // 注意:
        // 单独的射线对我们来说没有实际的意义
        // 我们需要用它结合物理系统进行射线碰撞判断
        #endregion

        #region 知识点三 碰撞检测函数
        // Physics 类中提供了很多进行射线检测的静态函数
        // 他们中有很多种重载类型 我们只需要掌握核心的几个函数 其他函数自然就明白什么意思了
        // 注意:
        // 射线检测是瞬时的
        // 执行代码时进行一次射线检测

        // 1.最原始的射线检测
        // 准备一条射线
        Ray r3 = new Ray(Vector3.zero, Vector3.forward);

        // 进行射线检测时 如果碰撞到对象 返回true
        // 参数一:射线
        // 参数二:检测的最大距离 超出这个距离不检测
        // 参数三:检测指定层级(不填检测所有层)
        // 参数四:是否忽略触发器 UseGlobal-使用全局设置 Collide-检测触发器 Ignore-忽略触发器 不填使用UseGlobal
        // 返回值:bool 当碰撞到对象时 返回true 没有 返回false
        if (Physics.Raycast(r3, 1000f, 1 << LayerMask.NameToLayer("Enemy"), QueryTriggerInteraction.UseGlobal))
        {
            print("碰撞到了对象");
        }

        // 还有一种重载 不用穿入射线 直接传入起点和方向 也可以用于判断
        // 就是把第一个参数射线 变成了 射线的两个点 一个起点一个方向
        if (Physics.Raycast(Vector3.zero, Vector3.forward, 1 << LayerMask.NameToLayer("Enemy")))
        {
            print("碰撞到了对象");
        }

        // 2.获取相交的单个物体信息
        // 物体信息类 RaycastHit

        // 参数一:射线
        // 参数二:RaycastHit是结构体 是值类型 Unity会通过out 关键字 在函数内部处理后返回到该参数中
        // 参数三:检测的最大距离 超出这个距离不检测
        // 参数四:检测指定层级(不填检测所有层)
        // 参数五:是否忽略触发器 UseGlobal-使用全局设置 Collide-检测触发器 Ignore-忽略触发器 不填使用UseGlobal
        RaycastHit hitinfo;
        if (Physics.Raycast(r3, out hitinfo, 1000f, 1 << LayerMask.NameToLayer("Enemy"), QueryTriggerInteraction.UseGlobal))
        {
            print("碰撞到了对象");
            print("碰撞到的位置:" + hitinfo.point);
            print("碰撞到的法线:" + hitinfo.normal);
            print("碰撞到的物体:" + hitinfo.collider.name);
            print("碰撞到的对象离自己的距离:" + hitinfo.distance);
        }

        // 还有一种重载 不用穿入射线 直接传入起点和方向 也可以用于判断
        // 就是把第一个参数射线 变成了 射线的两个点 一个起点一个方向
        if (Physics.Raycast(Vector3.zero, Vector3.forward, out hitinfo, 1 << LayerMask.NameToLayer("Enemy")))
        {
            print("碰撞到了对象");
            print("碰撞到的位置:" + hitinfo.point);
            print("碰撞到的法线:" + hitinfo.normal);
            print("碰撞到的物体:" + hitinfo.collider.name);
            print("碰撞到的对象离自己的距离:" + hitinfo.distance);
        }

        // 3.获取的相交的多个物体
        // 可以得到碰撞的多个对象
        // 如果没有 就是容量为0的数组
        // 参数一:射线
        // 参数二:检测的最大距离 超出这个距离不检测
        // 参数三:检测指定层级(不填检测所有层)
        // 参数四:是否忽略触发器 UseGlobal-使用全局设置 Collide-检测触发器 Ignore-忽略触发器 不填使用UseGlobal
        RaycastHit[] hits = Physics.RaycastAll(r3, 1000f, 1 << LayerMask.NameToLayer("Enemy"), QueryTriggerInteraction.UseGlobal);
        foreach (var item in hits)
        {
            print("碰撞到的所有物体 名字分别是" + item.collider.name);
        }
        // 4.射线检测的函数
        // 参数一:射线
        // 参数二:检测的最大距离 超出这个距离不检测
        // 参数三:检测指定层级(不填检测所有层)
        // 还有一种重载 不用穿入射线 直接传入起点和方向 也可以用于判断
        // 就是把第一个参数射线 变成了 射线的两个点 一个起点一个方向

        // 还有一种函数 返回的碰撞的数量 通过out得到数据
        Physics.RaycastNonAlloc(r3, hits, 1000f, 1 << LayerMask.NameToLayer("Enemy"));
        #endregion

        #region 知识点四 使用时注意的问题
        // 注意:
        // 距离 层级两个参数 都是int类型
        // 当我们传入参数时 一定要明确传入的参数代表的是距离还是层级
        // 举例
        // 这样写是错误的 因为第二个参数 代表的是距离 不是层级
        // Physics.Raycast(r3, 1 << LayerMask.NameToLayer("Enemy"));
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
