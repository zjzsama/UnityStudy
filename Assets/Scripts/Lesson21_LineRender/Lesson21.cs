using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson21 : MonoBehaviour
{
    private Material m;
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 LineRender是什么
        // LineRender是Unity提供的用于划线的组件 使用它我们可以在场景中绘制线段
        // 一般可以用于
        // 1.绘制攻击范围
        // 2.武器红外线
        // 3.辅助功能
        // 4.其他画线功能
        #endregion

        #region 知识点二 LineRender参数相关

        #endregion

        #region 知识点三 LineRender代码相关
        // 动态创建一个线段
        GameObject line = new GameObject();
        line.name = "Line";
        LineRenderer lineRenderer = line.
        AddComponent<LineRenderer>();

        // 首尾相连
        lineRenderer.loop = true;

        // 开始结束宽
        lineRenderer.startWidth = 1f;
        lineRenderer.endWidth = 1f;

        // 开始结束颜色
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.red;

        // 设置材质
        m = Resources.Load<Material>("m");
        lineRenderer.material = m;

        // 设置点
        //一定要注意 设置点要先设置 点的数量
        lineRenderer.positionCount = 4;
        // 接着设置点的位置
        lineRenderer.SetPositions(new Vector3[] { new Vector3(0, 0, 0), new Vector3(0, 0, 5), new Vector3(5, 0, 5) });
        // 第一个参数是点的索引 第二个参数是点的坐标
        lineRenderer.SetPosition(3, new Vector3(5, 0, 0));

        // 是否决定使用空间坐标系
        // 决定了 是否随对象移动而移动
        lineRenderer.useWorldSpace = true;

        // 让线段受光影响 会接受光数据 进行着色器计算
        lineRenderer.generateLightingData = true;
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
