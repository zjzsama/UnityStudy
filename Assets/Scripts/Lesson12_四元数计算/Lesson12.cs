using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson12 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 四元数相乘
        // 相乘相当于两个旋转量的叠加
        Quaternion q = Quaternion.AngleAxis(20, Vector3.up);
        this.transform.rotation *= q; // y 20度
        this.transform.rotation *= q; // y 40度
        #endregion

        #region 知识点二 四元数相乘向量
        // 返回一个新向量
        // 可以将指定的向量旋转对应的四元数的旋转量
        // 相当于旋转向量

        Vector3 v = Vector3.forward;
        print(v);
        // 相乘顺序不能错 只能是四元数乘以向量
        v = Quaternion.AngleAxis(45, Vector3.up) * v;
        print(v);
        v = Quaternion.AngleAxis(45, Vector3.up) * v;
        print(v);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
