using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginData
{
    public string userName;
    public string password;

    // 是否记住密码
    public bool remeberPassWord;
    // 是否自动登录
    public bool autoLogin;

    // T1ODO:服务器相关
    // -1 代表没有选择过服务器
    public int frontServerID = -1;
}
