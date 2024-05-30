using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson05 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 JsonUtility和LitJson相同点
        // 1.他们都是用于Json的序列化和反序列化
        // 2.Json文档编码格式都是UTF-8
        // 3.都是通过静态类进行方法调用
        #endregion

        #region 知识点二 JsonUtility和LitJson不同点
        // 1.JsonUtility是Unity自带,LitJson是第三方需要引用命名空间
        // 2.JsonUtility使用时自定义类需要加特性,LitJson不要
        // 3.JsonUtility支持私有变量,LitJson不支持
        // 4.JsonUtility不支持字典,LitJson支持(但是键必须是string)
        // 5.JsonUtility不能直接将数据反序列化为数据集合,LitJson可以
        // 6.JsonUtility对自定义类不要求有无参构造,LitJson需要
        // 7.JsonUtility存储空对象是默认值而不是null,LitJson会存null
        #endregion

        #region 知识点三 如何选择两者
        // 根据实际情况
        // 建议使用LitJson
        // 原因:LitJson不用加特性,支持字典,直接反序列化为数据集合,存储空值准确
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
