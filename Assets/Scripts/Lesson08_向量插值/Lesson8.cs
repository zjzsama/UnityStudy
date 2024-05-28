using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson8 : MonoBehaviour
{
    public Transform target;
    public Transform A;
    public Transform B;
    public Transform C;
    private Vector3 BstartPos;
    private float time = 0;
    private Vector3 nowTarget;
    // Start is called before the first frame update
    void Start()
    {
        BstartPos = B.position;
    }

    // Update is called once per frame
    void Update()
    {
        #region 知识点一 线性插值
        // result=start+(end-start)*t

        // 1.先快后慢 每帧改变start位置 位置无限接近 但不会得到end位置
        A.position = Vector3.Lerp(A.position, target.position, Time.deltaTime);

        // 2.匀速 每帧改变时间 当t>=1时 得到结果
        // 匀速移动当time>=1时 会瞬移到目标位置
        if (nowTarget != target.position)
        {
            nowTarget = target.position;
            time = 0;
            BstartPos = B.position;
        }
        time += Time.deltaTime;
        B.position = Vector3.Lerp(BstartPos, target.position, time);
        #endregion

        #region 知识点二  球形插值
        C.position = Vector3.Slerp(Vector3.right * 10, Vector3.forward * 10, time * 0.1f);
        #endregion
    }
    // 总结
    // 线性插值:用于跟随移动,摄像机跟随
    // 球形插值:用于曲线移动,模拟太阳运动弧线
}
