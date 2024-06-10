using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    private static UIManager instance = new UIManager();
    public static UIManager Instance => instance;
    // 存储面板的容器
    private Dictionary<string, BasePanel> panelDic = new Dictionary<string, BasePanel>();
    // 一开始得到 canvas对象
    private Transform canvasTrans;
    private UIManager()
    {
        canvasTrans = GameObject.Find("Canvas").transform;
        // 让 Canvas对象过场景不移除
        // 我们都是通过 动态创建和动态删除 来显示和隐藏面板的 所以不删除它 影响不大
        GameObject.DontDestroyOnLoad(canvasTrans.gameObject);
    }

    // 显示面板
    public T ShowPanel<T>() where T : BasePanel
    {
        // 我们只需要保证 泛型T的类型 和面板名字一致 定制一个这样的规则 方便我们使用
        string panelName = typeof(T).Name;
        //如果面板已经存在 不用创建 直接返回出去
        if (panelDic.ContainsKey(panelName))
        {
            return panelDic[panelName] as T;
        }
        // 显示面板就是 动态的创建面板预制体 设置父对象
        // 根据得到的 类名 就是我们的预制体面板名
        GameObject panelObj = GameObject.Instantiate(Resources.Load<GameObject>("UI/" + panelName));
        panelObj.transform.SetParent(canvasTrans, false);
        T panel = panelObj.GetComponent<T>();
        // 把面板脚本存储到 对应容器中 方便我们之后获取它
        panelDic.Add(panelName, panel);
        // 调用显示自己的逻辑
        panel.ShowMe();

        return panel;
    }
    // 隐藏面板
    // 参数一:如果希望淡出 就默认传true 如果希望直接隐藏(删除面板)就传false
    public void HidePanel<T>(bool isFade = true) where T : BasePanel
    {
        // 根据泛型类型 得到面板名字
        string panelName = typeof(T).Name;
        // 判断当前显示的面板 有没有该名字的面板
        if (panelDic.ContainsKey(panelName))
        {
            if (isFade)
            {
                panelDic[panelName].HideMe(() =>
                {
                    // 面板淡出成功后 希望删除面板
                    GameObject.Destroy(panelDic[panelName].gameObject);
                    // 删除面板后 从字典中移除
                    panelDic.Remove(panelName);
                });
            }
            else
            {
                // 删除面板
                GameObject.Destroy(panelDic[panelName].gameObject);
                // 删除面板后 从字典中移除
                panelDic.Remove(panelName);
            }
        }
    }
    // 获得面板
    public T GetPanel<T>() where T : BasePanel
    {
        string panelName = typeof(T).Name;
        if (panelDic.ContainsKey(panelName))
        {
            return panelDic[panelName] as T;
        }
        // 如果没有 返回空
        return null;
    }
}
