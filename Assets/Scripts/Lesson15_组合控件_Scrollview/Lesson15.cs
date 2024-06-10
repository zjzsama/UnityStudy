using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lesson15 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 ScrollRect是什么
        // ScrollRect是滚动视图组件
        // 是UGUI中用于处理滚动视图相关交互的关键组件

        // 默认创建的ScrollRect由四组对象组成
        // 父对象--ScrollRect组件依附的对象 还有一个Image组件 为背景图
        // 子对象
        // Viewport控制滚动视图可视范围和内容显示
        // Scrollbar Horizontal 水平滚动条
        // Scrollbar Vertical 垂直滚动条
        #endregion

        #region 知识点二 ScrollRect参数

        #endregion

        #region 知识点三 代码控制
        ScrollRect sr = GetComponent<ScrollRect>();
        //改变内容大小 具体可以拖动范围 根据这个来
        // sr.content.sizeDelta = new Vector2(200, 200);
        sr.normalizedPosition = new Vector2(0, 0.5f);

        #endregion

        #region 知识点四 监听事件的两种方式
        // 1.拖脚本
        // 2.代码添加
        #endregion
    }

    public void ChangeValue(Vector2 v)
    {
        print(v);
    }
}
