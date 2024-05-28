using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson19 : MonoBehaviour
{
    private Texture tex;
    void Start()
    {
        #region 知识点一 Resources重复加载资源会浪费内存吗?
        // 其实Resources加载一次资源后 该资源会一直存在内存中作为缓存
        // 第二次加载发现缓存中存在该资源 会直接取出来使用
        // 所以 多次重复加载不会浪费内存
        // 但是会 浪费性能(每次加载都会查找取出,始终伴随一些性能消耗)
        #endregion

        #region 知识点二 如何手动释放掉缓存中的资源
        // 1.卸载指定资源
        // Resources.UnloadAsset方法

        // 注意:
        // 该方法 不能释放 GameObject对象 因为他会用于实例化对象 
        // 他只能用于一些 不需要实例化的内容 比如 图片音效和文本等等
        // 一般情况下 我们很少单独使用它
        GameObject obj = Resources.Load<GameObject>("Cube");
        // 即使是没有实例化的对象 也不能进行卸载
        // Resources.UnloadAsset(obj);

        // 2.卸载未使用的资源
        // 注意:
        // 一般在过场景时和GC一起使用
        Resources.UnloadUnusedAssets();
        GC.Collect();
        #endregion

        #region 总结
        // Resources.UnloadAsset 卸载指定资源 但是不能卸载GameObject对象
        //  Resources.UnloadUnusedAssets 卸载未使用的资源 一般过场景配合GC使用
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("加载资源");
            tex = Resources.Load<Texture>("Tex/Test");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("卸载资源");
            Resources.UnloadAsset(tex);
            tex = null;
        }
    }
}
