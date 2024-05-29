using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson10 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 知识回顾
        // 我们目前已经学习了如何设置导入的图片
        // 如果我们想将导入的图片用于2D游戏开发 需要将图片类型设置为 Sprite精灵类型

        // 我们还学习了使用Sprite Editor精灵图片编辑器对精灵图片进行编辑

        // 但是我们还没有真正的用到这些图片
        // 这节课我们学习Sprite精灵图片的使用
        #endregion

        #region 知识点二 SpriteRender是什么
        // SpriteRender是精灵渲染器
        // 所有2D游戏中游戏资源(除UI外)都是通过Sprite Renderer让我们看到的
        // 它是2D游戏开发中的一个极为重要的组件
        #endregion

        #region 知识点三 2D对象创建
        // 1.直接拖入Sprite图片
        // 2.右键创建
        // 3.空物体添加脚本
        #endregion

        #region 知识点四 参数讲解

        #endregion

        #region 知识点五 代码设置
        GameObject obj = new GameObject();
        SpriteRenderer sr = obj.AddComponent<SpriteRenderer>();
        // 动态的改变图片
        sr.sprite = Resources.Load<Sprite>("1");

        Sprite[] sprs = Resources.LoadAll<Sprite>("RobotBoyCrouchSprite");
        sr.sprite = sprs[0];

        print(sprs[0].name);
        #endregion

        #region 总结
        // 主要掌握参数含义 和 如何代码控制
        // 其中重要的参数是
        // 1.绘制模式 控制缩放规则
        // 2.遮罩相关
        // 3.层级相关
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
