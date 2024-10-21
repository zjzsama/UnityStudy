using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RolePanel : MonoBehaviour
{
    // 1.获得控件
    public Text txtLev;
    public Text txtHp;
    public Text txtAtk;
    public Text txtDef;
    public Text txtCrit;
    public Text txtMiss;
    public Text txtLuck;

    public Button btnClose;
    public Button btnLevUp;
    private static RolePanel panel;
    public static void ShowMe()
    {
        if (panel == null)
        {
            // 实例化面板对象
            GameObject res = Resources.Load<GameObject>("UI/RolePanel");
            GameObject obj = Instantiate(res);

            // 设置父对象是Canvas
            obj.transform.SetParent(GameObject.Find("Canvas").transform, false);

            panel = obj.GetComponent<RolePanel>();
        }
        // 显示完面板 更新该面板信息
        panel.UpdateInfo();
    }
    public static void HideMe()
    {
        if (panel != null)
        {
            // 方式一:直接删
            Destroy(panel.gameObject);
            panel = null;

            // 方式二:设置可见为隐藏
            //panel.gameObject.SetActive(false);
        }

    }

    // 4.动态显影
    // Start is called before the first frame update
    void Start()
    {
        // 2.添加事件
        btnClose.onClick.AddListener(() =>
        {
            Debug.Log("关闭");
            HideMe();
        });
        btnLevUp.onClick.AddListener(() =>
        {
            Debug.Log("升级");
            // 升级其实就是 数据的更新
            // 获取本地数据
            int lev = PlayerPrefs.GetInt("PlayerLev", 1);
            int hp = PlayerPrefs.GetInt("PlayerHp", 100);
            int atk = PlayerPrefs.GetInt("PlayerAtk", 20);
            int def = PlayerPrefs.GetInt("PlayerDef", 10);
            int crit = PlayerPrefs.GetInt("PlayerCrit", 20);
            int miss = PlayerPrefs.GetInt("PlayerMiss", 10);
            int luck = PlayerPrefs.GetInt("PlayerLuck", 40);

            // 然后按一定的规则改变
            lev += 1;
            hp += lev;
            atk += lev;
            def += lev;
            crit += lev;
            miss += lev;
            luck += lev;
            // 存起来
            PlayerPrefs.SetInt("PlayerLev", lev);
            PlayerPrefs.SetInt("PlayerHp", hp);
            PlayerPrefs.SetInt("PlayerAtk", atk);
            PlayerPrefs.SetInt("PlayerDef", def);
            PlayerPrefs.SetInt("PlayerCrit", crit);
            PlayerPrefs.SetInt("PlayerMiss", miss);
            PlayerPrefs.SetInt("PlayerLuck", luck);

            // 同步更新面板数据
            UpdateInfo();
            // 更新主面板内容
            MainPanel.Panel.UpdateInfo();
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
    // 3.更新信息
    private void UpdateInfo()
    {
        txtLev.text = "LV." + PlayerPrefs.GetInt("PlayerLev", 1);
        txtHp.text = PlayerPrefs.GetInt("PlayerHp", 100).ToString();
        txtAtk.text = PlayerPrefs.GetInt("PlayerAtk", 20).ToString();
        txtDef.text = PlayerPrefs.GetInt("PlayerDef", 10).ToString();
        txtCrit.text = PlayerPrefs.GetInt("PlayerCrit", 20).ToString();
        txtMiss.text = PlayerPrefs.GetInt("PlayerMiss", 10).ToString();
        txtLuck.text = PlayerPrefs.GetInt("PlayerLuck", 40).ToString();
    }
}
