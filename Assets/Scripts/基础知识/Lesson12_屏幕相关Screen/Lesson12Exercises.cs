using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson12Exercises : MonoBehaviour
{
    public Transform target; //摄像机看向的对象
    public float rotateSpeed = 50; //摄像机旋转速度
    void Start()
    {
        #region 练习题一
        //1.在输入习题的基础上,鼠标滚轮控制炮管的抬起放下
        #endregion

        #region 练习题二
        //2.在上一题的基础上,加入长按鼠标右键移动鼠标
        //可以让摄像头围着坦克旋转,改变坦克的观察视角
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(target);
        //使用绕着某一个点的某一个轴 旋转的知识点 进行处理
        //鼠标右键按下知识点
        if (Input.GetMouseButton(1))
        {
            this.transform.RotateAround(target.position, //绕的点
             Vector3.up //绕的轴
            , rotateSpeed * Time.deltaTime * Input.GetAxis("Mouse X")); //旋转速度
        }
    }
}
