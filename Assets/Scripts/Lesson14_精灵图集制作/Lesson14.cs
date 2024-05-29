using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Lesson14 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 为什么要打图集
        // 打图集的目的是减少DrawCall 提高性能
        // 在2D游戏开发中 以及UI开发中是会频繁使用的功能
        #endregion

        #region 知识点二 在Unity中打开自带的打图集功能
        // Edit->Project Setting->Editor->Sprite Packer
        // 打开后 会在Project视图中多出一个Sprite Packer面板
        // 可以在该面板中进行打图集的操作

        // Disabled:默认设置 不会打包图集
        // Enabled For Builds(Legacy Sprite Packer):Unity仅在构建时打包图集,在编辑模式下不会打包图集
        // Always Enabled(Legacy Sprite Packer):Unity在构建时打包图集,编辑模式下运行前会打包图集
        // Legacy Sprite Packer传统打包模式 相对下面两种模式来说 多了一个设置图片之间的间隔距离
        // Padding Power:选择打包算法在计算打包的精灵之间以及精灵与生成的图集边缘之间的间隔距离
        // 这里的数字代表 2的n次方

        // Enabled For Build:Unity仅在构建时打包图集,在编辑器模式下不会打包
        // Always Enabled:Unity在构建时打包图集,在编辑模式下运行前会打包图集


        #endregion

        #region 知识点三 打图集面板参数相关

        #endregion

        #region 知识点四 代码控制
        GameObject obj = new GameObject();
        SpriteRenderer sr = obj.AddComponent<SpriteRenderer>();
        SpriteAtlas atlas = Resources.Load<SpriteAtlas>("MyAtlas");
        sr.sprite = atlas.GetSprite("2");
        #endregion

        #region 知识点五 观察DrawCall数量

        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
