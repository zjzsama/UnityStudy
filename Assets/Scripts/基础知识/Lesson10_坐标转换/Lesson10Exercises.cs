using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson10Exercises : MonoBehaviour
{
    void Start()
    {

        #region 练习题二
        //一个物体A 不管它在什么位置 写一个方法 只要执行这个方法就可以在它的前方创建出三个球体
        //位置分别是(0,0,1),(0,0,2),(0,0,3)
        #endregion
    }
    [ContextMenu("左前方创建空物体")]
    void TestFunc1()
    {
        #region 练习题一
        //一个物体A 不管它在什么位置,写一个方法,只要执行这个方法就可以在它的左前方(-1,0,1)处创建一个空物体 
        Vector3 vPos = this.transform.TransformPoint(new Vector3(-1, 0, 1));
        GameObject obj = new GameObject("空物体");
        obj.transform.position = vPos;
        #endregion
    }

    [ContextMenu("创建三个球体")]
    void TestFunc2()
    {
        for (int i = 1; i <= 3; i++)
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            obj.transform.position = this.transform.TransformPoint(new Vector3(0, 0, i));
        }
    }
}
