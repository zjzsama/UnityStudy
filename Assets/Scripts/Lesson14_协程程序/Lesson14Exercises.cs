using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson14Exercises : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 利用协程制作一个记秒器
        StartCoroutine(MyCoroutine());
        #endregion


        #region 练习题二 请在场景中创建100000个随机位置的立方体,让其不会明显卡顿

        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(CreatCube(100000));
        }

    }
    // 练习题一
    IEnumerator MyCoroutine()
    {
        int time = 0;
        while (true)
        {
            print(time + "秒");
            time++;
            yield return new WaitForSeconds(1);
        }
    }
    // 练习题二
    IEnumerator CreatCube(int num)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obj.transform.position = new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));
            if (i % 1000 == 0)
            {
                yield return null;
            }

        }
    }

}


