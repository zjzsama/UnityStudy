using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RolePresenter : MonoBehaviour
{
    // 能够在Controller中得到界面才行
    private MVP_RoleView roleView;
    private static RolePresenter instance = null;

    public static RolePresenter Instance
    {
        get => instance;
    }
    // 1.界面的显影
    public static void ShowMe()
    {
        if (instance == null)
        {
            // 实例化面板对象
            GameObject res = Resources.Load<GameObject>("UI/RolePanel");
            GameObject obj = Instantiate(res);

            // 设置父对象是Canvas
            obj.transform.SetParent(GameObject.Find("Canvas").transform, false);

            instance = obj.GetComponent<RolePresenter>();
        }
        instance.gameObject.SetActive(true);
    }

    public static void HideMe()
    {
        if (instance != null)
        {
            // 方式一:直接删
            //Destroy(panel.gameObject);
            //panel = null;

            //方式二: 设置可见为隐藏
            instance.gameObject.SetActive(false);
        }
    }

    // 2.界面 事件的监听 来处理对应的业务逻辑
    private void Start()
    {
        // 挂载同样在一个对象上的 view脚本
        roleView = this.GetComponent<MVP_RoleView>();
        // 第一次界面更新
        //roleView.UpdateInfo(PlayerModel.Instance);
        UpdateInfo(PlayerModel.Instance);

        roleView.btnClose.onClick.AddListener(() =>
        {
            print("关闭角色面板");
            HideMe();
        });
        roleView.btnLevUp.onClick.AddListener(() =>
        {
            // 通过数据模块进行升级 达到数据改变
            PlayerModel.Instance.LevUp();
        });
        // 告知数据模块 当更新时 通知哪个函数做处理
        PlayerModel.Instance.AddEventListener(UpdateInfo);
    }
    private void UpdateInfo(PlayerModel data)
    {
        if (roleView != null)
        {
            //直接在P中得到v界面的控件 进行修改、开v和M的联系
            roleView.txtLev.text = "LV." + data.Lev;
            roleView.txtHp.text = data.Hp.ToString();
            roleView.txtAtk.text = data.Atk.ToString();
            roleView.txtDef.text = data.Def.ToString();
            roleView.txtCrit.text = data.Crit.ToString();
            roleView.txtMiss.text = data.Miss.ToString();
            roleView.txtLuck.text = data.Luck.ToString();
        }
    }
    private void OnDestroy()
    {
        PlayerModel.Instance.RemoveEventListener(UpdateInfo);
    }
}
