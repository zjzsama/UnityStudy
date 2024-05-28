using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson1_PlayerPrefs : MonoBehaviour
{
    void Start()
    {
        #region 知识点一 PlayerPrefs是什么
        //是Unity提供的可以用于存储读取玩家数据的公共类
        #endregion

        #region 知识点二 存储相关
        //PlayerPrefs的数据存储 类似于键值对存储 一个键对应一个值
        //提供了存储三种数据的方法 int float string
        //键:string类型
        //值:int float string 对应三种API

        PlayerPrefs.SetInt("myAge", 20);
        PlayerPrefs.SetFloat("myHeight", 175.5f);
        PlayerPrefs.SetString("myName", "君哲");

        //直接调用set方法只会把数据存入内存里
        //当游戏结束时 Unity会自动把数据存档硬盘中
        //如果游戏不是正常结束 而是崩溃 数据不会存到硬盘中

        PlayerPrefs.Save();//只要调用该方法 就会马上存到硬盘中

        //PlayerPrefs是有局限性的 它只能存三种类型的数据
        //如果你想要存储别的类型 只能降低精度 或者上升精度来进行存储
        bool sex = true;
        PlayerPrefs.SetInt("mySex", sex ? 1 : 0);

        //如果不同类型用同一键名进行存储 会进行覆盖
        PlayerPrefs.SetFloat("myAge", 19.5f);
        #endregion

        #region 知识点三 读取相关
        //注意 运行时 只要你Set了对应键值对
        //即使你没有马上存储Save在本地
        //也能读取出信息

        //int
        int age = PlayerPrefs.GetInt("myAge"); //找不到信息的int默认值是0
        print(age);
        age = PlayerPrefs.GetInt("myAge", 25); //前提是找不到myAge对应的值 就会返回函数的第二个参数 默认值
        print(age);
        //float
        float myHeight = PlayerPrefs.GetFloat("myHeight", 1000f);
        print(myHeight);

        //string
        string myName = PlayerPrefs.GetString("myName");
        print(myName);

        //第二个参数默认值 对于我们的作用
        //就是在 得到没有的数据的时候 就可以用它进行基础数据的优化

        //判断数据是否存在
        if (PlayerPrefs.HasKey("myAge"))
        {
            print("存在myAge对应的键值对信息");
        }
        #endregion

        #region 知识点四 删除数据
        //删除指定键值对信息
        PlayerPrefs.DeleteKey("myAge");
        //删除所有存储的信息
        PlayerPrefs.DeleteAll();
        #endregion
    }

    void Update()
    {

    }
}
