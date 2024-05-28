using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson4_A : MonoBehaviour
{
    //2.通过公共成员变量进行关联
    //虽然方法简单 但是有一点破坏面向对象思想的结构
    //现在相当于A 有一个特征是 B
    // public Lesson4_B b;
    void Start()
    {
        //找对象有几种方法
        //1.通过GameObject提供的查找对象的方法

        //要控制别人 那就要得到你要控制的对象
        //先找到 然后去做
        GameObject B = GameObject.Find("Lesson4_B"); //先找到名字叫Lesson4_B的对象
        Lesson4_B l4b = B.GetComponent<Lesson4_B>(); //然后再得到该对象上挂载的某一个脚本 然后进行操作即可
        if (l4b != null)
        {
            l4b.enabled = false;
        }
        // b.enabled = false;
    }


    void Update()
    {

    }
}
