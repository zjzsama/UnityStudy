using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson10 : MonoBehaviour
{
    private Vector3 e;
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 四元数 Quaternion
        // 四元数Q = [(cosβ/2),sin(β/2)x,sin(β/2)y,sin(β/2)z]
        // 设β为60度
        // 计算原理
        // Quaternion q = new Quaternion(Mathf.Sin(30 * Mathf.Deg2Rad), 0, 0, Mathf.Cos(30 * Mathf.Deg2Rad));

        // 提供的轴角对初始化四元数的方法
        Quaternion q = Quaternion.AngleAxis(60, Vector3.right);

        // 创建一个立方体
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        obj.transform.rotation = q;

        #endregion

        #region 知识点二 四元数和欧拉角转换
        // 1.欧拉角转四元数
        Quaternion q2 = Quaternion.Euler(60, 0, 0);
        // 2.四元数转欧拉角
        print(q2.eulerAngles);
        #endregion

        #region 知识点三 四元数弥补的欧拉角的缺点
        // 欧拉角缺点
        // 1.万向节死锁
        // 2.不连续
        // 3.不直观
        // 四元数优点
        // 1.连续
        // 2.直观
        // 3.万向节死锁不会出现
        // 4.四元数可以进行线性运算
        // 5.四元数可以进行插值运算
        // 6.四元数可以进行旋转运算
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        // 四元数不存在万向节死锁
        this.transform.rotation *= Quaternion.AngleAxis(1, Vector3.up);

        // 欧拉角存在万向节死锁
        // e = this.transform.rotation.eulerAngles;
        // e += Vector3.up * 1;
        // this.transform.rotation = Quaternion.Euler(e);
    }
}
