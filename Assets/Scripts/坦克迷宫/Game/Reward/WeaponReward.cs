using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReward : MonoBehaviour
{
    public GameObject[] weaponObj;
    public GameObject getEff;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 让玩家切换武器
            int index = Random.Range(0, weaponObj.Length);
            other.GetComponent<PlayerObj>().ChangeWeapon(weaponObj[index]);
            // 获取特效
            GameObject eff = Instantiate(getEff, transform.position, this.transform.rotation);

            // 控制音效
            AudioSource audioSource = eff.GetComponent<AudioSource>();
            audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
            audioSource.Play();

            // 销毁特效
            Destroy(eff, 1f);
            // 获取到后移除
            Destroy(this.gameObject);
        }
    }
}
