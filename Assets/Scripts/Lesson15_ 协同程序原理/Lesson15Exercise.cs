using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson15Exercise : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 练习题一
        // 不使用Unity自带的协程协调器开启协程
        // 通过迭代器函数实现每隔一秒执行函数中的一部分逻辑
        // StartCoroutine(MyTest());
        CoroutineMgr.Instance.MyStartCoroutine(MyTest());
        #endregion
    }

    IEnumerator MyTest()
    {
        print("1");
        yield return 1; //如果自带的开启 数字代表等待1帧开启后面的内容
        print("2");
        yield return 2;
        print("3");
        yield return 3;
        print("4");
    }
}
