using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lesson20 : MonoBehaviour, IDragHandler
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 RectTransformUtility类
        // RectTransformUtility公共类 是RectTransform的辅助类
        // 主要用于进行一些 坐标转的等等操作
        // 其中对于我们来说最重要的函数是 将屏幕空间上的点 转换成UI本地坐标系下的点
        #endregion

        #region 知识点二 将屏幕坐标转换为UI本地坐标系下的点
        // 方法:
        // RectTransformUtility.ScreenPointToLocalPointInRectangle()
        // 参数一:相对父坐标
        // 参数二:屏幕点
        // 参数三:摄像机
        // 参数四:最终得到的点
        // 一般配合拖拽事件使用
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 nowPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(this.transform.parent as RectTransform, eventData.position,
            eventData.enterEventCamera, out nowPos);
        this.transform.localPosition = nowPos;
    }
}
