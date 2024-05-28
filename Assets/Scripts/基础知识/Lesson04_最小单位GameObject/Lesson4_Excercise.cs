using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson4_Excercise : MonoBehaviour
{
    public GameObject tankPrefab;
    void Start()
    {
        #region 练习题一
        //1.一个空物体挂了一个脚本,游戏运行时该脚本可以 实例化出之前的 坦克预设体
        //一般情况下 我们实例化的对象 都是克隆的预设体 但是也可以拖场景的对象进行克隆
        GameObject tankObj = GameObject.Instantiate(tankPrefab);
        tankObj.name = "坦克";

        //找一个对象克隆
        // GameObject obj = GameObject.Find("Tank");
        // if (obj != null)
        // {
        //     //继承MonoBehaviour的类 可以不写前面的内容
        //     Instantiate(obj);
        // }
        #endregion

        #region 练习题二
        //2.一个脚本A一个脚本B 脚本A挂在A对象上,脚本B挂在B对象上
        //实现在A脚本的Strat函数中将B对象上的B脚本失活(用GameObject相关知识做)
        #endregion

        #region 练习题三
        //3.一个对象A和对象B,在A上挂一个脚本
        //通过这个脚本可以让脚本B改名,失活,延迟删除,立刻删除
        //可以在Inspector窗口进行设置,让B实现不同的效果(提示:GameObject,枚举)
        #endregion
    }

    void Update()
    {

    }
}
