using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson7 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 角度相关
        //相对世界坐标角度
        print(this.transform.eulerAngles);
        //相对父坐标角度
        print(this.transform.localEulerAngles);
        //注意:设置角度和设置位置一样 不能单独设置xyz 要一起设置
        this.transform.localEulerAngles = new Vector3(10, 10, 10);
        #endregion


    }

    // Update is called once per frame
    void Update()
    {
        #region 知识点二 旋转相关
        //1.自己计算

        //2.API计算

        //自转
        //第一个参数:旋转的角度 每一帧 第二个参数:默认不填 就是相对于自己坐标系 进行的旋转
        // this.transform.Rotate(new Vector3(0, 0, 10) * Time.deltaTime);
        // this.transform.Rotate(new Vector3(0, 0, 10) * Time.deltaTime, Space.World);

        //相对于某一个轴转多少度
        //参数一:是相对哪个轴进行旋转 参数二:转动的角度是多少 参数三:默认不填 就是相对于自己的坐标系 进行旋转
        // this.transform.Rotate(Vector3.up, 10 * Time.deltaTime, Space.Self);

        //相对于某一点转
        //第一个参数:绕的点 第二个参数:绕的轴 第三个参数:速度
        this.transform.RotateAround(Vector3.zero, Vector3.up, 10 * Time.deltaTime);
        #endregion
    }
}
