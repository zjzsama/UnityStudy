using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson10Exercises : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 练习题一
        // 写一个工具类 让我们可以更加方便的加载Multiple类型的图集资源

        // 提示:提供一个方法给外部 传入一个图集名字 和这个单张图的名字
        GameObject obj = new GameObject();
        SpriteRenderer sr = obj.AddComponent<SpriteRenderer>();
        sr.sprite = MultipleMgr.Instance.GetSprite("robotboyidlesprite", "robotboyidle02");

        #endregion

        #region 练习题二
        // 用提供的角色资源 制作一个通过wasd键 控制上下左右移动的功能
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
