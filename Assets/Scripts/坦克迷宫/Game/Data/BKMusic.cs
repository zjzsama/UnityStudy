using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKMusic : MonoBehaviour
{
    private static BKMusic instance;
    private AudioSource audioSource;
    public static BKMusic Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;
        // 得到自己依附的游戏对象上的 挂载的音频源脚本
        audioSource = this.GetComponent<AudioSource>();
        // 初始化时根据数据进行设置
        ChangeValue(GameDataMgr.Instance.musicData.bkValue);
        ChangeOpen(GameDataMgr.Instance.musicData.isOpenBK);
    }

    public void ChangeValue(float value)
    {
        audioSource.volume = value;
    }
    public void ChangeOpen(bool isOpen)
    {
        // 开启就是静音
        audioSource.mute = !isOpen;
    }
}
