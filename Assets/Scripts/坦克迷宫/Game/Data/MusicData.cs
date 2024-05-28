using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicData
{
    // 背景音乐是否开启
    public bool isOpenBK;
    // 音效是否开启
    public bool isOpenSound;
    // 背景音乐大小
    public float bkValue;
    // 音效音量大小
    public float soundValue;
    // 加一个是否是第一次加载的标识
    public bool notFirst = false;
}
