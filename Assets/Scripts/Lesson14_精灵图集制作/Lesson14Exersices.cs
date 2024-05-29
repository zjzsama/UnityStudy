using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Lesson14Exersices : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 练习题一
        // 用代码控制图集
        GameObject obj = new GameObject();
        SpriteRenderer sr = obj.AddComponent<SpriteRenderer>();
        SpriteAtlas altas = Resources.Load<SpriteAtlas>("PigAtlas");
        sr.sprite = altas.GetSprite("1");
        #endregion

        #region 练习题二
        // 在场景中有三张图片 3张图片叠在一起放,最底层和最上层的图片在一个图集中
        // 中间的图片和他们不在一个图集中,当前的DrawCall是多少? 3
        #endregion

    }

    // Update is called once per frame
    void Update()
    {

    }
}
