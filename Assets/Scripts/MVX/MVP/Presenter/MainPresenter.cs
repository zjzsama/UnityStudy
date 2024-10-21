using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPresenter : MonoBehaviour
{
    // 能够在Controller中得到界面才行
    private MVP_MainView mainView;
    private static MainPresenter instance = null;

    public static MainPresenter Instance
    {
        get => instance;
    }



    // 1.界面的显影
    public static void ShowMe()
    {
        if (instance == null)
        {
            // 实例化面板对象
            GameObject res = Resources.Load<GameObject>("UI/MainPanel");
            GameObject obj = Instantiate(res);

            // 设置父对象是Canvas
            obj.transform.SetParent(GameObject.Find("Canvas").transform, false);

            instance = obj.GetComponent<MainPresenter>();
        }
        instance.gameObject.SetActive(true);
    }

    public static void HideMe()
    {
        if (instance != null)
        {
            //方式一: 直接删
            //Destroy(instance.gameObject);
            //instance = null;

            //方式二: 设置可见为隐藏
            instance.gameObject.SetActive(false);
        }
    }


    // 2.界面 事件的监听 来处理对应的业务逻辑
    private void Start()
    {
        // 挂载同样在一个对象上的 view脚本
        mainView = this.GetComponent<MVP_MainView>();
        // 第一次界面更新
        //mainView.UpdateInfo(PlayerModel.Instance);
        // 通过P自己的更新方法 更新View
        UpdateInfo(PlayerModel.Instance);

        // 2.界面事件的监听 来处理对应的业务逻辑
        mainView.btnRole.onClick.AddListener(() =>
        {
            print("点击显示角色面板");
            // 通过Controller显示面板
            RolePresenter.ShowMe();
        });
        mainView.btnSill.onClick.AddListener(() =>
        {

        });
        PlayerModel.Instance.AddEventListener(UpdateInfo);
    }
    // 3.界面的更新
    private void UpdateInfo(PlayerModel data)
    {
        if (mainView != null)
        {
            //mainView.UpdateInfo(data);
            mainView.txtName.text = data.PlayerName; mainView.txtLev.text = "LV."
            + data.Lev;
            mainView.txtMoney.text = data.Money.ToString();
            mainView.txtGem.text = data.Gem.ToString();
            mainView.txtPower.text = data.Power.ToString();
        }
    }

    private void OnDestroy()
    {
        PlayerModel.Instance.RemoveEventListener(UpdateInfo);
    }
}
