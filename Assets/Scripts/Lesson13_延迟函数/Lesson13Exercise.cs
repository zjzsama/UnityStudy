using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson13Exercise : MonoBehaviour
{
    private int time;
    void Start()
    {
        #region 练习题一 利用延时函数实现一个记秒器
        InvokeRepeating("DelayFun", 0, 1);
        #endregion

        #region 练习题二 用两种方式延时销毁一个指定对象
        Destroy(gameObject, 5f);
        Invoke("DelayDes", 5f);
        #endregion
    }
    private void DelayFun()
    {
        print(time + "秒");
        time++;
    }
    private void DelayDes()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
