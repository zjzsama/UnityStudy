using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lesson9Exercise : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 练习题一
        //请为Transform 写一个拓展方法 可以将它的子对象按名字长短进行排序并改变它们的顺序
        //名字短的在前面 名字长的在后面
        this.transform.Sort();
        #endregion

        #region 练习题二
        //为Transform写一个拓展方法,传入一个名字查找子对象 即使是子对象的子对象也能找到
        print(this.transform.CustomFind("4646456").name);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
