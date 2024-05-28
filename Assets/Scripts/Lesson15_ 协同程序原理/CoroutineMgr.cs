using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class YieldReturnTime
{
    public IEnumerator ie;
    public float time;
}
public class CoroutineMgr : MonoBehaviour
{
    private static CoroutineMgr instance;
    public static CoroutineMgr Instance => instance;

    // 声明存储容器
    private List<YieldReturnTime> list = new List<YieldReturnTime>();
    private void Awake()
    {
        instance = this;
    }
    public void MyStartCoroutine(IEnumerator ie)
    {
        // 来进行分步走 分时的逻辑

        // 传入一个迭代器函数返回的结构 那么应该一来就执行它
        // 一来就先执行第一步 执行完了如果返现 返回true 证明 后面还有步骤
        if (ie.MoveNext())
        {
            // 判断 如果yield return的返回是一个数字 那就证明需要等待n秒继续执行
            if (ie.Current is int)
            {
                // 按思路应该把这个迭代器函数 和他下一次执行的时间点 记录下来
                YieldReturnTime yrt = new YieldReturnTime();
                yrt.ie = ie;
                yrt.time = Time.time + (int)ie.Current;
                // 把记录的信息 记录到数据容器中 因为可能有多个协程函数开启 所以用一个list来存储
                list.Add(yrt);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 为了避免循环的时候 移除列表内容 倒着遍历
        for (int i = list.Count - 1; i >= 0; i--)
        {
            // 判断当前迭代器函数 是否到了下一次要执行的时间
            // 如果到了 执行下一步
            if (list[i].time <= Time.time)
            {
                if (list[i].ie.MoveNext())
                {
                    // 如果是true那么还需要进行处理
                    if (list[i].ie.Current is int)
                    {
                        // 如果返回的是一个数字 证明 需要等待n秒继续执行
                        list[i].time = Time.time + (int)list[i].ie.Current;
                    }
                    else
                    {
                        // 该list 只是存储 处理时间相关 等待逻辑的 迭代器函数的
                        // 如果是别的类型 就不应该存在这个list中
                        list.RemoveAt(i);
                    }
                }
                else
                {
                    // 否则 移除这个迭代器函数
                    list.RemoveAt(i);
                }
            }
        }

    }
}
