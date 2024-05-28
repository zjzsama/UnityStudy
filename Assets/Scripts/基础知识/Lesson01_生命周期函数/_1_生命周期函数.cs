using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _1_生命周期函数 : MonoBehaviour
{
    #region 知识点一 了解帧的概念
    //unity底层已经帮我们做好了死循环
    //我们需要学习unity的生命周期函数
    //利用它做好的规则来帮我们执行游戏逻辑
    #endregion

    #region 知识点二 生命周期函数的概念
    //所有继承了MonoBehaviour的脚本 最终都会挂载到GameObject游戏对象上
    //生命周期函数 就是该脚本对象依附的GameObject对象从出生到消亡整个生命周期中
    //会通过反射自动调用的一些特殊函数

    //unity帮助我们记录了一个GameObject对象依附了哪些脚本
    //会自动得到这些对象,通过反射执行一些固定名字的函数
    #endregion

    #region 知识点三 生命周期函数
    //注意:
    //生命周期函数的访问修饰符一般是private和protected
    //因为不需要再外部调用生命周期函数 都是unity自己帮我们调用的

    //当对象在创建时 才会调用该生命周期函数
    //Awake 是类似构造函数的存在 我们可以在一个类对象刚创建时 进行一些初始化操作
    private void Awake()
    {
        //在Unity中打印信息的两种方式
        //1.没有继承monobehaviour类
        Debug.Log("Awake");
        // Debug.LogWarning("警告");
        // Debug.LogError("错误");
        //继承了monobahaviour类 有一个现成的方法使用
        // print("123");
    }
    //对我们来说 想要当一个对象被激活时 进行一些逻辑处理 就可以写在这个函数中
    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }
    //主要作用还是用于初始化信息的 但是它相对于Awake来说要晚一点
    //因为它是在对象 进行第一次帧更新前才会进行的
    private void Start()
    {
        print("Start");
    }

    //它主要是用于物理更新的
    //它是每一帧都会执行的 但是这里的帧 与游戏帧不同 是物理帧
    //它的时间间隔可以在 project setting里面的Time去设置
    private void FixedUpdate()
    {
        print("FixedUpdate");
    }
    //主要用于处理游戏逻辑核心的更新函数
    private void Update()
    {
        print("Update");
    }
    //一般这个更新用来处理摄像机位置更新相关内容的
    //Update和LateUpdate之间 unity进行了一些处理 处理我们动画相关的更新
    private void LateUpdate()
    {
        print("LateUpdate");
    }

    //如果我们希望在一个对象失活时做一些处理 就可以在该函数写逻辑
    private void OnDisable()
    {
        print("OnDisable");
    }
    //
    private void OnDestroy()
    {

    }
    #endregion

    #region 知识点四 生命周期函数 支持继承多态

    #endregion
}
