using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : MonoBehaviour
{
    private static SettingPanel instance;
    public Rect toggleMusicPos;
    public Rect toggleSoundPos;
    public Rect btnPos;
    public GUIStyle btnStyle;
    private bool isSelMusic = true;
    private bool isSelSound = true;
    private float musicValue = 1f;
    public Rect musicPos;
    private float soundValue = 1f;
    public Rect soundPos;

    private void Awake()
    {
        instance = this;
        Hide();
    }
    private void OnGUI()
    {
        isSelMusic = GUI.Toggle(toggleMusicPos, isSelMusic, "音乐开关");
        isSelSound = GUI.Toggle(toggleSoundPos, isSelSound, "音效开关");
        //拖动条
        musicValue = GUI.HorizontalSlider(musicPos, musicValue, 0, 1);
        soundValue = GUI.HorizontalSlider(soundPos, soundValue, 0, 1);

        if (GUI.Button(btnPos, "", btnStyle))
        {
            //关闭面板功能
            Hide();
            //显示开始界面
            BeginPanel.Show();
        }
    }
    //面板的显示和隐藏
    public static void Show()
    {
        if (instance != null)
        {
            instance.gameObject.SetActive(true);
        }

    }
    public static void Hide()
    {
        if (instance != null)
        {
            instance.gameObject.SetActive(false);
        }
    }
    //总结:
    //1.要完成 面板之间 相互控制显示 有三种方法
    //第一种:都写在一个ONGUI上 通过bool来控制显影
    //第二种:挂载在同一个对象上 通过控制脚本的 失活激活 enable去控制代码是否执行 达到显影
    //第三种:挂载在不同的对象上 通过控制对象的 失活激活来 达到 面板的显影

    //2.关键的 如何在多个面板之间相互调用显影 我们通过静态变量和静态方法的方式
    //在Awake中初始化静态变量 如果要调用该方法 对象一开始不能失活
}
