using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Lesson11Exercise
{
    #region 练习题1
    // 利用四元数的LookRotation方法实现LookAt效果
    #endregion

    #region 练习题2
    // 将之前摄像机移动的练习题中的LookAt换成LookRotation实现并且通过Slerp来缓慢看向玩家
    #endregion
    // 1.
    public static void MyLookAt(this Transform obj, Transform target)
    {
        Vector3 vec = target.position - obj.position;
        obj.rotation = Quaternion.LookRotation(vec);
    }

    // 2.在Lesson8Exercise中
}
