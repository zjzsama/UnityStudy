using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lesson07 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 Image是什么?

        #endregion

        #region 知识点二 Image参数

        #endregion

        #region 知识点三 代码控制

        Image img = this.GetComponent<Image>();
        img.sprite = Resources.Load<Sprite>("ui_TY_fanhui_01");

        (img.transform as RectTransform).sizeDelta = new Vector2(200, 200);
        img.raycastTarget = false;

        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
