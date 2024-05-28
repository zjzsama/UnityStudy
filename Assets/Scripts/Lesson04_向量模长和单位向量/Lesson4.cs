using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 向量
        // 三维向量 vector3
        // 有两种几何意义
        // 1.位置-代表一个点
        print(this.transform.position);
        // 2.方向-代表一个方向
        print(this.transform.forward);
        print(this.transform.up);

        Vector3 v = new Vector3(1, 2, 3);
        Vector2 v2 = new Vector3(1, 2);
        #endregion

        #region 知识点二 两点决定一向量
        // A和B此时几何意义是两个点
        Vector3 A = new Vector3(1, 2, 3);
        Vector3 B = new Vector3(5, 1, 5);
        // 求向量
        // 此时AB和BA几何意义是两个向量
        Vector3 AB = B - A;
        Vector3 BA = A - B;
        #endregion

        #region 知识点三 零向量和负向量
        print(Vector3.zero);
        print(Vector3.forward);
        print(-Vector3.forward);
        #endregion

        #region 知识点四 向量的模长
        // 向量的模长
        print(AB.magnitude);
        print(Vector3.Distance(A, B));
        Vector3 C = new Vector3(5, 6, 7);
        print(C.magnitude); // 相对于原点的长度

        // 向量的模长的平方
        print(AB.sqrMagnitude);
        #endregion

        #region 知识点五 单位向量
        print(AB.normalized);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
