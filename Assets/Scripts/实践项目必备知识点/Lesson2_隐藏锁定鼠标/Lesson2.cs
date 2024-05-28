using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson2 : MonoBehaviour
{
    public Texture2D cursorTexture;
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 隐藏鼠标
        Cursor.visible = false;
        #endregion

        #region 知识点二 锁定鼠标
        // None就是不锁定
        // Locked是锁定 鼠标会被限制在中心点 不仅会锁定 还会被隐藏 可以通过ESC摆脱编辑模式下的锁定
        // Confine是限制在窗口范围内
        Cursor.lockState = CursorLockMode.Locked;
        #endregion

        #region 知识点三 设置鼠标图片
        // 参数一:光标图片
        // 参数二:偏移位置 相对图片左上角
        // 参数三:平台支持的光标模式(硬件或软件)
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
