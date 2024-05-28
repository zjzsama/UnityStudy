using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson13 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 什么是延迟函数
        // 延迟函数顾名思义
        // 就是会延迟执行的函数
        // 我们可以自己设定延时要执行的函数和具体延时时间
        // 是MonoBehaviour基类实现好的一个方法
        #endregion

        #region 知识点二 延迟函数的使用
        // 1.延迟函数
        // Invoke
        // 参数一: 函数名 字符串
        // 参数二: 延迟时间 秒为单位

        // 注意:
        // 1-1.延时函数第一个参数传入的是函数名字字符串
        // 1-2.延时函数没办法传入参数 只有包裹一层
        // 1-3.函数名必须是该脚本上申明的函数
        Invoke("DelayDoSomething", 1f);
        Invoke("TestFunc", 1f);
        Invoke("DelayDoSomething", 1f); //包裹有参函数调用

        // 2.延迟重复执行函数
        // InvokeRepeating
        // 参数一: 函数名 字符串
        // 参数二: 延迟时间 秒为单位
        // 参数三: 重复执行间隔时间 秒为单位
        InvokeRepeating("DelayDoSomethingRe", 1f, 1f);
        // 注意:
        //它的注意事项和延时函数一致

        // 3.取消延时函数
        // CancelInvoke
        // 3-1.取消改脚本上的所有延时函数的执行
        // CancelInvoke();
        // 3-2.指定函数名取消
        // 只要取消了指定延迟 不管之前该函数开启了多少次 延迟执行 都会统一取消
        CancelInvoke("DelayDoSomethingRe");

        // 4.判断是否有延迟函数
        if (IsInvoking())
        {
            print("存在延迟函数");
        }
        if (IsInvoking("DelayDoSomething"))
        {
            print("存在延迟函数DelayDoSomething");
        }
        #endregion

        #region 知识点三 延迟函数受对象失活销毁影响
        // 脚本依附对象失活
        // 延迟函数可以继续执行

        // 脚本依附对象销毁或者脚本移除
        // 延迟函数无法继续执行
        #endregion
    }

    private void DelayDoSomething()
    {
        print("DelayDoSomething");
        TestFunc(2);
    }
    private void TestFunc()
    {
        print("无参重载");
    }
    private void TestFunc(int i)
    {
        print("传入参数" + i);
    }
    private void DelayDoSomethingRe()
    {
        print("DelayDoSomethingRe");
    }
    void Update()
    {

    }
}
