using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneMgr
{
    private static SceneMgr instance = new SceneMgr();
    public static SceneMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SceneMgr();
            }
            return instance;
        }
    }
    private SceneMgr()
    {

    }
    public void LoadScene(string name, UnityAction action)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(name);
        ao.completed += (obj) =>
        {
            // 通过Lamba表达式包裹一层
            // 在内部 直接调用外部委托
            action();
        };
    }
}
