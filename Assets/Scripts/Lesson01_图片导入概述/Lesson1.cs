using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 Unity支持的图片格式
        // Unity支持的图片格式有很多
        // BMP:是Windows操作系统的标准图像文件格式 特点是几乎不进行压缩 占磁盘空间大
        // TIF:基本不损失图片信息的图片格式 缺点是体积大

        // JPG:一般指JPEG格式,属于有损压缩格式 能够让图像压缩在很小的存储空间 一定程度上会损失图片数据 无透明通道
        // PNG:无损压缩格式 压缩比高 生成文件小 有透明通道

        // TGA:支持压缩 使用不失真的压缩算法 还支持编码压缩 体积小 效果清晰 兼备BMP的图像质量和JPG的体积优势 有透明通道
        // PSD:是PhotoShop(PS)图形处理软件的专用格式,通过一些第三方工具或自制工具可以直接将PSD界面转化为UI界面

        // 其他还支持
        // EXR GIF HDR IFF PICT等等

        // Unity最常用的是 JPG,PNG,TGA三种格式


        #endregion

        #region 知识点二 图片设置的六大部分
        // 1.纹理类型
        // 2.纹理形状
        // 3.高级设置
        // 4.平铺拉伸
        // 5.平台设置
        // 6.预览窗口

        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
