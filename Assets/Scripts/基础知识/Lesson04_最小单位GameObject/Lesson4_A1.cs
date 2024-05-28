using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_Do_Type
{
    ChangeName,//改名
    ActiveFalse,//失活
    DelayDes,//延迟删除
    Des,//删除
}
public class Lesson4_A1 : MonoBehaviour
{
    //声明一个枚举 表示不同的状态
    public E_Do_Type type = E_Do_Type.ChangeName;
    public GameObject B; //通过Inspector窗口关联B效率更高
    void Start()
    {
        switch (type)
        {
            case E_Do_Type.ChangeName:
                B.name = "B改名";
                break;
            case E_Do_Type.ActiveFalse:
                B.SetActive(false);
                break;
            case E_Do_Type.DelayDes:
                GameObject.Destroy(B, 5);
                break;
            case E_Do_Type.Des:
                DestroyImmediate(B);
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
