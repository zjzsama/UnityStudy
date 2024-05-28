using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson6 : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        #region 补充知识 调试画线
        // 画线段
        // 前两个参数分别是起点和终点，第三个参数是线段的颜色
        // Debug.DrawLine(this.transform.position, this.transform.position + this.transform.forward, Color.red);
        // 画射线
        // 前两个参数分别是 起点 方向
        // Debug.DrawRay(this.transform.position, this.transform.forward, Color.white);
        #endregion

        #region 知识点一 通过点乘判断对象方位
        Debug.DrawRay(this.transform.position, this.transform.forward, Color.red);
        Debug.DrawRay(this.transform.position, target.position - this.transform.position, Color.red);
        // 得到两个向量的点乘结果
        // 向量OA点乘向量AB的结果
        float dotResult = Vector3.Dot(this.transform.forward, target.position - this.transform.position);
        if (dotResult > 0)
        {
            print("前方");
        }
        else
        {
            print("后方");
        }
        #endregion

        #region 知识点二 通过点乘推导公式算出夹角
        // β=Acos(单位向量A*单位向量B)
        // 1.用单位向量算出点乘结果
        dotResult = Vector3.Dot(this.transform.position, (target.position - this.transform.position).normalized);
        // 2.用反三角函数得出角度
        print("角度:" + Mathf.Acos(dotResult * Mathf.Rad2Deg));

        // vector3提供了得到两个向量之间夹角的方法
        print("角度2:" + Vector3.Angle(this.transform.position, target.position - this.transform.position));
        #endregion
    }
}
