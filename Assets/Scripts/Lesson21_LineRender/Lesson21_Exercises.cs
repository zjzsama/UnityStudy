using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson21_Exercises : MonoBehaviour
{
    private LineRenderer line2;
    private Vector3 nowPos;
    void Start()
    {
        #region 练习题一 
        // 写一个方法 传入一个中心店,传入一个半径,用LineRender画一个圆出来
        DrawLineRender(Vector3.zero, 5, 360);
        #endregion

        #region 练习题二
        // 在Game窗口长按鼠标用LineRender画出鼠标移动的轨迹
        line2 = this.gameObject.AddComponent<LineRenderer>();
        line2.loop = false;
        line2.startWidth = 0.5f;
        line2.endWidth = 0.5f;
        line2.positionCount = 0;
        #endregion


    }
    // 练习题一
    public void DrawLineRender(Vector3 centerPos, float r, int pointNum)
    {
        GameObject obj = new GameObject();
        obj.name = "R";
        LineRenderer line = obj.AddComponent<LineRenderer>();
        line.loop = true;
        // 设置有多少点
        line.positionCount = pointNum;

        // 得到每个点 之间间隔的度数
        float angle = 360 / pointNum;

        // 准备得到每一个点
        for (int i = 0; i < pointNum; i++)
        {
            // 知识点 
            // 1.点加向量 相当于平移点
            // 2.四元数*向量 相当于旋转向量
            line.SetPosition(i, centerPos + Quaternion.AngleAxis(angle * i, Vector3.up) * Vector3.forward * r);
        }
    }
    private void Update()
    {
        // 按下鼠标左键创建一条新的线
        if (Input.GetMouseButtonDown(0))
        {
            GameObject obj = new GameObject();

            line2 = obj.AddComponent<LineRenderer>();
            line2.loop = false;
            line2.startWidth = 0.5f;
            line2.endWidth = 0.5f;
            line2.positionCount = 0;
        }

        // 一直按鼠标左键 创建线
        if (Input.GetMouseButton(0))
        {
            line2.positionCount++;
            // 如何得到鼠标转世界坐标的对应点
            // 知识点
            // 1.如何得到鼠标位置
            // Input.mousePosition
            // 2.如何得到世界坐标
            // Camera.main.ScreenToWorldPoint(Input.mousePosition)
            nowPos = Input.mousePosition;
            nowPos.z = 10;

            line2.SetPosition(line2.positionCount - 1, Camera.main.ScreenToWorldPoint(nowPos));
        }
    }
}
