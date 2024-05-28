using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lesson1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        #region 知识点一 场景切换
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //切换到场景2
            //直接写场景可能会报错 因为没有把场景加入到列表中
            SceneManager.LoadScene("Test2");
        }
        #endregion

        #region 知识点二 游戏退出
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 执行这句代码就会结束游戏
            // 编辑模式下不会起作用
            // 一定是发布游戏过后 才有用
            Application.Quit();
        }

        #endregion
    }
}
