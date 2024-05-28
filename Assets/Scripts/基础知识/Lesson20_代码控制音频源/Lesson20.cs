using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson20 : MonoBehaviour
{
    AudioSource audioSource;
    private bool isPaused = false;
    public GameObject obj;
    public AudioClip clip;
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        #region 知识点三 如何动态控制音效播放
        //1.直接在要播放音效的对象上挂载脚本 控制播放

        //2.实例化挂载了音效源脚本的对象
        //这个方法用的比较少
        // Instantiate(obj);

        //3.用一个AudioSource来控制不同的音效
        AudioSource aus = this.gameObject.AddComponent<AudioSource>();
        aus.clip = clip;
        aus.Play();
        #endregion

        //潜在知识点
        //一个GameObject可以挂载多个 音效源脚本
    }

    // Update is called once per frame
    void Update()
    {
        #region 知识点一 代码控制播放停止
        if (Input.GetKeyDown(KeyCode.P) && audioSource.isPlaying == false)
        {
            //播放音效
            audioSource.Play();
            //延迟播放 填写的是秒数
            // audioSource.PlayDelayed(2);
        }
        if (Input.GetKeyDown(KeyCode.P) && audioSource.isPlaying == true)
        {
            //停止音效
            audioSource.Stop();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isPaused == false)
        {
            //暂停
            audioSource.Pause();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isPaused == true)
        {
            //播放
            audioSource.UnPause();
        }
        #endregion

        #region 知识点二 怎么检测音效播放完毕
        if (audioSource.isPlaying)
        {
            print("播放中");
        }
        else
        {
            print("播放完毕");
        }
        #endregion
    }
}
