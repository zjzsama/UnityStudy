using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : TankBaseObj
{
    float kX;
    float kY;
    // 当前装备的武器
    public WeaponObj nowWeapon;
    public Transform weaponPos;
    private void Awake()
    {
        hp = maxHp;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 1.ws键控制前进 ad键控制旋转
        kX = Input.GetAxis("Horizontal");
        kY = Input.GetAxis("Vertical");
        this.transform.Translate(kY * Vector3.forward * moveSpeed * Time.deltaTime);
        this.transform.Rotate(kX * Vector3.up * roundSpeed * Time.deltaTime);
        // 2.鼠标左右移动控制炮台旋转
        // 鼠标轴向输入检测
        tankHead.transform.Rotate(Input.GetAxis("Mouse X") * Vector3.up * headRotateSpeed * Time.deltaTime);
        // 3.开火
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    public override void Fire()
    {
        if (nowWeapon != null && Time.timeScale != 0)
        {
            nowWeapon.Fire();
        }
    }
    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        // 更新主面板血条
        GamePanel.Instance.UpdateHP(this.maxHp, this.hp);
    }
    public override void Dead()
    {
        // 不执行父类死亡 因为主摄像机是玩家子类 如果移除 间接移除主摄像机
        Time.timeScale = 0;
        LosePanel.Instance.Show();
    }
    public void ChangeWeapon(GameObject weapon)
    {
        // 删除当前武器
        if (nowWeapon != null)
        {
            Destroy(nowWeapon.gameObject);
            nowWeapon = null;
        }
        // 切换武器
        // 创建出武器 设置父对象 并保证缩放
        GameObject weaponObj = Instantiate(weapon, weaponPos, false);
        nowWeapon = weaponObj.GetComponent<WeaponObj>();
        // 设置武器拥有者
        nowWeapon.SetOwner(this);
    }
}
