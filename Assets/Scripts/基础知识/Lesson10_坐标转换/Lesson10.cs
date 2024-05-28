using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson10 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 世界坐标系转本地坐标系
        print(Vector3.forward);
        //世界坐标系的点 转换为 相对本地坐标系的点
        //收到缩放影响
        print("转化后的点" + this.transform.InverseTransformPoint(Vector3.forward));
        //世界坐标系的方向 转换 为本地坐标系的方向
        //不受缩放影响
        print("转化后的方向" + this.transform.InverseTransformDirection(Vector3.forward));
        //受缩放影响
        print("转化后的方向(受缩放影响)" + this.transform.InverseTransformVector(Vector3.forward));
        #endregion

        #region 本地坐标系转世界坐标系
        //本地坐标系的点 转换为 相对世界坐标系的点
        //收到缩放影响
        print("本地 转 世界 点" + this.transform.TransformPoint(Vector3.forward));
        //本地坐标系的方向 转换 为世界坐标系的方向
        //不受缩放影响
        print("本地 转 世界 方向" + this.transform.TransformDirection(Vector3.forward));
        //受缩放影响
        print("本地 转 世界 方向(受缩放影响)" + this.transform.TransformVector(Vector3.forward));
        #endregion
    }
}
