﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Lesson61 : MonoBehaviour
{
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        #region 知识点一 导航网格寻路组件用来干什么的?
        // 通过上节课导航网格生成知识点的学习
        // 我们已经准备好了地形相关的数据
        // 知道地形上哪些地方可以到达 哪些不能
        // 那么寻路组件的作用就是帮助我们让角色可以在地形上准确的移动起来

        // 寻路组件的本质就是根据烘焙出的寻路网格信息
        // 通过基于A星寻路的算法计算出行进路径让我们在该路径上移动起来
        #endregion

        #region 知识点二 导路组件参数相关
        // 导航网格寻路组件
        // Nav Mesh Agent(导航网格代理人)
        #endregion

        #region 知识点三 导路组件代码相关

        #region 常用内容
        // 自动寻路设置目标点
        //agent.SetDestination()
        // 停止寻路
        //agent.isStopped = true;
        #endregion

        #region 不常用内容

        #region 变量
        // 关键变量
        // 1.面板参数相关 速度 加速度 旋转速度等等
        //print(agent.speed);
        //print(agent.acceleration);
        //print(agent.angularSpeed);
        // 2.其他重要属性
        // 2-1 当前是否有路径
        //if (agent.hasPath)
        //{

        //}
        // 2-2 代理目标点 可以设置 也可以得到
        //print(agent.destination);
        // 2-3 是否停止 可以得到也可以设置
        //print(agent.isStopped);
        // 2-4 当前路径
        //print(agent.path);
        // 2-5 路径是否在计算中
        //if (agent.pathPending)
        //{

        //}
        // 2-6 路径状态
        //print(agent.pathStatus);
        // 2-7 是否更新位置
        //agent.updatePosition = true;
        // 2-8 是否更新角度
        //agent.updateRotation = false;
        // 2-9 代理速度
        //print(agent.velocity);
        #endregion

        #region 方法
        // 手动寻路
        // 计算生成路径
        //NavMeshPath path = new NavMeshPath();
        //if (agent.CalculatePath(Vector3.zero, path))
        //{

        //}
        // 设置新路径
        //if (agent.SetPath(path))
        //{

        //}
        // 清除路径
        //agent.ResetPath();
        // 调整到指定点位置
        //agent.Warp(Vector3.zero);

        #endregion

        #endregion

        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            agent.isStopped = false;
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                print(hit.collider.name);
                // 让对象朝目标点移动 先生成移动路径 再移动
                agent.SetDestination(hit.point);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            agent.isStopped = true;
        }
    }
}
