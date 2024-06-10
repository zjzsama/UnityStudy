using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lesson18 : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IDragHandler
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 事件接口用来解决什么问题
        // 目前所有的控件都只提供了常用的事件监听列表
        // 如果想做一些类似长按,双击,拖拽等功能是无法制作的
        // 如果想让Image和Text,RawImage三大基础控件能够相应玩家输入也是无法制作的

        // 而事件接口就是能用来处理类似问题
        // 让所有控件都能够添加更多的事件监听来处理对应逻辑
        #endregion

        #region 知识点二 有哪些事件接口

        #region 常用事件接口
        //IPointerEnterHandler -OnPointer -当指针进入对象时调用(鼠标进入)
        //IPointerExitHandler-0nPointerExit-当指针退出对象时调用 (鼠标离开)
        //IPointerDownHandler -0nPointerDown-在对象上按下指针时调用(按下)
        //IPointerupHandler - 0nPointerup - 松开指针时调用(在指针正在点击的游戏对象上调用)(抬起)
        //IPointerclickHandler- 0nPointerclick- 在同一对象上按下再松开指针时调用 (点击)

        //IBeginDragHandler-0nBeginDrag-即将开始拖动时在拖动对象上调用(开始拖拽)
        //IDragHandler-0nDrag-发生拖动时在拖动对象上调用(拖拽中)
        //IEndDragHandler-0nEndDrag-拖动完成时在拖动对象上调用(结束拖拽)
        #endregion

        #region 不常用事件接口 了解即可
        // IInitializePotentialDragHandler-0nInitializePotentialDrag- 在找到拖动目标时调用，可用于初始化值
        //IDropHandler-OnDrop-在拖动标对象上调用
        //IScrollHandler-OnScro11-当鼠标滚轮滚动时调用
        //IUpdateSelectedHandler- 0nUpdateselected -每次勾选时在选定对象上调用

        //ISelectHandler-OnSelect-当对象成为选定对象时调用
        //IDeselectHandler-0nDeselect-取消选择选定对象时调用

        //导航相关
        //IMoveHandler-0nMove -发生移动事件(上、下、左、右等)时调用
        //ISubmitHandler -OnSubmit - 按下 submit 按钮时调用
        //ICancelHandler- OnCancel-按下Cancel 按钮时调用

        #endregion

        #endregion

        #region 知识点三 使用事件接口
        // 1.继承MonoBehaviour的脚本继承对应的事件接口,引用命名空间
        // 2.实现接口中的内容
        // 3.将该脚本挂载到想要监听的自定义事件的UI控件上
        #endregion

        #region 知识点四 PointerEventData参数的关键内容
        // 父类:BaseEventData

        // pointerId:鼠标左右中键点击鼠标的ID,通过它可以判断鼠标右键单击
        // position:当前指针位置(屏幕坐标系)
        // pressPosition:按下的时候鼠标的指针位置
        // delta:指针移动增量
        // clickCount:连击次数
        // clickTime:点击时间

        // pressEventCamera:最后一个OnPointerPress按下事件关联的摄像机
        // enterEventCamera:最后一个OnPointerEnter进入事件关联的摄像机
        #endregion

        #region 总结
        // 好处:
        // 需要监听自定义事件的控件挂载继承实现了接口的脚本就可以监听到一些特殊事件
        // 可以通过它实现长按,双击,拖拽的功能

        // 坏处:
        // 不方便管理,需要自己写脚本继承接口挂载到对应控件上,比较麻烦
        #endregion






    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // 鼠标进入 在移动设备上不存在 因为不存在进入的概念
        print("鼠标进入");
        print(eventData.pressPosition);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("鼠标(触屏)按下");
        print(eventData.pointerId);
        print(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("鼠标(触屏)抬起");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 鼠标离开 在移动设备上不存在 因为不存在进入的概念
        print("鼠标离开");
    }

    public void OnDrag(PointerEventData eventData)
    {
        print(eventData.delta);
    }
}
