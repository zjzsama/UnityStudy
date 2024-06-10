using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public abstract class BasePanel : MonoBehaviour
{
    // 整体控制淡入淡出画布组 组件
    private CanvasGroup canvasGroup;
    // 淡入淡出速度
    private float alphaSpeed = 10f;
    // 是否显示自己
    private bool isShow;
    // 当自己淡出成功时 调用的委托函数
    private UnityAction hideCallBack;
    protected virtual void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = this.gameObject.AddComponent<CanvasGroup>();
        }
    }

    protected virtual void Start()
    {
        Init();
    }
    /// <summary>
    /// 主要用于初始化 按钮事件监听等等内容
    /// </summary>
    public abstract void Init();

    /// <summary>
    /// 显示自己时 做的事情
    /// </summary>
    public virtual void ShowMe()
    {
        isShow = true;
        canvasGroup.alpha = 1;
    }
    /// <summary>
    /// 隐藏自己时 做的事情
    /// </summary>
    public virtual void HideMe(UnityAction callBack)
    {
        isShow = false;
        canvasGroup.alpha = 0;
        // 记录 传入的 当淡出成功后会执行的函数
        hideCallBack = callBack;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShow && canvasGroup.alpha != 1)
        {
            canvasGroup.alpha += alphaSpeed * Time.deltaTime;
            // 淡入
            if (canvasGroup.alpha >= 1)
            {
                canvasGroup.alpha = 1;
            }
        }
        else if (!isShow)
        {
            canvasGroup.alpha -= alphaSpeed * Time.deltaTime;
            if (canvasGroup.alpha <= 0)
            {
                canvasGroup.alpha = 0;
                // 让管理器 删除自己
                hideCallBack?.Invoke();
            }
        }
    }
}
