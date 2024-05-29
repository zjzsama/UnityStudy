﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson34 : MonoBehaviour
{
    public Sprite[] sprites;

    private SpriteRenderer sr;

    private float time;

    private int nowIndex;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprites[nowIndex];
        #region 知识点一 什么是序列帧动画
        // 我们最常见的序列帧动画就是日本动漫
        // 以固定的时间间隔 按序列切换图片就是 序列帧动画的本质
        // 当固定时间间隔足够短 我们的肉眼就会认为图片是连续动态的 进而形成动画(会动的画面)

        // 它的本质和游戏的帧率概念有点类似

        // 原理就是一个循环中按一定时间间隔不停地切换显示的图片
        #endregion

        #region 知识点二 代码制作序列帧动画
        // 先尝试用原理 通过代码实现序列帧动画
        #endregion

        #region 知识点三 Animation窗口制作序列帧动画
        // 方法一:
        // 1.创建一个空物体
        // 2.创建一个动画
        // 3.直接将某一个动作的序列帧拖入窗口中

        // 方法二:
        // 直接将图片拖入Hierarchy层级窗口中

        // 注意:需要修改动画帧率 来控制动画的播放速度
        #endregion

        #region 知识点四 利用Animator进行动画控制

        #endregion

    }

    // Update is called once per frame
    void Update()
    {
        // 每一次增加帧间隔时间
        time += Time.deltaTime;
        // 当帧间隔时间达到某一条件时 就切换图片
        if (time >= 0.03f)
        {
            // 索引增加 切换图片
            nowIndex++;
            // 如果显示到最后一张 从头显示
            if (nowIndex >= sprites.Length)
            {
                nowIndex = 0;
            }
            sr.sprite = sprites[nowIndex];
            time = 0;
        }
    }
}
