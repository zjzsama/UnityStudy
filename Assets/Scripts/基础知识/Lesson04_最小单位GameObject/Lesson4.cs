using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson4 : MonoBehaviour
{
    public GameObject myObj;
    void Start()
    {
        #region 知识点一 GameObejct的成员变量
        //名字
        print(this.gameObject.name);
        this.gameObject.name = "Lesson4改名";
        print(this.gameObject.name);
        //是否激活
        print(this.gameObject.activeSelf);
        //是否是静态
        print(this.gameObject.isStatic);
        //层级
        print(this.gameObject.layer);
        //标签
        print(this.gameObject.tag);
        //transform
        //this.transform 通过Mono去得到的依附对象的GameObject的位置信息
        print(this.gameObject.transform.position);
        // print(this.transform.position); //和上面一样的

        #endregion

        #region 知识点二 GameObject的静态方法
        //创建自带几何体
        //只要得到了一个GameObject对象 我就可以得到他身上挂载的任何脚本信息
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        obj.name = "Lesson4创建的几何体";

        #region 查找对象的方法
        //查找对象的相关知识
        //共同缺点
        //1.无法找到失活对象,只能找到激活对象
        //2.如果场景中存在多个满足条件的对象,无法准确确定找到的是谁


        //1.通过查找单个对象
        //通过对象名查找
        GameObject obj2 = GameObject.Find("Lesson4创建的几何体"); //根据名字查找,效率低下 因为会在场景的所有对象中查找
        if (obj2 != null)
        {
            print(obj2.name);
        }
        else
        {
            print("没有找到该对象");
        }
        //通过tag查找
        // GameObject obj3 = GameObject.FindWithTag("Player");
        GameObject obj3 = GameObject.FindGameObjectWithTag("Player"); //该方法和上面的方法一样

        if (obj3 != null)
        {
            print("根据tag找的对象" + obj3.name);
        }
        else
        {
            print("没有找到该对象");
        }

        //得到单个对象现在有两种方式
        //1.public从外部面板拖 进行关联
        //2.通过API去找

        //2.查找多个对象
        //找多个对象的API 只能是通过tag去找多个 通过名字是没有找多个的方法的
        //只能找得到激活对象 无法找到失活对象
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Player");
        print("找到tag为Player的个数为:" + objects.Length);

        //还有几个查找对象相关是用的比较少的方法 是GameObject父类Object提供的方法
        //引出额外知识点
        //Unity里面的Object 不是万物之父object
        //Object的命名空间是在UnityEngine 是集成object的一个自定义类
        //c#的object是在System命名空间内的

        //它可以找到场景中挂载的某一个脚本对象
        //效率更低, 上面的GameObject.Find和通过FindWithTag找 只是遍历对象
        //这个方法不仅要遍历对象 还要遍历对象上挂载的脚本
        Lesson4 o = GameObject.FindObjectOfType<Lesson4>();
        print(o.gameObject.name);
        #endregion

        #region 实例化对象的方法(克隆对象)
        //它的作用是 根据一个GameObject对象 创建出一个一模一样的对象
        GameObject obj5 = GameObject.Instantiate(myObj);
        //以后学了更多知识点 就可以在这操作obj5
        //如果继承了 Monobehaviour 其实可以不用写GameObject一样可以使用
        //因为 这个方法在Unity里面的Object基类提供给我们 可以直接使用
        Instantiate(myObj);
        #endregion

        //删除对象的方法
        GameObject.Destroy(obj5);
        //第二个参数是延迟几秒钟
        GameObject.Destroy(obj5, 5);
        //Destroy不仅可以删除对象 还可以删除脚本
        GameObject.Destroy(this);

        //删除对象有两种作用
        //1.删除指定的一个游戏对象
        //2.删除指定的一个脚本对象
        //注意:Destroy方法不会马上移除对象 只是给这个对象加了一个移除标识
        //一般情况下 它会在下一帧把这个对象移除并从内存中移除

        //如果没有特殊需求 就是一定要马上移除一个对象的话
        //建议使用上面的 Destroy方法 因为是异步的 降低卡顿的几率
        //下面这个方法就是马上从内存移出
        GameObject.DestroyImmediate(myObj);
        //如果是继承MonoBehavior的类 不用写GameObject

        //过场景不移出

        //默认情况 在切换场景时 场景中的对象都会被删除
        //如果希望某个对象过场景不被移出
        //下面这句代码 就是不想谁过场景被移除就传
        GameObject.DontDestroyOnLoad(this.gameObject); //这句代码就是自己依附的GameObject对象 过场景不被移除
        #endregion

        #region 知识点三 GameObject的成员方法
        //创建空物体
        GameObject obj6 = new GameObject();
        GameObject obj7 = new GameObject("创建的新物体");
        // GameObject obj8 = new GameObject("顺便加脚本的空物体", typeof(Lesson4), typeof(Lesson3_Test));

        //为对象添加脚本
        //继承Monobehaviour的脚本 不能够去new
        //如果想要动态的添加继承Monobehavior的脚本 在某一个对象上
        //直接使用GameObject提供的方法即可
        obj6.AddComponent<Lesson4>();  //用泛型更方便
        // obj6.AddComponent(typeof(Lesson4)) as Lesson4;

        //通过返回值 可以得到加入的脚本信息 来进行一些处理
        //得到脚本的成员方法和继承Monobehavior类得到脚本的方法一模一样

        //标签比较
        //下面两种的比较方法是一样的
        if (this.gameObject.CompareTag("Player"))
        {
            print("对象的标签是 Player");
        }
        // if (this.gameObject.tag == "Player")
        // {
        //     print("对象的标签是 Player");
        // }

        //设置失活激活
        //失活
        obj6.SetActive(false);
        #endregion
    }
}
