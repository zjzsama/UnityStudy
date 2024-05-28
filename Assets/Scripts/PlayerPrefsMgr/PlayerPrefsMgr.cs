using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerPrefsMgr
{
    private static PlayerPrefsMgr instance = new PlayerPrefsMgr();
    public static PlayerPrefsMgr Instance
    {
        get
        {
            return instance;
        }
    }

    private PlayerPrefsMgr() //写成私有 防止外部new 单例模式
    {

    }

    //存储数据 data=数据对象 keyName=数据对象唯一的Key 自己控制
    public void SaveData(object data, string keyName)
    {
        //第一步 获取传入数据对象的所有字段
        Type dataType = data.GetType();
        //得到所有字段
        FieldInfo[] infos = dataType.GetFields();
        // for (int i = 0; i < infos.Length; i++)
        // {
        //     Debug.Log(infos[i]);
        // }

        #region 第二步 自己定义一个key的规则 进行数据存储
        //我们存储都是通过PlayerPrefs来进行存储的
        //保证Key的唯一性 我们就需要自己定义key的命名规则

        //自己的规则:keyName_数据类型_字段类型_字段名
        #endregion

        #region 第三步 遍历这些字段 进行数据存储
        string saveKeyName = "";
        for (int i = 0; i < infos.Length; i++)
        {
            //对每一个字段 进行数据存储
            //得到具体的字段信息
            FieldInfo fieldInfo = infos[i];//通过FieldInfo可以直接获取到 字段的类型 和字段的名字
            //字段的类型 filedinfo.FieldType.Name
            //字段的名字 filedinfo.Name
            //根据命名规则 来进行key的生成
            saveKeyName = keyName + "_" + dataType.Name + "_" + fieldInfo.FieldType.Name + "_" + fieldInfo.Name;
            // Debug.Log(saveKeyName);

            //得到了key 按照规则
            //接下来就是通过PlayerPrefs来进行存储

            //如何获取值
            // fieldInfo.GetValue(data);

            SaveValue(fieldInfo.GetValue(data), saveKeyName);
        }
        PlayerPrefs.Save();
        #endregion
    }

    private void SaveValue(object value, string keyName)
    {
        //直接通过PlayerPrefs进行存储
        //就是根据数据类型的不同 来决定使用哪一个API来进行存储
        //PlayerPrefs只支持三种类型的存储
        //判断数据是什么类型 然后进行存储
        Type filedType = value.GetType();

        //类型判断
        if (filedType == typeof(int))
        {
            // Debug.Log("存储int" + keyName);
            PlayerPrefs.SetInt(keyName, (int)value);
        }
        else if (filedType == typeof(float))
        {
            // Debug.Log("存储float" + keyName);
            PlayerPrefs.SetFloat(keyName, (float)value);
        }
        else if (filedType == typeof(string))
        {
            // Debug.Log("存储string" + keyName);
            PlayerPrefs.SetString(keyName, value.ToString());
        }
        else if (filedType == typeof(bool))
        {
            // Debug.Log("存储bool" + keyName);
            //自己定一个bool存储规则
            PlayerPrefs.SetInt(keyName, (bool)value ? 1 : 0);
        }

        //如何判断 泛型类的类型
        //通过反射判断 父子关系
        //相当于判断 字段是不是IList的子类
        else if (typeof(IList).IsAssignableFrom(filedType))
        {
            // Debug.Log("存储list" + keyName);
            //父类装子类
            IList list = value as IList; //value转换成Ilist类型
            //先存储 数量
            PlayerPrefs.SetInt(keyName, list.Count);
            int index = 0;//用于区分Key的标识
            foreach (var obj in list)
            {
                //存储具体的值
                SaveValue(obj, keyName + "[" + index + "]");
                ++index;
            }
        }
        //判断是不是Dictionary类型 通过父类判断
        else if (typeof(IDictionary).IsAssignableFrom(filedType))
        {
            // Debug.Log("存储Dictionary" + keyName);
            //父类装子类
            IDictionary dic = value as IDictionary;

            //先存储数量
            PlayerPrefs.SetInt(keyName, dic.Count);
            int index = 0;
            foreach (var key in dic.Keys)
            {
                SaveValue(key, keyName + "[" + index + "].key");
                SaveValue(dic[key], keyName + "[" + index + "].value");
                ++index;
            }
        }
        //基础数据类型都不是 那么就是自定义数据类型
        else
        {
            SaveData(value, keyName);
        }
    }

    //读取数据 type=想要读取的数据类型 keyName=数据对象唯一的Key 自己控制
    public object LoadData(Type type, string keyName)
    {
        //不用object对象传入 而是用 Type传入
        //主要目的是节约一行代码(在外部)
        //假设现在你要 读取一个Player类型的数据 如果是object 你就必须在外部new一个对象传入
        //现在有Type的 你只要传入 一个Type typeof(Player) 然后在内部动态创建一个对象给返回出来
        //达到了 在外部 少写一行代码的作用

        //根据传入的类型 和 keyName
        //依据存储数据时 key的拼接规则 来进行数据的获取赋值 返回出去

        //根据传入的Type 创建一个对象 用于存储数据
        object data = Activator.CreateInstance(type);
        //往这个new出来的对象中 填充数据
        //得到所有字段
        FieldInfo[] fieldInfos = type.GetFields();
        string loadKeyName = "";
        foreach (var info in fieldInfos)
        {
            //key的拼接规则一定和存储是一模一样的 这样才能找到对应数据
            loadKeyName = keyName + "_" + type.Name + "_" + info.FieldType.Name + "_" + info.Name;
            //结合PlayerPrefs 来读取数据
            //填充数据到data中
            info.SetValue(data, LoadValue(info.FieldType, loadKeyName));
        }

        return data;
    }
    private object LoadValue(Type filedType, string keyName)
    {
        //读取常见类型
        if (filedType == typeof(int))
        {
            return PlayerPrefs.GetInt(keyName);
        }
        else if (filedType == typeof(float))
        {
            return PlayerPrefs.GetFloat(keyName);
        }
        else if (filedType == typeof(string))
        {
            return PlayerPrefs.GetString(keyName);
        }
        else if (filedType == typeof(bool))
        {
            //根据自定义存储bool值的规则 来进行值的获取
            return PlayerPrefs.GetInt(keyName, 0) == 1 ? true : false;
        }
        //读取List类型
        else if (typeof(IList).IsAssignableFrom(filedType))
        {
            //得到长度
            int count = PlayerPrefs.GetInt(keyName, 0);
            //实例化一个List对象 进行赋值
            //用反射双A中的 Activitor来进行快速实例化List对象
            IList list = Activator.CreateInstance(filedType) as IList;
            for (int i = 0; i < count; i++)
            {
                //目的是得到 List中的泛型类型
                list.Add(LoadValue(filedType.GetGenericArguments()[0], keyName + "[" + i + "]"));
            }
            return list;
        }
        //判断Dictionary类型
        else if (typeof(IDictionary).IsAssignableFrom(filedType))
        {
            //得到长度
            int count = PlayerPrefs.GetInt(keyName, 0);
            //实例化一个Dictionary对象 进行赋值
            IDictionary dic = Activator.CreateInstance(filedType) as IDictionary;
            Type[] kvType = filedType.GetGenericArguments();
            for (int i = 0; i < count; i++)
            {
                dic.Add(LoadValue(kvType[0], keyName + "[" + i + "].key"), LoadValue(kvType[1], keyName + "[" + i + "].value"));
            }
            return dic;
        }
        else
        {
            return LoadData(filedType, keyName);
        }
    }
}


