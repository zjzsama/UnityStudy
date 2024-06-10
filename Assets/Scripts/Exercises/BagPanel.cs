using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagPanel : MonoBehaviour
{
    public static BagPanel instance;
    public ScrollRect svItems;
    public Button btnClose;

    public GameObject itemPref;

    private void Awake()
    {
        instance = this;
        // 一开始隐藏自己
        this.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        // 第一步 动态创建n个图标 作为滚动视图中显示的内容
        for (int i = 0; i < 30; i++)
        {
            GameObject item = Instantiate(itemPref);
            item.transform.SetParent(svItems.content, false);
            // 设置格子位置
            item.transform.localPosition = new Vector3(90, -85, 0) + new Vector3(i % 4 * 160, -i / 4 * 160, 0);
        }
        // 第二步 设置 Content的高
        svItems.content.sizeDelta = new Vector2(0, Mathf.CeilToInt(30 / 4f));

        btnClose.onClick.AddListener(() =>
        {
            this.gameObject.SetActive(false);
            GamePanel.instance.ShowMe();
        });
    }
}
