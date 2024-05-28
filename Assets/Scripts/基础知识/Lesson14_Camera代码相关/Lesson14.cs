using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson14 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 重要静态成员
        //1.获取摄像机
        //用之前的知识获取摄像机
        //主摄像机的获取
        print(Camera.main.name); //如果想通过这种方法快速获得主摄像机 必须有MainCamera的Tag
        print(Camera.allCamerasCount); //获取摄像机的数量
        //得到所有摄像机
        Camera[] cameras = Camera.allCameras;
        print(cameras.Length);

        //2.渲染相关委托
        //摄像机剔除前处理的委托函数
        Camera.onPreCull += (c) =>
        {

        };
        //摄像机 渲染前处理的委托函数
        Camera.onPreCull += (c) =>
        {

        };
        //摄像机 渲染后处理的委托函数
        Camera.onPostRender += (c) =>
        {

        };
        #endregion

        #region 知识点二 重要成员
        //1.界面上的参数 都可以在Camera中获取到
        Camera.main.depth = 10; //得到主摄像机上的深度 并设置
        //2.世界坐标转屏幕坐标
        Vector3 v = Camera.main.WorldToScreenPoint(this.transform.position);
        //xy代表屏幕坐标 z代表这个3D物体离摄像机有多远
        //我们会用这个来做的功能最多的 就是 头顶血条相关的功能
        print(v);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        //3.屏幕坐标转世界坐标
        //之所以改变z 是因为不改z z默认为0
        //转化过去的世界坐标系的点 永远都是一个点 可以理解为 视口的焦点
        //如果改变了z 那么转换过去的世界坐标系的点 就是相对于摄像机多少距离的横截面上的世界坐标点
        Vector3 v = Input.mousePosition;
        v.z = 10;
        print(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}
