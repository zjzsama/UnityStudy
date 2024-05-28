using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson12 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 静态属性

        #region 常用
        //当前屏幕分辨率
        Resolution r = Screen.currentResolution;
        print("当前屏幕分辨率的宽:" + r.width + " 当前屏幕分辨率的高:" + r.height);

        //屏幕当前的宽高
        //这得到的是当前窗口的宽高 不是设备分辨率的宽高
        //一般写代码 要用窗口宽高 做计算时 就用它们
        print(Screen.width);
        print(Screen.height);

        //屏幕休眠模式
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        #endregion

        #region 不常用
        //运行时是否全屏
        Screen.fullScreen = true;
        //窗口模式
        //独占全屏FullScreenMode.ExclusiveFullScreen
        //全屏窗口FullScreenMode.FullScreenWindow
        //最大化窗口FullScreenMode.MaximizedWindow
        //窗口模式FullScreenMode.Windowed
        Screen.fullScreenMode = FullScreenMode.Windowed;


        //移动设备屏幕转向相关
        //允许自动旋转为左横向 Home键在左
        Screen.autorotateToLandscapeLeft = true;
        //允许自动旋转为右横向 Home键在右
        Screen.autorotateToLandscapeRight = true;
        //允许自动旋转为纵向 Home键在下
        Screen.autorotateToPortrait = true;
        //允许自动旋转为纵向倒着 Home键在上
        Screen.autorotateToPortraitUpsideDown = true;
        //指定屏幕显示方向
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        #endregion

        #endregion

        #region 知识点二 静态方法
        //设置分辨率 一般移动设备不使用
        //第一个参数:宽 第二个参数:高 第三个参数:是否全屏
        Screen.SetResolution(1920, 1080, false);

        #endregion
    }
}
