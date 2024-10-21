using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MP_RolePanel : BasePanel
{
    // 1.找控件
    // 2.处理逻辑
    // 3.面板更新
    // Start is called before the first frame update
    void Start()
    {
        // 第一次显示时更新面板
        UpdateInfo(PlayerModel.Instance);
        PlayerModel.Instance.AddEventListener(UpdateInfo);
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void OnClick(string btnName)
    {
        base.OnClick(btnName);
        switch (btnName)
        {
            case "btnClose":
                UIManager.GetInstance().HidePanel("RolePanel");
                break;
            case "btnLevUp":
                PlayerModel.Instance.LevUp();
                break;
            default:
                break;
        }
    }

    public void UpdateInfo(PlayerModel data)
    {
        GetControl<Text>("txtLev").text = "LV." + data.Lev;
        GetControl<Text>("txtHp").text = data.Hp.ToString();
        GetControl<Text>("txtAtk").text = data.Atk.ToString();
        GetControl<Text>("txtDef").text = data.Def.ToString();
        GetControl<Text>("txtCrit").text = data.Crit.ToString();
        GetControl<Text>("txtMiss").text = data.Miss.ToString();
        GetControl<Text>("txtLuck").text = data.Luck.ToString();
    }

    private void OnDestroy()
    {
        PlayerModel.Instance.RemoveEventListener(UpdateInfo);
    }
}
