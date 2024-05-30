using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;
/// <summary>
/// 序列化和反序列化时 使用哪种方案
/// </summary>
public enum JsonType
{
    JsonUtility,
    LitJson
}

/// <summary>
/// Json数据管理类 主要用于进行 Json的序列化存储到硬盘 和Json反序列化读取到内存
/// </summary>
public class JsonMgr
{
    private static JsonMgr instance;
    public static JsonMgr Instance => instance;

    private JsonMgr()
    {

    }
    //存储Json数据 序列化
    public void SaveData(object data, string fileName, JsonType type = JsonType.LitJson)
    {
        // 确定存储路径
        string path = Application.persistentDataPath + "/" + fileName + ".json";

        // 序列化 得到Json字符串
        string jsonStr = "";
        switch (type)
        {
            case JsonType.JsonUtility:
                jsonStr = JsonUtility.ToJson(data);
                break;
            case JsonType.LitJson:
                jsonStr = JsonMapper.ToJson(data);
                break;
            default:
                break;
        }
        // 把序列化的Json字符串 存储到指定路径的文件中
        File.WriteAllText(path, jsonStr);
    }

    public T LoadData<T>(string fileName, JsonType type = JsonType.LitJson) where T : new()
    {
        // 确定从哪个路径读取
        // 首先先判断 默认数据文件夹中是否有我们想要的数据 如果有 就从中获取
        string path = Application.streamingAssetsPath + "/" + fileName + ".json";
        // 先判断是否存在这个文件
        if (!File.Exists(path))
        {
            path = Application.persistentDataPath + "/" + fileName + ".json";
        }
        // 如果还不存在
        if (!File.Exists(path))
        {
            return new T();
        }

        // 进行反序列化
        string jsonStr = File.ReadAllText(path);
        T data = default(T);
        switch (type)
        {
            case JsonType.JsonUtility:
                data = JsonUtility.FromJson<T>(jsonStr);
                break;
            case JsonType.LitJson:
                data = JsonMapper.ToObject<T>(jsonStr);
                break;
            default:
                break;
        }

        // 把对象返回出去
        return data;
    }
}
