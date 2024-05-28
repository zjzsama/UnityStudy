using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBaseObj : MonoBehaviour
{
    // 基础数据
    public int atk;
    public int def;
    public int maxHp;
    public int hp;
    // 所有坦克都有炮台
    public Transform tankHead;
    // 移动旋转速度相关
    public float moveSpeed = 10;
    public float roundSpeed = 10;
    public float headRotateSpeed = 10;

    public GameObject deadEffect;
    // 开火抽象方法 子类重写行为即可
    public abstract void Fire();

    // 我被别人攻击 我自己受伤
    public virtual void Wound(TankBaseObj other)
    {
        int dmg = other.atk - this.def;
        if (dmg < 0) return;
        // 伤害大于0 扣血
        this.hp -= dmg;
        // 血量<=0 死亡
        if (this.hp <= 0)
        {
            this.hp = 0;
            this.Dead();
        }
    }
    public virtual void Dead()
    {
        // 死亡的时候 可能所有坦克对象 都会播放相应的特效
        if (deadEffect != null)
        {
            GameObject effObj = Instantiate(deadEffect, this.transform.position, this.transform.rotation);
            // 由于该特性身上关联了音效 所以我们可以在此处把音效也一并控制
            AudioSource audioSource = effObj.GetComponent<AudioSource>();
            // 根据音乐数据设置音量大小和是否播放
            audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
            //音效是否播放
            audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            // 避免没勾选Play on Awake
            audioSource.Play();
        }
        // 对象死亡 在场景上移除该对象
        Destroy(this.gameObject);
    }
}
