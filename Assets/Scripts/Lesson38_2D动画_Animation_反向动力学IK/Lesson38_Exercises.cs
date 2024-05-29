using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson38_Exercises : MonoBehaviour
{
    public Transform ikPoint;

    private float z;
    private Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        #region 练习题

        // 制作一个鼠标指向哪 2D人物手臂就指向哪的功能

        // 这是为了得到当前2D游戏所在平面的 横截面Z轴坐标 用于之后的 屏幕坐标转世界坐标
        z = Camera.main.WorldToScreenPoint(ikPoint.position).z;

        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // 得到当前鼠标所在位置
            mousePos = Input.mousePosition;
            // 改变z轴 为了之后转换世界坐标后 横截面位置正确
            mousePos.z = z;
            ikPoint.position = Camera.main.ScreenToWorldPoint(mousePos);
        }
    }
}
