using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// 长按按钮脚本 提供两个事件给外部 让外部处理
/// </summary>
public class LongPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public event UnityAction upEvent;
    public event UnityAction downEvent;



    public void OnPointerUp(PointerEventData eventData)
    {
        upEvent?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        downEvent?.Invoke();
    }
}
