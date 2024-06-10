using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lesson23 : MonoBehaviour
{
    public Image img;
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 什么是异形按钮
        // 图片形状不是传统矩形的形状
        #endregion

        #region 知识点二 如何让异形按钮能够准确点击

        #region 方法一 添加子对象
        // 按钮之所以能响应点击 主要根据图片矩形范围进行判断
        // 它的范围判断是自下而上的 意思是如果有子对象图片 子对象图片的范围也会算为 可点击范围
        // 那么我们就可以哟个多个透明图拼凑不规则图形 作为按钮子对象用于进行射线检测

        // 这个方法内存消耗小
        #endregion

        #region 方法二 代码改变图片透明度相应阈值
        // 1.修改图片参数 开启Read/Write Enabled开关
        // 2.通过代码修改图片的响应阈值

        // 该参数含义:指定一个像素必须具有的最小alpha值 以便能够认为射线命中了图片
        // 说人话:当像素点alpha小于 该值 就不会被射线检测
        // 但是内存消耗比前一种大 效果比上一种好 用性能换效果
        img.alphaHitTestMinimumThreshold = 0.1f;

        #endregion

        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
