using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson54 : MonoBehaviour
{
    private Animator animator;

    public Transform pos;
    public Transform pos2;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        #region 知识点一 如何进行IK控制
        // 1.在状态机的层级设置中开启IK通道(勾选IK Pass)
        // 2.继承MonoBehaviour的类中
        // Unity定义了IK的一个回调函数OnAnimatorIK
        // 我们可以在该函数中调用Unity提供的IK相关API来控制IK
        // 3.Animator中的IK相关API
        // SetLookAtWeight 设置头部IK权重
        // SetLookAtPosition 设置头部IK看向位置

        // SetIKPositionWeight 设置IK位置权重
        // SetIKRotationWeight 设置IK旋转权重

        // SetIKPosition 设置IK对应的位置
        // SetIKRotation 设置IK对应的角度

        // AvatarIKGoal枚举 四肢末端IK枚举
        #endregion

        #region 知识点二 IK反向动力学控制对于我们的意义
        // IK在游戏开发中的应用
        // 1.拾取某一件物品
        // 2.持枪或持弓箭瞄准某一个对象
        //等等
        #endregion

        #region 知识点三 关于OnAnimatorIK和OnAnimatorMove两个函数的理解
        // 我们可以简单理解这两个函数是两个和动画相关的特殊生命周期函数
        // 他们在Update之后LateUpdate之前调用
        // 他们会在每帧的状态机和动画处理完后调用
        // OnAnimatorIK在OnAnimatorMove之前调用
        // OnAnimatorIK中主要处理 IK运动相关逻辑
        // OnAnimatorMove主要处理 动画移动以修改根运动的回调逻辑

        // 他们的存在的目的只是多了一个调用时机 当每帧的动画和状态机逻辑处理完后调用
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnAnimatorIK(int layerIndex)
    {
        // 头部IK相关
        //weight:LookAt全局权重0~1
        //bodyWeight:LookAt身体权重0~1
        //headWeight:LookAt头部权重0~1
        //eyesWeight:LookAt眼睛权重0~1
        //clampsWeight:0表示角色运动时不受限制 1表示角色完全固定无法执行LookAt,0.5表示只能移动范围的一半
        animator.SetLookAtWeight(1, 0f, 1f);
        animator.SetLookAtPosition(pos.position);

        //四肢IK相关
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
        animator.SetIKPosition(AvatarIKGoal.RightHand, pos2.position);
        animator.SetIKRotation(AvatarIKGoal.RightHand, pos2.rotation);
    }
}
