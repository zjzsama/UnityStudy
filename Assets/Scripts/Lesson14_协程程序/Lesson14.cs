using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Lesson14 : MonoBehaviour
{
    Thread t;

    // 声明一个变量作为一个公共内存容器
    Queue<Vector3> queue = new Queue<Vector3>();
    Queue<Vector3> queue2 = new Queue<Vector3>();

    void Start()
    {
        #region 知识点一 Unity是否支持多线程?
        // 首先明确一点
        // Unity支持多线程
        // 只是新开的线程无法访问Unity相关对象的内容

        // 注意:Unity的多线程 要记得关闭
        t = new Thread(Test);
        t.Start();
        #endregion

        #region 知识点二 协同程序是什么?
        // 简称协程
        // 假的多线程,不是多线程

        // 主要作用
        // 将代码分时执行,不会卡主线程
        // 简单理解,是把可能会让主线程卡顿的耗时的逻辑分时分布进行

        // 主要使用场景
        // 异步加载文件
        // 异步下载文件
        // 场景异步加载
        // 批量创建时防止卡顿

        #endregion

        #region 知识点三 协同程序和线程的区别
        // 新开一个线程是独立的一个管道,和主线程并行执行
        // 新开一个协程是在原线程之上开启,进行逻辑分时分布执行
        #endregion

        #region 知识点四 协程的使用
        // 继承MonoBehaviour的类 都可以开启协程
        // 第一步:声明协程函数
        // 协程函数的两个关键点
        // 1-1.返回值为IEnumerator类型及其子类
        // 1-2.函数中通过yield return 返回值进行返回

        // 第二步:开启协程函数

        // 这样执行没有任何效果,不能够这样执行!!
        // MyCoroutine(1, "123");

        IEnumerator ie = MyCoroutine(1, "123");
        // 常用开启方式
        Coroutine c1 = StartCoroutine(MyCoroutine(1, "123"));
        // StartCoroutine(ie);

        // 第三步:关闭协程

        // 关闭所有协程
        // StopAllCoroutines();

        // 关闭指定协程
        StopCoroutine(c1);
        #endregion

        #region 知识点五 yield return 不同内容的含义
        // 1.下一帧执行
        // yield return 数字;
        // yield return null;
        // 在Update和LateUpdate之间执行

        // 2.等待执行秒后执行
        // yield return new WaitForSeconds(1f);
        // 在Update和LateUpdate之间执行

        // 3.等待下一个固定物理帧更新时执行
        // yield return new WaitForFixedUpdate();
        // 在FixedUpdate和碰撞检测相关函数之后执行

        // 4.等待摄像机和GUI渲染之后执行
        // yield return new WaitForEndOfFrame();
        // 在LateUpdate之后的渲染相关处理完毕之后

        // 5.一些特殊类型的对象 比如异步加载相关函数返回的对象
        // 一般在Update和LateUpdate之间执行

        // 6.跳出协程
        // yield break;
        #endregion

        #region 知识点六 协程收对象和组件失活销毁的影响
        // 协程开启后
        // 组件和物体销毁,协程不执行
        // 物体失活协程不执行,组件失活协程不执行
        // 单独失活脚本 协程继续执行
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        if (queue.Count > 0)
        {
            this.transform.position = queue.Dequeue();
        }
    }
    private void Test()
    {
        while (true)
        {
            //只能在主线程中使用
            // this.transform.Translate(Vector3.right * Time.deltaTime);
            Thread.Sleep(1000);
            // 相当于模拟复杂算法 算出了一个结果 然后放入公共容器中
            System.Random r = new System.Random();
            queue.Enqueue(new Vector3(r.Next(-10, 10), r.Next(-10, 10), r.Next(-10, 10
            ))
            );
            print("新开线程");
        }
    }
    private void OnDestroy()
    {
        t.Abort();
        t = null;
    }
    // 关键点一:协同程序函数 返回值 必须是 IEnumerator或者继承它的类型
    IEnumerator MyCoroutine(int i, string str)
    {
        print(i);
        // 关键点二:协程函数 必须使用yield return进行返回
        yield return new WaitForSeconds(1f);
        print(str);
        yield return new WaitForSeconds(1f);
        print("协程执行完毕");
        // 主要用来 截图时 会使用
        yield return new WaitForEndOfFrame();
    }
}
