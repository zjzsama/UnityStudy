using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginMgr
{
    private static LoginMgr instance = new LoginMgr();
    public static LoginMgr Instance => instance;

    private LoginData loginData;
    // 注册数据
    private RegisterData registerData;
    public RegisterData RegisterData => registerData;
    // 所有服务器数据
    private List<ServerInfo> serverData;
    public List<ServerInfo> ServerData => serverData;

    // 公共属性 方便外面获取
    public LoginData LoginData => loginData;
    private LoginMgr()
    {
        // 直接通过Json管理器 来读取对应数据
        loginData = JsonMgr.Instance.LoadData<LoginData>("LoginData");

        // 读取注册数据
        registerData = JsonMgr.Instance.LoadData<RegisterData>("RegisterData");

        //读取服务器数据
        serverData = JsonMgr.Instance.LoadData<List<ServerInfo>>("ServerInfo");
    }

    #region 登录数据
    // 存储登录数据相关
    public void SaveLoginData()
    {
        JsonMgr.Instance.SaveData(loginData, "LoginData");
    }
    // 主要用于 注册成功后 清理登录数据
    public void ClearLoginData()
    {
        loginData.frontServerID = -1;
        loginData.autoLogin = false;
        loginData.remeberPassWord = false;
    }
    #endregion

    #region 注册数据

    // 存储数据
    public void SaveRegisterData()
    {
        JsonMgr.Instance.SaveData(registerData, "RegisterData");
    }
    // 注册方法
    public bool RegisterUser(string userName, string password)
    {
        // 判断用户是否已经存在
        if (registerData.registerInfo.ContainsKey(userName))
        {
            return false;
        }
        // 如果不存在 证明可以注册
        // 存储新用户名和密码
        registerData.registerInfo.Add(userName, password);
        // 本地存储
        SaveRegisterData();
        // 注册成功
        return true;
    }
    // 验证用户名密码是否合法
    public bool CheckInfo(string userName, string password)
    {
        // 判断是否有该用户
        if (registerData.registerInfo.ContainsKey(userName))
        {
            // 密码相同证明 登录成功
            if (registerData.registerInfo[userName] == password)
            {
                return true;
            }
        }
        // 用户名和密码不合法
        return false;
    }
    #endregion
}
