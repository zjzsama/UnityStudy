using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;

public class Student2
{
    public int age;
    public string name;

    public Student2()
    {
    }

    public Student2(int age, string name)
    {
        this.age = age;
        this.name = name;
    }
}
public class ReInfoData2
{
    public List<ReInfo2> list;

    public ReInfoData2()
    {
    }
}
public class ReInfo2
{
    public int hp;
    public int speed;
    public int volume;
    public string resName;
    public int scale;

    public ReInfo2()
    {
    }
}

public class MrZhou2
{
    public string name;
    public int age;
    public bool sex;
    public float testF;
    public double testD;

    public int[] ids;
    public List<int> ids2;
    public Dictionary<int, string> dic;
    public Dictionary<string, string> dic2;

    public Student2 s1;
    public List<Student2> s2s;

    private int privateI = 1;
    protected int protectedI = 2;
}
public class Lesson04 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 LitJson是什么?
        // 它是一个第三方库 用于处理Json的序列化和反序列化
        // LitJson是C#编写的 体积小 速度快 易于使用
        // 它可以很容易的嵌入到我们的代码中
        // 只需要将LitJson代码拷贝到工程中即可
        #endregion

        #region 知识点二 获取LitJson
        // 1.前往LitJson官网
        // 2.通过官网前往Github获取最新版本代码
        // 3.将代码拷贝到Unity工程中
        #endregion

        #region 知识点三 使用LitJson进行序列化
        // 方法:
        // JsonMapper.ToJson(对象) 
        MrZhou2 z = new MrZhou2();
        z.name = "君哲";
        z.age = 18;
        z.sex = true;
        z.testF = 1.4f;
        z.testD = 2.2;

        z.ids = new int[] { 1, 2, 3, 4 };
        z.ids2 = new List<int> { 1, 2, 3, 4 };
        //z.dic = new Dictionary<int, string> { { 1, "123" }, { 2, "234" } };
        z.dic2 = new Dictionary<string, string> { { "1", "123" }, { "2", "234" } };

        z.s1 = new Student2(1, "小红");
        z.s2s = new List<Student2> { new Student2(1, "小红"), new Student2(2, "小明") };
        string jsonStr = JsonMapper.ToJson(z);
        print(Application.persistentDataPath);
        File.WriteAllText(Application.persistentDataPath + "/MrZhou3.json", jsonStr);

        // 注意:
        // 1.相对JsonUtility不需要加特性
        // 2.不能序列化私有变量
        // 3.支持字典类型,字典的键 建议都是字符串 因为Json的特性
        // 4.需要引用LitJson命名空间
        // 5.LitJson可以准确保存null类型
        #endregion

        #region 知识点四 使用LitJson进行反序列化
        // 方法:
        // JsonMapper.ToObject(字符串)
        jsonStr = File.ReadAllText(Application.persistentDataPath + "/MrZhou3.json");

        //JsonData是LitJson提供的类对象 可以用键值对的形式去访问其中的内容
        //这种了解即可
        JsonData data = JsonMapper.ToObject(jsonStr);
        print(data["name"]);
        print(data["age"]);
        //通过泛型转换更加方便 建议使用
        MrZhou2 z2 = JsonMapper.ToObject<MrZhou2>(jsonStr);

        // 注意:
        // 1.类结构需要无参构造函数 否则反序列化时报错
        // 2.字典虽然支持 但是键在使用为数值时会有问题 需要使用字符串类型

        #endregion

        #region 知识点五 注意事项
        // 1.LitJson可以直接读取数据集合
        jsonStr = File.ReadAllText(Application.streamingAssetsPath + "/Lesson02.json");
        ReInfo2[] info = JsonMapper.ToObject<ReInfo2[]>(jsonStr);
        print(jsonStr);
        // 2.文本编码格式必须是UTF-8 不然无法加载

        #endregion

        #region 总结
        // 1.LitJson提供的序列化和反序列化方法 JsonMapper和ToObject<>
        // 2.LitJson不需要加特性
        // 3.LitJson不支持私有变量
        // 4.LitJson支持字典序列化和反序列化
        // 5.LitJson可以直接将数据反序列化为数据集合
        // 6.LitJson反序列化时 自定义类型需要无参构造
        // 7.LitJson文档编码必须是UTF-8
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
