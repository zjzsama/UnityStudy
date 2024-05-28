using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson11Exercise : MonoBehaviour
{
    public float moveSpeed = 10;
    public float rotateSpeed = 10;
    public float headRotateSpeed = 50;
    public float pkRotateSpeed = 20;
    public Transform head;
    public Transform pkPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        #region 练习题一
        //1.使用之前的坦克预设体,用WASD控制坦克的前进后退,左右转向
        //transform当中的位移 旋转 相关知识点
        //键盘输入相关知识点

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        //公式:前进方向*速度*时间*当前是否移动(-1~1)
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * y);

        //ad键控制 左右转向
        //公式:转动轴*速度*时间*当前是否移动(-1~1)
        this.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * x);
        #endregion

        #region 练习题二
        //在上一题基础上 用鼠标控制炮台转向
        head.Rotate(Vector3.up * headRotateSpeed * Time.deltaTime * Input.GetAxis("Mouse X"));
        #endregion

        #region Lesson12 练习题一
        //1.在输入习题的基础上,鼠标滚轮控制炮管的抬起放下
        pkPos.Rotate(Vector3.right * pkRotateSpeed * Time.deltaTime * Input.mouseScrollDelta.y);
        #endregion
    }
}
