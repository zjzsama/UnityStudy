using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PureMVCMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameFacede.Instance.StartUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            // 显示主面板
            GameFacede.Instance.SendNotification(PureNotification.SHOW_PANEL, "MainPanel");
        }
        // 隐藏主面板
        if (Input.GetKeyDown(KeyCode.N))
        {
            GameFacede.Instance.SendNotification(PureNotification.HIDE_PANEL, GameFacede.Instance.RetrieveMediator(MainViewMediator.NAME));
            GameFacede.Instance.SendNotification(PureNotification.HIDE_PANEL, GameFacede.Instance.RetrieveMediator(RoleViewMediator.NAME));
        }
    }
}
