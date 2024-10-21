using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PureMVC_MainView : MonoBehaviour
{
    // 1.找控件
    public Button btnRole;
    public Button btnSill;

    public Text txtName;
    public Text txtLev;
    public Text txtMoney;
    public Text txtGem;
    public Text txtPower;

    // 2.提供面板更新的相关方法给外部
    // 按照MVC的思想 能直接提供更新方法
    // MVP不用
    public void UpdateInfo(PlayerDataObj data)
    {
        txtName.text = data.PlayerName;
        txtLev.text = "LV." + data.Lev;
        txtMoney.text = data.Money.ToString();
        txtGem.text = data.Gem.ToString();
        txtPower.text = data.Power.ToString();
    }
}
