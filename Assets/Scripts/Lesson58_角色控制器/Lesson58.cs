using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson58 : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 角色控制器是什么?
        // 角色控制器是让角色可以受制于碰撞,但是不会被刚体所牵制
        // 如果我们对角色使用刚体碰撞判断 肯呢个会出现一些奇怪的表现
        // 比如:
        // 1.在斜坡上往下滑动
        // 2.不加约束的情况碰撞可能让自己被撞飞
        // 等等
        // 而角色控制器会让角色表现得更加稳定
        // Unity提供了角色控制器脚本专门用于控制角色

        // 注意:
        // 添加角色控制器后 不用再添加刚体
        // 能检测碰撞函数
        // 能检测触发器函数
        // 能被射线检测
        #endregion

        #region 知识点二 角色控制器的使用
        // 1.参数相关
        // 2.代码相关
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        // 关键参数
        // 关键参数是否接触了地面
        if (characterController.isGrounded)
        {
            print("接触了地面");
        }
        // 关键方法
        // 受重力作用的移动
        //characterController.SimpleMove(Vector3.forward * 10 * Time.deltaTime);
        // 不受重力的移动
        //characterController.Move(Vector3.forward * 10 * Time.deltaTime);

        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("Speed", (int)Input.GetAxisRaw("Vertical"));
        characterController.SimpleMove(this.transform.forward * 80 * Time.deltaTime);
    }
}
