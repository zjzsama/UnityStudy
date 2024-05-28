using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson11 : MonoBehaviour
{
    public Transform testObj;
    public Transform target;
    public Transform A;
    public Transform B;
    private Quaternion start;
    private Quaternion nowTarget;
    private float time;
    public Transform lookA;
    public Transform lookB;
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 单位四元数
        print(Quaternion.identity);
        // testObj.rotation = Quaternion.identity;

        Instantiate(testObj, this.transform.position, Quaternion.identity);
        #endregion

        #region 知识点二 插值运算
        // 推荐Slerp
        start = B.rotation;
        nowTarget = target.rotation;
        #endregion


    }

    // Update is called once per frame
    void Update()
    {
        // 无限接近 先快后慢
        A.rotation = Quaternion.Slerp(A.rotation, target.rotation, Time.deltaTime);
        // 匀速变化 time>=1到达目标
        if (nowTarget != target.rotation)
        {
            nowTarget = target.rotation;
            start = B.rotation;
            time = 0;
        }
        time += Time.deltaTime;
        B.rotation = Quaternion.Lerp(start, target.rotation, time);

        #region 知识点三 LookRotation
        Quaternion q = Quaternion.LookRotation(lookB.position - lookA.position);
        lookA.rotation = q; // A看向B
        // lookA.MyLookAt(lookB);
        #endregion
    }
    // 总结
    // 1.单位四元数 -用于对象角度初始化
    // 2.插值运算 -用于平滑旋转
    // 3.向量指向转四元数 -用于让对象朝向某方向
}
