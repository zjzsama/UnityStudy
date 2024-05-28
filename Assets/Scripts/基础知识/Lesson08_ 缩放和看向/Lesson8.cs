using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson8 : MonoBehaviour
{
    public Transform lookObj;
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 缩放
        //相对世界坐标系
        print(this.transform.lossyScale);
        //相对于本地坐标系(父对象)
        print(this.transform.localScale);

        //注意:
        //1.同样缩放不能只改xyz 只能一起改(相对于世界坐标系的缩放大小 只能得不能改)
        // this.transform.localScale = new Vector3(1, 1, 1);
        //2.Unity没有提供关于缩放的API
        //之前的 旋转 位移都提供的对应的API 但是缩放没有
        //如果想要 就要自己去写(自己算)
        #endregion
    }
    // Update is called once per frame
    void Update()
    {
        #region 知识点二 看向
        //让一个对象的面朝向 可以一直看向某一个点或某一个对象
        //看向一个点 相对于世界坐标系
        // this.transform.LookAt(Vector3.zero);

        //看向一个对象 就传入看向对象的Transform信息
        this.transform.LookAt(lookObj);
        #endregion
    }
}
