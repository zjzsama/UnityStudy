using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel<T> : MonoBehaviour where T : class
{
    private static T instance;
    public static T Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        // 在Awake中初始化 原因
        // 我们的面板脚本 在场景上肯定只挂载一次
        // 那么我们可以在这个脚本的生命周期函数中
        // 直接记录唯一的这个脚本
        instance = this as T;
    }
    public virtual void Show()
    {
        if (instance != null)
        {
            this.gameObject.SetActive(true);
        }
    }
    public virtual void Hide()
    {
        if (instance != null)
        {
            this.gameObject.SetActive(false);
        }
    }
}
