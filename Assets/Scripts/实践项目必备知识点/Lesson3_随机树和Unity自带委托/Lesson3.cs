using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lesson3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 随机数
        // Unity的随机数
        // int规则 左包含 右不包含
        int randomNum = Random.Range(0, 100); // 0~99的数
        print(randomNum);
        // float 左包含 右包含
        float randomNumF = Random.Range(1.1f, 99.9f);
        // C#的随机数
        System.Random r = new System.Random();
        r.Next(0, 100);
        #endregion

        #region 知识点二 Unity自带委托
        // C#自带的委托
        System.Action ac = () => { print("Action"); };
        System.Action<int> ac2 = (x) => { print("Action<int> " + x); };
        System.Action<int, int> ac3 = (x, y) => { print("Action<int,int> " + x + "," + y); };
        System.Func<int> fc = () => { return 1; };
        System.Func<int, int> fc2 = (x) => { return x; };
        System.Func<int, int, string> fc3 = (x, y) => { return "x + y"; }; //最后一个参数是返回值
        // Unity自带的委托
        UnityAction uac1 = () => { };
        UnityAction<int> uac2 = (x) => { };
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
