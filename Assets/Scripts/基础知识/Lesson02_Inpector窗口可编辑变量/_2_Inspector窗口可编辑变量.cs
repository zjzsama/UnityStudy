using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_Test
{
    player,
    monster,
    boss,
}
[System.Serializable]
public struct Mystruct
{
    public int age;
    public bool sex;
}
[System.Serializable]
public class MyClass
{
    public int age;
    public bool sex;
}
public class _2_Inspector窗口可编辑变量 : MonoBehaviour
{
    #region Inspector显示的可编辑内容就是脚本的成员变量

    #endregion

    #region 知识点一 私有和保护无法显示编辑
    private int i1;
    protected int i2;
    #endregion

    #region 知识点二 让私有和保护的也可以显示
    // 加上强制序列化字段特性
    // [SerializeField]
    // 所谓序列化就是把一个对象保存到一个文件或数据库字段中去
    [SerializeField]
    private int privateInt;
    [SerializeField]
    protected string protectedString;
    #endregion

    #region 知识点三 公共的可以显示编辑
    public int publicInt;
    public bool publicBool;
    #endregion

    #region 知识点四 公共的也不让显示编辑
    // 在变量前加上特性 [HideInInspector]
    [HideInInspector]
    public int publicInt2 = 50;
    #endregion

    #region 知识点五 大部分类型都能显示编辑
    public int[] array;
    public List<int> list;
    public E_Test type;
    public GameObject gameObj;
    Dictionary<int, string> dic;
    // 自定义类型变量
    public Mystruct structVar;
    public MyClass classVar;
    #endregion

    #region 知识点六 让自定义类可以被访问
    // 加上序列化特性
    // [System.Serializable]
    // 字典怎样都不行
    #endregion

    #region 知识点七 一些辅助特性
    // 分组说明特性Header
    //为成员分组
    // [Header("成员变量")]
    [Header("基础属性")]
    public int baseInt;

    // 2.悬停注释ToolTip
    // 为变量添加说明
    // [ToolTip("说明内容")]
    [Tooltip("闪避")]
    public int miss;

    // 3.间隔特性 Space()
    // 让两个字段间出现间隔
    // [Space()]
    [Space()]
    public int space;

    // 4.修饰数值的滑条范围Range
    // [Range(最大值,最小值)]
    [Range(0, 100)]
    public float luck;

    // 5.多行显示字符串 默认不写参数显示三行
    // 写参数就是对应行
    // [Multiline(4)]
    [Multiline(5)]
    public string tips;

    // 6.滚动条显示字符串
    // 默认不写参数就是三行滚动条
    // [TextArea(3,4)]
    // 最少显示三行,最多四行,超过四行就显示滚动条
    [TextArea(3, 4)]
    public string tips2;

    // 7.为变量添加快捷方法
    // [ContextMenu("显示按钮名", "方法名")]
    // 参数一 显示按钮名
    // 参数二 方法名 不能有参数
    [ContextMenuItem("重置钱", "Test")]
    public int money;
    private void Test()
    {
        money = 99;
    }

    // 8.为方法添加特性能够在Inspector内被执行
    // [ContextMenu("测试函数")]
    [ContextMenu("哈哈哈哈")]
    private void TestFun()
    {
        print("测试方法");
    }
    #endregion

    #region 注意
    // 1.Inspector窗口中的变量关联的就是对象的成员变量,运行时改变他们就是改变成员变量
    public int i;
    // 2.拖拽到GameObject对象后 再改变脚本中变量默认值 界面上不会改变
    // 3.运行中修改的信息不会保存
    #endregion

    private void Update()
    {
        print(i);
    }
}
