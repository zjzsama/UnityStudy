using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson11 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //注意:输入相关内容肯定都在Update当中
    }

    // Update is called once per frame
    void Update()
    {
        #region 知识点一 鼠标在屏幕的位置
        //屏幕原点是左下角 往右是X轴正方向 往上是Y轴正方向
        //z一直是0 因为是2D的
        // print(Input.mousePosition);
        #endregion

        #region 知识点二 检测鼠标输入
        //鼠标按下一瞬间 进入
        //0左键 1右键 2中键
        //只有按下的一瞬间 进入
        if (Input.GetMouseButtonDown(0))
        {
            print("鼠标左键按下了");
        }

        //鼠标抬起一瞬间 进入
        if (Input.GetMouseButtonUp(0))
        {
            print("鼠标左键抬起了");
        }

        //鼠标长按 按下 抬起都会进入
        //当按住不放时 一直进入
        if (Input.GetMouseButton(0))
        {
            print("鼠标左键长按中");
        }

        //中键滚动
        //返回值的y 0没有滚 1是上 -1是下
        //它的返回值是 Vector的值 我们鼠标中键滚动 会改变其中的Y值
        print(Input.mouseScrollDelta);
        #endregion

        #region 知识点三 检测键盘输入
        //比如说按一个键放一个技能

        //键盘按下
        if (Input.GetKeyDown(KeyCode.W))
        {
            print("W按下");
        }

        //传入字符串的重载
        //这里传入的字符串不能是大写的 只能是小写的
        if (Input.GetKeyDown("q"))
        {
            print("Q按下了");
        }
        // if (Input.GetKeyDown(KeyCode.Q))
        // {
        //     print("Q按下了");
        // }

        //键盘抬起
        if (Input.GetKeyUp(KeyCode.W))
        {
            print("W抬起");
        }
        //键盘长按
        if (Input.GetKey(KeyCode.W))
        {
            print("W长按");
        }
        #endregion

        #region 知识点四 检测默认轴输入
        //我们学习鼠标 键盘输入 主要用来控制玩家 比如旋转 位移等等
        //所以Unity提供了一个更方便的方法 来帮助我们控制

        //键盘按下AD时 返回-1到1的变换
        //相当于这个值 就是我们的左右方向 我们可以通过它来控制 对象左右移动 或者左右旋转
        print(Input.GetAxis("Horizontal"));
        //键盘按下SW时 返回-1到1的变换
        print(Input.GetAxis("Vertical"));
        //鼠标横向移动时 -1到1 左 右
        print(Input.GetAxis("Mouse X"));
        //鼠标纵向移动时 -1到1 下 上
        print(Input.GetAxis("Mouse Y"));

        //GetAxisRaw方法和GetAxis使用方式相同
        //只不过 它的返回值 只会是 -1 0 1 不会有中间值
        #endregion

        #region 其他
        //是否有任意键或鼠标长按
        if (Input.anyKey)
        {
            print("有一个键长按");
        }
        //是否有任意键或鼠标按下
        if (Input.anyKeyDown)
        {
            print("有一个键按下");
        }

        //这一帧的键盘输入
        print(Input.inputString);

        //手柄输入相关
        //得到连接的手柄的所有按钮名字
        string[] strs = Input.GetJoystickNames();

        //某一个键按下
        if (Input.GetButtonDown("Jump"))
        {

        }
        //某一个键长按
        if (Input.GetButton("Jump"))
        {

        }
        //某一个键抬起
        if (Input.GetButtonUp("Jump"))
        {

        }

        //移动设备触摸相关
        if (Input.touchCount > 0)
        {
            Touch t1 = Input.touches[0];

            //位置
            print(t1.position);
            //相对上次位置的变化
            print(t1.deltaPosition);
        }

        //是否启用多点触控
        Input.multiTouchEnabled = true;

        //陀螺仪(重力感应)
        //是否开启陀螺仪 必须开启 才能正常使用
        Input.gyro.enabled = true;

        //重力加速度向量
        print(Input.gyro.gravity);

        //旋转速度
        print(Input.gyro.rotationRate);

        //陀螺仪 当前的旋转四元数
        //比如 用这个角度信息 来控制 场景上的一个3D物体的重力影响
        //手机怎么动 它怎么动
        print(Input.gyro.attitude);
        #endregion
    }
}
