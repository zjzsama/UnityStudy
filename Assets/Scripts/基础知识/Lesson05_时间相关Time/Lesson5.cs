using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson5 : MonoBehaviour
{

    void Update()
    {
        #region Time相关内容主要用来干啥
        //时间相关内容 主要用于游戏中参与位移 计时 时间暂停等
        #endregion

        #region 知识点一 时间缩放比例
        //时间停止
        Time.timeScale = 0;
        //恢复正常
        Time.timeScale = 1;
        //2倍速
        Time.timeScale = 2;
        #endregion

        #region 知识点二 帧间隔时间
        //帧间隔时间主要用来计算位移
        //路程=时间*速度
        //根据需求 选择参与计算的间隔时间
        //如果希望 游戏暂停时就不动 用deltaTime
        //如果希望 不受影响 用unscaledDeltaTime

        //帧间隔时间:最近的一帧用了多少时间
        //受scale影响
        print("帧间隔时间" + Time.deltaTime);
        //不受scale影响的帧间隔时间
        print("不受scale影响的帧间隔时间" + Time.unscaledDeltaTime);

        #endregion

        #region 知识点三 游戏开始到现在的时间
        //它主要用来计时 单机游戏计时
        //受scale影响
        print("游戏开始到现在的时间:" + Time.time);
        //不受scale影响
        print("不受scale影响的游戏开始到现在的时间:  " + Time.unscaledTime);
        #endregion

        #region 知识点五 帧数
        //从开始到现在游戏跑了多少帧(次循环)
        print("帧数:" + Time.frameCount);
        #endregion
    }
    private void FixedUpdate()
    {
        #region 知识点四 物理帧间隔时间 FixedUpdate
        //受scale影响
        print("受scale影响的物理帧间隔时间:" + Time.fixedDeltaTime);
        //不受scale影响
        print("不受scale影响的物理帧间隔时间:" + Time.fixedUnscaledDeltaTime);
        #endregion
    }
}
