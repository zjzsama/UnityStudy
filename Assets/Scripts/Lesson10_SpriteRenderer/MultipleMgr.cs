using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleMgr
{
    private static MultipleMgr instance = new MultipleMgr();
    public static MultipleMgr Instance => instance;
    private MultipleMgr()
    {

    }

    // 存储大图对应的小图资源
    private Dictionary<string, Dictionary<string, Sprite>> dic = new Dictionary<string, Dictionary<string, Sprite>>();
    public Sprite GetSprite(string multipleName, string spriteName)
    {
        // 判断是否加载过大图
        if (dic.ContainsKey(multipleName))
        {
            // 判断大图是否有小图信息
            if (dic[multipleName].ContainsKey(spriteName))
            {
                return dic[multipleName][spriteName];
            }
            // 加载小图信息
            else
            {
                Dictionary<string, Sprite> dicTmp = new Dictionary<string, Sprite>();
                Sprite[] sprs = Resources.LoadAll<Sprite>(multipleName);
                for (int i = 0; i < sprs.Length; i++)
                {
                    dicTmp.Add(sprs[i].name, sprs[i]);
                }
                dic.Add(multipleName, dicTmp);
                if (dicTmp.ContainsKey(spriteName))
                {
                    return dicTmp[spriteName];
                }
            }
        }
        return null;
    }
    public void ClearInfo()
    {
        // 清空
        dic.Clear();
        // 卸载资源
        Resources.UnloadUnusedAssets();
    }
}


