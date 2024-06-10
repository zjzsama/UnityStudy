using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lesson16 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 DropDown是什么

        // DropDown是下拉列表组件
        // 是UGUI中用于处理下拉列表相关交互的关键组件

        // 默认创建的DropDown由四组对象组成
        // 父对象
        // DropDown组件依附的对象 还有一个Image组件 作为背景图

        // 子对象
        // Label是当前选项描述
        // Arrow右侧小箭头
        // Template下拉列表选单

        #endregion

        #region 知识点二 DropDown参数

        #endregion

        #region 知识点三 代码控制
        Dropdown dd = GetComponent<Dropdown>();
        print(dd.value);
        print(dd.options[dd.value].text);
        dd.options.Add(new Dropdown.OptionData("123123"));
        #endregion

        #region 知识点四 监听事件的两种方式
        // 1.拖脚本
        // 2.代码添加
        dd.onValueChanged.AddListener((value) =>
        {
            print("代码监听的函数" + value);
        }
        );
        #endregion
    }

    public void ChangeValue(int value)
    {
        print(value);
    }
}
