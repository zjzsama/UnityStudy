using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson9 : MonoBehaviour
{
    public Transform son;
    void Start()
    {
        #region 知识点一 获取和设置父对象
        //获取父对象
        // print(this.transform.parent.name);
        //设置父对象 断绝父子关系
        this.transform.parent = null;
        //设置父对象 认爸爸
        this.transform.parent = GameObject.Find("Lesson9Father").transform;

        //通过API进行父子关系的设置
        this.transform.SetParent(null); //断绝父子关系
        // this.transform.SetParent(GameObject.Find("Lesson9Father").transform); //设置父子关系
        //参数一:设置父亲 参数二:是否保留世界坐标的 位置 角度 缩放
        //true 会保留 世界坐标系下的位置 和 父对象 进行计算 得到本地坐标系的位置
        //false 不会保留 会把世界坐标系下的 位置角度进行缩放 直接赋值到 本地坐标系下
        this.transform.SetParent(GameObject.Find("Lesson9Father").transform, true);
        #endregion

        #region 知识点二 抛妻弃子
        //与自己所有子对象断绝关系 没有父子关系了
        this.transform.DetachChildren();
        #endregion

        #region 知识点三 获取子对象
        //按名字查找
        //Find方法能找到失活对象的 GameObject相关的 不能找到失活的
        //只能找到自己儿子 不能找到自己孙子
        //虽然它的效率比 GameObject.Find相关 要高一些 但前提是要知道谁是父亲才能找
        this.transform.Find("Lesson9Cube");

        //遍历儿子
        //得到儿子数量 失活的儿子也会算数量 找不到孙子
        print(this.transform.childCount);
        //通过索引号 去得到自己对应的儿子
        //注意:如果编号超出了儿子数量范围 会报错
        this.transform.GetChild(0);
        for (int i = 0; i < this.transform.childCount; i++)
        {
            print("儿子的名字:" + this.transform.GetChild(i).name);
        }
        #endregion

        #region 知识点四 儿子的操作
        //判断自己的爸爸是谁
        //一个对象 判断自己是不是另一个对象的儿子
        if (son.IsChildOf(this.transform))
        {
            print("我是爸爸的儿子");
        }
        //得到自己作为儿子的编号
        print(son.GetSiblingIndex());
        //把自己设置成第一个儿子
        son.SetAsFirstSibling();
        //把自己设置成最后一个儿子
        son.SetAsLastSibling();
        //把自己设置成指定个儿子
        //就算填的数量超出了范围 不会报错 会将它变成最后一个编号
        son.SetSiblingIndex(0);
        #endregion
    }
}
