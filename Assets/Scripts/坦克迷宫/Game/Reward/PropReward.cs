using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum E_PropType
{
    // 加属性的类型
    Atk, Def, MaxHP, HP,
}
public class PropReward : MonoBehaviour
{
    public E_PropType e_PropType = E_PropType.Atk;
    public int changeAtk = 2;
    public int changeDef = 2;
    public int changeHP = 2;
    public int changeMaxHP = 2;
    // 获取特效
    public GameObject getEff;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 得到对应的玩家脚本
            PlayerObj player = other.GetComponent<PlayerObj>();
            switch (e_PropType)
            {
                case E_PropType.Atk:
                    player.atk += changeAtk;
                    break;
                case E_PropType.Def:
                    player.def += changeDef;
                    break;
                case E_PropType.MaxHP:
                    player.maxHp += changeMaxHP;
                    // 更新血条
                    GamePanel.Instance.UpdateHP(player.maxHp, player.hp);
                    break;
                case E_PropType.HP:
                    player.hp += changeHP;
                    // 更新血条
                    GamePanel.Instance.UpdateHP(player.maxHp, player.hp);
                    // 不能超过上限
                    if (player.hp > player.maxHp)
                    {
                        player.hp = player.maxHp;
                    }
                    break;
                default:
                    break;
            }
            GameObject eff = Instantiate(getEff, transform.position, Quaternion.identity);
            AudioSource audioSource = eff.GetComponent<AudioSource>();
            audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
            audioSource.Play();

            // 销毁道具
            Destroy(eff, 1f);
            Destroy(this.gameObject);
        }

    }
}
