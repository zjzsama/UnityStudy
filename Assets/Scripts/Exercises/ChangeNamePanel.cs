using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeNamePanel : MonoBehaviour
{
    public static ChangeNamePanel instance;


    public InputField inputName;

    public Button btnChangeName;
    private void Awake()
    {
        instance = this;
        // 一开始隐藏自己
        this.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        btnChangeName.onClick.AddListener(() =>
        {
            // 输入框输入的内容赋值给 游戏面板的 名字控件
            GamePanel.instance.txtName.text = inputName.text;
            this.gameObject.SetActive(false);
            GamePanel.instance.ShowMe();
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
