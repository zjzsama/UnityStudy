using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson3_Mono中的重要成员 : MonoBehaviour
{
    public GameObject otherGameObject;
    private void Start()
    {
        #region 知识点一 重要成员
        // 1.获取依附的GameObject
        print(gameObject.name);
        // 2.获取依附的GameObject的信息位置
        print(transform.position);//位置
        print(transform.eulerAngles); //欧拉角
        print(transform.lossyScale);//缩放大小
        // 这种写法和上面是一样的 都是得到依附的对象的位置信息
        // this.gameObject.transform

        // 3.获取脚本是否激活
        // this.enabled = false;
        // 获取别的脚本对象 依附的gameobject和transform的信息
        print(otherGameObject.gameObject);
        print(otherGameObject.transform);
        #endregion

        #region 知识点二 重要方法
        // 得到依附对象上挂载的其他脚本
        // 1.得到自己挂载的单个脚本
        // 根据脚本名获取
        // 如果获取失败,就是没有对应的脚本,返回null
        Lesson3_Test t = GetComponent("Lesson3_Test") as Lesson3_Test;
        print(t);
        // 根据Type获取
        t = GetComponent(typeof(Lesson3_Test)) as Lesson3_Test;
        print(t);
        // 根据泛型获取 建议使用泛型获取 因为不用二次转换
        t = GetComponent<Lesson3_Test>();
        print(t);

        // 只要你能得到场景中别的对象或者对象依附的脚本
        // 那就可以获取到它的所有信息
        // 2.得到自己挂载的多个脚本
        Lesson3_Mono中的重要成员[] array = GetComponents<Lesson3_Mono中的重要成员>();
        print(array.Length);
        List<Lesson3_Mono中的重要成员> list = new List<Lesson3_Mono中的重要成员>();
        GetComponents<Lesson3_Mono中的重要成员>(list);
        print(list.Count);
        // 3.得到子对象挂载的脚本(他默认也会在自身查找是否挂载了该脚本)
        // 函数参数默认传 false 意思是 如果子对象失活 不会从这个对象上找是否含有对应脚本
        // 如果传true 即使失活也会在子对象找到对应脚本

        // 得子对象 单个
        t = GetComponentInChildren<Lesson3_Test>(true);
        print(t);

        // 得子对象 多个
        Lesson3_Test[] lt = GetComponentsInChildren<Lesson3_Test>(true);
        print(lt.Length);
        List<Lesson3_Test> ltList = new List<Lesson3_Test>();
        GetComponentsInChildren<Lesson3_Test>(true, ltList);
        print(ltList.Count);
        // 4.得到父对象挂载的脚本(也会找自身是否含有该脚本)
        t = GetComponentInParent<Lesson3_Test>();
        print(t);

        lt = GetComponentsInParent<Lesson3_Test>();
        print(lt.Length);
        // 5.尝试获取脚本
        Lesson3_Test t2;
        if (TryGetComponent<Lesson3_Test>(out t2))
        {
            // 逻辑处理
        }

        #endregion
    }
}
