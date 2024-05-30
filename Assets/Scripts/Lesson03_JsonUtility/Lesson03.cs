using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using UnityEngine;
using File = System.IO.File;
[System.Serializable]
public class Student
{
    public int age;
    public string name;

    public Student()
    {
    }

    public Student(int age, string name)
    {
        this.age = age;
        this.name = name;
    }
}

public class ReInfoData
{
    public List<ReInfo> list;
}
[System.Serializable]
public class ReInfo
{
    public int hp;
    public int speed;
    public int volume;
    public string resName;
    public int scale;
}
public class MrZhou
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

    public Student s1;
    public List<Student> s2s;

    [SerializeField] private int privateI = 1;
    [SerializeField] protected int protectedI = 2;
}
public class Lesson03 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 JsonUtility是什么
        // JsonUtility 是Unity自带的用于解析Json的公共类
        // 它可以
        // 1.将内存中对象序列化为Json格式的字符串
        // 2.将Json字符串反序列化为类对象
        #endregion

        #region 知识点二 必备知识点--在文件中存读字符串
        // 1.存储字符串到指定路径文件中
        // 第一个参数:存储路径 第二个参数:存储字符串的内容 
        File.WriteAllText(Application.persistentDataPath + "/Test.json", "君哲存储的Json文件");
        print(Application.persistentDataPath);
        // 2.在指定路径文件中
        string str = File.ReadAllText(Application.persistentDataPath + "/Test.json");
        print(str);
        #endregion

        #region 知识点三 使用JsonUtility进行序列化
        // 序列化:把内存中的数据 存储到硬盘上
        // 方法:
        // JsonUtility.ToJson(对象)
        MrZhou z = new MrZhou();
        z.name = "君哲";
        z.age = 18;
        z.sex = true;
        z.testF = 1.4f;
        z.testD = 2.2;
        z.ids = new int[] { 1, 2, 3, 4 };
        z.ids2 = new List<int> { 1, 2, 3, 4 };
        z.dic = new Dictionary<int, string> { { 1, "123" }, { 2, "234" } };
        z.dic2 = new Dictionary<string, string> { { "1", "123" }, { "2", "234" } };

        z.s1 = new Student(1, "小红");
        z.s2s = new List<Student> { new Student(1, "小红"), new Student(2, "小明") };

        // JsonUtility提供了现成的方法 可以把类对象序列化为 json字符串
        string jsonStr = JsonUtility.ToJson(z);
        File.WriteAllText(Application.persistentDataPath + "/MrZhou.json", jsonStr);

        // 注意:
        // 1.float序列化时看起来会有一些误差
        // 2.自定义类需要加上序列化特性[System.Serializable]
        // 3.想要序列化私有变量 需要加上特性 [SerializeField]
        // 4.JsonUtility不支持字典
        // 5.JsonUtility存储null对象不会是null 而是默认值的数据
        #endregion

        #region 知识点四 使用JsonUtility进行反序列化
        // 反序列化:把硬盘上的数据 读取到内存中
        // 方法:
        // JsonUtility.FromJson(字符串)

        // 读取文件中的Json字符串
        jsonStr = File.ReadAllText(Application.persistentDataPath + "/MrZhou.json");
        // 使用JSon字符串内容 转换成类对象
        MrZhou z2 = JsonUtility.FromJson(jsonStr, typeof(MrZhou)) as MrZhou;
        MrZhou z3 = JsonUtility.FromJson<MrZhou>(jsonStr);

        // 注意:如果Json中数据少了 读取到内存中类对象时不会报错  

        #endregion

        #region 知识点五 注意事项
        // 1.JsonUtility无法直接读取数据集合
        jsonStr = File.ReadAllText(Application.streamingAssetsPath + "/Lesson02.json");
        print(jsonStr);
        ReInfoData reInfoData = JsonUtility.FromJson<ReInfoData>(jsonStr);
        // 2.文本编码格式需要UTF-8 不然无法加载

        #endregion

        #region 总结
        // 1.必备知识点 -- File存读字符串的方法 ReadAllText和WriteAllText
        // 2.JsonUtility提供的序列化和反序列化方法 ToJson和FormJson
        // 3.自定义类需要加上序列化特性 [System.Serializable] (被类里面包裹的的类需要加上)
        // 4.私有保护成员 需要加上 [SerializeField]
        // 5.JsonUtility不支持字典
        // 6.JsonUtility不能直接将数据反序列化为数据集合
        // 7.Json文档编码格式必须是UTF-8
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
