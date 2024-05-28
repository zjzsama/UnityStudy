using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObj : TankBaseObj
{

    // 1.要让坦克在两个点来回移动
    // 当前目标点
    private Transform targerPos;
    // 随机用的点 外部关联
    public Transform[] randomPos;
    // 2.坦克要一直盯着自己的目标
    public Transform lookAtTarget;
    // 3.当目标达到一定范围内过后 间隔时间攻击一下目标
    public float fireDis = 5; // 当小于这个距离时就会瞄准攻击
    public float fireTimer = 1; // 攻击间隔时间
    private float fireTime = 0; // 攻击间隔时间计时器

    // 开火点
    public Transform[] shootPos;
    // 子弹预设体
    public GameObject bulletObj;
    // 两张血条的图 外部关联
    public Texture maxHpBK;
    public Texture hpBK;
    private Rect maxHpRect = new Rect();
    private Rect hpRect = new Rect();
    public float showTime = 0; // 显示血条的时间
    // 随机生成一个点
    void Start()
    {
        RandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        #region 多个点之间的随机移动
        // 看向自己的目标点
        this.transform.LookAt(targerPos);
        // 不停地向自己面朝向位移
        this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);

        // 知识点 Vector3.Distance 两个点之间的距离
        // 当距离过小时判断已经到了 去下一个点
        if (Vector3.Distance(this.transform.position, targerPos.position) < 0.05f)
        {
            RandomPos();
        }
        #endregion

        #region 看向自己的目标
        if (lookAtTarget != null)
        {
            tankHead.transform.LookAt(lookAtTarget);
            if (Vector3.Distance(this.transform.position, lookAtTarget.position) <= fireDis)
            {
                fireTime += Time.deltaTime;
                if (fireTime >= fireTimer)
                {
                    fireTime = 0;
                    Fire();
                }
            }
        }
        #endregion

    }
    private void RandomPos()
    {
        if (randomPos.Length == 0)
        {
            return;
        }
        targerPos = randomPos[Random.Range(0, randomPos.Length)];
    }
    public override void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bulletObj, shootPos[i].position, shootPos[i].rotation);
            // 设置子弹拥有者 用于伤害计算
            BulletObj bullet = obj.GetComponent<BulletObj>();
            bullet.SetFather(this);
        }
    }
    public override void Dead()
    {
        base.Dead();
        // 怪物死亡时加分
        GamePanel.Instance.AddScore(10);
    }
    // 进行血条UI设置
    private void OnGUI()
    {
        if (showTime > 0)
        {
            showTime -= Time.deltaTime;
            // 画图 画血条
            // 1.把怪物当前位置 转换成屏幕位置
            // 摄像机里面提供了API 可以将 世界坐标 转换成 屏幕坐标
            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            // 2.屏幕位置转换成 GUI位置
            // 知识点 如何得到当前分辨率屏幕的高
            screenPos.y = Screen.height - screenPos.y;
            // 然后再绘制
            // 知识点 GUI图片绘制
            // 底图
            maxHpRect.x = screenPos.x - 50;
            maxHpRect.y = screenPos.y - 50;
            maxHpRect.height = 15;
            maxHpRect.width = 100;
            GUI.DrawTexture(maxHpRect, maxHpBK);

            hpRect.x = screenPos.x - 50;
            hpRect.y = screenPos.y - 50;
            hpRect.height = 15;
            // 根据血量和最大血量百分比决定画多宽
            hpRect.width = (float)hp / maxHp * 100f;
            GUI.DrawTexture(hpRect, hpBK);
        }

    }
    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        showTime = 3;
    }
}
