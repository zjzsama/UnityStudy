using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson17 : MonoBehaviour
{
    public AudioSource audioSource;
    private Texture texture;

    // Start is called before the first frame update

    void Start()
    {
        #region 知识点一 Resources资源动态加载的作用
        // 1.通过代码动态加载Resources文件夹下指定路径资源
        // 2.避免繁琐的拖拽操作
        #endregion

        #region 知识点二 常用资源类型
        // 1.预设体对象-GameObject
        // 2.音效文件-AudioClip
        // 3.文本文件-TextAsset
        // 4.图片文件-Texture
        // 5.其他文件-需要什么用什么

        // 注意:
        // 预设体对象加载需要实例化
        // 其他资源加载一般直接用
        #endregion

        #region 知识点三 资源同步加载 普通方法
        // 在一个工程中Resources文件夹可以有多个 在调用API时 它会自己根据这些同名的Resources文件夹去寻找相关资源


        // 1.预设体对象 想要创建在场景上 记住实例化
        // 第一步: 要去加载预设体的资源文件(本质上就是加载内置数据到内存中)
        GameObject obj = (GameObject)Resources.Load("Cube");
        // 第二步:如果想要在场景上创建预设体 一定是加载配置文件后 然后实例化
        Instantiate(obj);

        // 2.音效资源
        // 第一步:加载数据
        Object obj2 = Resources.Load("Music/BGM");
        // 第二步:使用数据 我们不需要 实例化音效切片 我们只需要把数据 赋值到正确的脚本上即可
        audioSource.clip = obj2 as AudioClip;
        audioSource.Play();

        // 3.文本资源
        // 文本资源支持格式
        // .txt .xml .bytes .json .html .csv等等
        TextAsset ta = Resources.Load("TXT/txt") as TextAsset;

        // 文本内容
        print(ta.text);
        // 字节数据组
        // print(ta.bytes);

        // 4.图片资源
        texture = Resources.Load("Tex/Test") as Texture;

        // 5.问题:资源同名怎么办
        // Resources.Load加载同名资源时 无法准确加载出想要的内容

        // 可以使用另外的API
        // 6-1.加载指定类型的资源
        texture = Resources.Load("Tex/Test", typeof(Texture)) as Texture;
        // 6-2.加载指定名字的资源
        Object[] objs = Resources.LoadAll("Tex/Test");
        foreach (var item in objs)
        {
            if (item is Texture)
            {

            }
            else if (item is TextAsset)
            {

            }
        }

        #endregion

        #region 知识点四 资源同步加载 泛型方法
        TextAsset ta2 = Resources.Load<TextAsset>("TXT/txt");
        print(ta2.text);
        #endregion

        #region 总结
        // 动态加载资源方法让拓展性更强
        // 相对拖拽来说 他更加一劳永逸 更加方便
        // 重要知识点:
        // 记住API
        // 记住一些特定的格式
        // 预设体加载出来一定要实例化
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, 200, 200), texture);
    }
}
