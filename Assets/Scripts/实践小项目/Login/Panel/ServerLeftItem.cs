using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerLeftItem : MonoBehaviour
{
    // 按钮自己
    public Button btnSelf;
    // 显示内容
    public Text txtInfo;

    // 区间范围
    private int beginIndex;
    private int endIndex;

    public bool isSelect;
    public ChooseServerPanel panel; // 引用ChooseServerPanel
    // Start is called before the first frame update
    void Start()
    {
        btnSelf.onClick.AddListener(() =>
        {
            // TODO:通知选服面板 改变右侧内容
            ChooseServerPanel panel = UIManager.Instance.GetPanel<ChooseServerPanel>();
            panel.UpdateCurrentSelectedItem(this);
            panel.UpdatePanel(beginIndex, endIndex);
            isSelect = true;
        });
    }

    public void InitInfo(int beginIndex, int endIndex)
    {
        // 记录当前区间的按钮的 区间值
        this.beginIndex = beginIndex;
        this.endIndex = endIndex;

        txtInfo.text = beginIndex + " - " + endIndex + "区";
    }
    // Update is called once per frame
    void Update()
    {
        if (isSelect)
        {
            txtInfo.color = Color.white;
        }
    }
}
