using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MVP_RoleView : MonoBehaviour
{
    // 1.找控件
    public Button btnClose;
    public Button btnLevUp;

    public Text txtLev;
    public Text txtHp;
    public Text txtAtk;
    public Text txtDef;
    public Text txtCrit;
    public Text txtMiss;
    public Text txtLuck;

    // 2.提供面板更新方法给外部
    // 方法可选 到时候可以直接在P里面通过访问控件修改
}
