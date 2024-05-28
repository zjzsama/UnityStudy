using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTowerObj : TankBaseObj
{
    // 间隔开火
    // 应该有个间隔时间
    private float fireTime;
    public float fireTimer = 1;
    // 发射位置
    public Transform[] shootPos;
    // 子弹预设体关联
    public GameObject bulletObj;
    // Start is called before the first frame update
    void Start()
    {
        fireTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        fireTime += Time.deltaTime;
        if (fireTime >= fireTimer)
        {
            fireTime = 0;
            Fire();
        }
    }
    public override void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            // 实例化几个对象
            GameObject obj = Instantiate(bulletObj, shootPos[i].position, shootPos[i].transform.rotation);
            // 设置子弹拥有者
            BulletObj bullet = obj.GetComponent<BulletObj>();
            bullet.SetFather(this);
        }
    }
    public override void Wound(TankBaseObj other)
    {
        // 这里面什么都不写
        // 目的就是让固定不动的敌人不被伤害 永远不会死亡
    }
}
