using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson18 : MonoBehaviour
{
    private Texture tex;
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 Resources异步加载是什么?
        // 如果我们加载过大的资源可能会造成程序卡顿
        // 卡顿的原因就是 硬盘上读取数据到内存 是需要进行计算的
        // 越大的资源 耗时越长 就会造成掉帧卡顿

        // Resources异步加载 就是内部断开一个线程进行资源加载 不会造成主线程卡顿
        #endregion

        #region 知识点二 Resources异步加载方法
        // 注意:
        // 异步加载 不能马上得到加载的资源 至少要等一帧

        // 1.通过异步加载中的完成事件监听 使用加载的资源
        // 这句代码 可以理解为Unity在内部 会去开一个线程进行资源下载
        ResourceRequest rq = Resources.LoadAsync<Texture>
        ("Tex/Test");
        // 马上进行一个 资源下载结束 的一个事件监听
        rq.completed += LoadOver;


        // 2.通过协程 使用加载的资源
        StartCoroutine(Load());
        #endregion

        #region 总结
        // 1.完成事件监听异步加载
        // 好处:写法简单
        // 坏处:只能在资源加载结束后 进行处理
        // "线性加载"

        // 2.协程异步加载
        // 好处:可以在协程中处理复杂逻辑 比如同时加载多个资源 比如进度条更新
        // 坏处:写法稍麻烦
        // "并行加载"

        // 注意:
        // 理解为什么异步加载不能马上加载结束 为什么至少要等1帧
        // 理解协程异步加载的原理
        #endregion
    }

    private void LoadOver(AsyncOperation rq)
    {
        tex = (rq as ResourceRequest).asset
         as Texture;
        print("加载结束");
    }
    IEnumerator Load()
    {
        // 迭代器函数 当遇到yield return 是就会 停止之后执行的代码
        // 然后协程调度器 通过得到返回的值 去判断 下一次执行后面的步骤 将会是何时
        ResourceRequest rq = Resources.LoadAsync<Texture>("Tex/Test");
        // 判断资源是否加载结束
        while (!rq.isDone)
        {
            // 打印当前的加载进度
            // 该进度不会特别准确 过度也不是特别明显
            print(rq.priority);
        }
        // 第一部分
        // Unity自己知道 该返回值 意味着你在异步加载资源
        yield return rq;
        // Unity会自己判断 该资源是否加载完毕了 加载完毕过后 才会继续执行后面的代码
        tex = rq.asset as Texture;

        yield return null;

        // 第二部分
        yield return new WaitForSeconds(2f);

        // 第三部分
    }
    private void OnGUI()
    {
        if (tex != null)
        {
            GUI.DrawTexture(new Rect(0, 0, 100, 100), tex);
        }

    }
}
