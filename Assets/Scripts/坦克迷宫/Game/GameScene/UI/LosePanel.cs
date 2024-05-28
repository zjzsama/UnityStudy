using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel : BasePanel<LosePanel>
{
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnAgain;
    // Start is called before the first frame update
    void Start()
    {
        btnQuit.clickEvent += () =>
        {
            // 取消暂停
            Time.timeScale = 1;
            SceneManager.LoadScene("BeginScene");
        };
        btnAgain.clickEvent += () =>
        {
            // 取消暂停
            Time.timeScale = 1;
            // 再次切换到游戏场景 就可以达到所有场景重新加载 重头开始
            SceneManager.LoadScene("GameScene");
        };
        Hide();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
