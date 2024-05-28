using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 PlayerPrefs存储的数据存在哪里?
        //不同平台存储位置不一样

        //Windows

        //Android

        //IOS
        #endregion

        #region 知识点二 PlayerPrefs数据唯一性
        //PlayerPrefs中不同数据的唯一性
        //是由key决定的,不同的key决定不同的数据
        //同一项目中 如果不同数据key相同 会造成数据缺失
        //要保证数据不丢失就要建立一个保证key唯一的规则
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
