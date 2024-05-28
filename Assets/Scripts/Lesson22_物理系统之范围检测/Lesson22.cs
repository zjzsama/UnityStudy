using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson22 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识回顾 物理系统之碰撞检测
        // 碰撞产生的必要条件
        // 1.至少一个物体有刚体
        // 2.两个物体都必须有碰撞器

        // 碰撞和触发
        // 碰撞会产生实际的物理效果
        // 触发看起来不会产生碰撞但是可以通过函数监听来触发

        // 碰撞检测主要用于实体物体之间产生物理效果时使用
        #endregion

        #region 知识点一 什么是范围检测
        // 游戏中瞬时的攻击范围判断一般会使用范围检测
        // 举例:
        // 1.玩家在前方5m处释放一个地刺魔法,在此处范围内的对象将受到地刺伤害
        // 2.玩家攻击,在前方1m圆形范围内的对象都受到伤害 等等
        // 类似这种没有实体物体 只想要检测在指定某一范围是否让敌方受到伤害时 便可以使用范围判断
        // 简而言之
        // 在指定位置 进行 范围判断 我们可以得到处于指定范围内的对象
        // 目的是对 对象进行处理 比如受伤 减血等等
        #endregion

        #region 知识点二 如何进行范围检测
        // 必备条件:想要被范围检测到的对象 必须具备碰撞器
        // 注意点:
        // 1.范围检测相关API 只有当执行该句代码时 进行一次范围检测 它是瞬时的
        // 2.范围检测相关API 并不会产生一个真正的碰撞器 只是碰撞判断计算而已

        // 范围检测API
        // 1.盒装范围检测
        // 参数一:立方体中心点
        // 参数二:立方体三边大小
        // 参数三:立方体角度
        // 参数四:检测指定层级(不填检测所有层级)
        // 参数五:是否忽略触发器 UseGlobal-使用全局设置 Collide-检测触发器 Ignore-忽略触发器 不填使用UseGlobal
        // 返回值:在该范围内的触发器(得到了对象触发器就可以得到对象的所有信息)
        print(LayerMask.NameToLayer("Player"));
        Collider[] colliders = Physics.OverlapBox(Vector3.zero, Vector3.one, Quaternion.AngleAxis(45, Vector3.up), 1 << LayerMask.NameToLayer("UI"), QueryTriggerInteraction.UseGlobal);
        for (int i = 0; i < colliders.Length; i++)
        {
            print(colliders[i].gameObject.name);
        }
        // 重要知识点:
        // 关于层级
        // 通过名字得到层级编号 LayerMask.NameToLayer
        // 我们需要通过编号左移构建二进制数
        // 这样每一个编号的层级 都是 对应位为1的2进制
        // 我们通过位运算 可以选择想要检测层级
        // 好处 一个int 就可以表示所有想要检测的 层级信息

        // 层级编号是0~31 刚好32位
        // 是一个int数

        // 另一个API
        // 返回值: 检测到的碰撞器数量
        // 参数:传入一个数组进行存储
        // Physics.OverlapBoxNonAlloc()
        if (Physics.OverlapBoxNonAlloc(Vector3.zero, Vector3.one, colliders) != 0)
        {

        }

        // 2.球形范围检测
        // 参数一:中心点
        // 参数二:球半径
        // 参数三:检测指定层级(不填检测所有层)
        // 参数四:是否忽略触发器 UseGlobal-使用全局设置 Collide-检测触发器 Ignore-忽略触发器 不填使用UseGlobal
        // 返回值:在该范围内的触发器(得到了对象触发器就可以得到对象的所有信息)
        Collider[] colliders2 = Physics.OverlapSphere(Vector3.zero, 5f, 1 << LayerMask.NameToLayer("UI"));

        // 另一个API
        // 返回值: 检测到的碰撞器数量
        // 参数:传入一个数组进行存储
        //  Physics.OverlapSphereNonAlloc()
        if (Physics.OverlapSphereNonAlloc(Vector3.zero, 5f, colliders2) != 0)
        {

        }
        #endregion

        // 3.胶囊范围检测
        // 参数一:半圆一中心点
        // 参数二:半圆二中心点
        // 参数三:半圆半径
        // 参数四:检测指定层级(不填检测所有层)
        // 参数五:是否忽略触发器 UseGlobal-使用全局设置 Collide-检测触发器 Ignore-忽略触发器 不填使用UseGlobal
        // 返回值:在该范围内的触发器(得到了对象触发器就可以得到对象的所有信息)
        Collider[] colliders3 = Physics.OverlapCapsule(Vector3.zero, Vector3.up, 5f, 1 << LayerMask.NameToLayer("UI"));

        // 另一个API
        // 返回值: 检测到的碰撞器数量
        // 参数:传入一个数组进行存储
        //   Physics.OverlapCapsuleNonAlloc()
        if (Physics.OverlapCapsuleNonAlloc(Vector3.zero, Vector3.up, 5f, colliders3) != 0)
        {

        }
        {

        }
        #region 总结
        // 范围检测主要用于瞬时的碰撞范围检测
        // 主要掌握:
        // Physics类中的静态方法
        // 球形 盒装 胶囊三种API的使用
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
