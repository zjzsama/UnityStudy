using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObj : MonoBehaviour
{
    // 用于实例化的子弹对象
    public GameObject bullet;
    // 外部决定到底有几个位置
    public Transform[] shootPos;
    // 武器拥有者
    public TankBaseObj owner;
    public void SetOwner(TankBaseObj owner)
    {
        this.owner = owner;
    }
    public void Fire()
    {
        // 根据位置创建对应个子弹
        for (int i = 0; i < shootPos.Length; i++)
        {
            // 创建子弹
            GameObject obj = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);
            // 控制子弹行为
            BulletObj bulletObj = obj.GetComponent<BulletObj>();
            bulletObj.SetFather(owner);
        }
    }
}
