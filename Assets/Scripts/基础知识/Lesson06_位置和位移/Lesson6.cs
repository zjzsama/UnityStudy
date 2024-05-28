using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson6 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region Transform主要用来干嘛?
        //游戏对象 位移,旋转,缩放,父子关系,坐标转换等相关操作都由它处理
        //它是Unity提供的极其重要的类
        #endregion

        #region 知识点一 必备知识点Vector3基础
        Vector3 v1 = new Vector3(1, 1, 1);
        Vector3 v2 = new Vector3(2, 2, 2);
        //常用
        print(Vector3.zero); //(0,0,0)
        print(Vector3.one); //(1,1,1)
        print(Vector3.right); //(1,0,0)
        print(Vector3.left); //(-1,0,0)
        print(Vector3.up); //(0,1,0)
        print(Vector3.down); //(0,-1,0)
        print(Vector3.forward); //(0,0,1)
        print(Vector3.back); //(0,0,-1)

        //常用的一个方法
        //计算两个点之间的距离的方法
        print(Vector3.Distance(v2, v1));
        #endregion

        #region 知识点二 位置
        //相对世界坐标系
        //通过position得到的位置 是相对于 世界坐标系的原点的位置
        //可能和面板上显示的不一样(如果有父物体 且父物体位置不在原点 则位置不一样)
        print(this.transform.position);
        // this.gameObject.transform

        //相对父对象
        //这两个坐标对我们很重要 如果以面板为基准来进行位置设置 一定是通过localPosition来设置
        print(this.transform.localPosition);
        //两种坐标一样的情况
        //1.父对象位置在原点
        //2.物体没有父对象

        //对象当前的各朝向

        //对象当前的面朝向
        print(this.transform.forward);
        //对象当前的头顶朝向
        print(this.transform.up);
        //对象当前的右边
        print(this.transform.right);

        //注意:位置的赋值不能直接改变xyz,需要整体改变
        // this.transform.position = new Vector3(10, 10, 10);
        // this.transform.localPosition = Vector3.up * 10;

        //如果只想要改一个值
        //1.直接赋值
        this.transform.position = new Vector3(10, this.transform.position.y, this.transform.position.z);
        //2.先取出来 再赋值
        //虽然不能直接改transform的xyz 但是Vector3是可以直接改xyz的
        //所以可以先取出来Vector3再重新赋值
        Vector3 vPos = this.transform.localPosition;
        vPos.x = 10;
        this.transform.localPosition = vPos;
        #endregion


    }


    void Update()
    {
        #region 知识点三 位移
        //1.自己计算
        //想要改变的是position
        // this.transform.position += this.transform.right * 1.0f * Time.deltaTime;//当前的位置加上动的距离 得到之后的位置
        //方向非常重要因为它决定好了前进方向
        this.transform.position += Vector3.right * 1.0f * Time.deltaTime;
        //2.API计算
        //参数一: 位移多少 参数二:表示相对坐标系 默认该参数是相对于自己坐标系的
        //1.相对于世界坐标的x轴动
        // this.transform.Translate(Vector3.right * 1.0f * Time.deltaTime, Space.World);
        //2.相对于世界坐标系的 自己的x轴动
        // this.transform.Translate(this.transform.right * 1.0f * Time.deltaTime, Space.World);
        //3.相对于自己坐标系的 朝自己面朝向移动(一定不能这样动)
        // this.transform.Translate(this.transform.forward * 1.0f * Time.deltaTime, Space.Self);
        //4.相对于自己坐标系 朝向自己面移动
        this.transform.Translate(Vector3.forward * 1.0f * Time.deltaTime, Space.Self);
        #endregion
    }
}
