using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tools
{
    //将子对象按名字长短进行排序

    public static void Sort(this Transform obj)
    {
        //利用list容器比较符合
        List<Transform> list = new List<Transform>();
        for (int i = 0; i < obj.childCount; i++)
        {
            list.Add(obj.GetChild(i));
        }
        list.Sort((a, b) =>
        {
            if (a.name.Length > b.name.Length)
                return 1;
            else
                return -1;
        });

        //根据 list的排序结果 重新设置每一个对象的索引编号
        for (int i = 0; i < list.Count; i++)
        {
            list[i].SetSiblingIndex(i);
        }
    }
    public static Transform CustomFind(this Transform father, string childName)
    {
        //我要找的对象
        Transform target = null;
        //先从自己身上找
        target = father.Find(childName);
        if (target != null)
        {
            return target;
        }

        //如果没有找到 那就找自己子对象的子对象
        for (int i = 0; i < father.childCount; i++)
        {
            //让子对象帮我找 有没有这个名字的子对象
            //递归
            target = father.GetChild(i).CustomFind(childName);

            //找到直接返回
            if (target != null)
            {
                return target;
            }
        }
        return target;
    }
}

