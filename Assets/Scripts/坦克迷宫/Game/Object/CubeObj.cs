using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObj : MonoBehaviour
{
    public GameObject[] rewardObjs;
    public GameObject deadEff;
    private void OnTriggerEnter(Collider other)
    {
        // 1.打到自己 子弹应该销毁
        //不用在这里写 前面在子弹脚本已经处理好了
        // 2.打到自己 处理随机奖励逻辑
        // 随机数 来获取奖励
        int rangeInt = Random.Range(0, 100);
        if (rangeInt < 50)
        {
            // 随机创建一个 奖励预设体
            rangeInt = Random.Range(0, rewardObjs.Length);
            // 放到当前箱子在的位置就可以
            Instantiate(rewardObjs[rangeInt], transform.position, Quaternion.identity);
        }
        GameObject eff = Instantiate(deadEff, transform.position, Quaternion.identity);
        AudioSource audioSource = eff.gameObject.GetComponent<AudioSource>();
        audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;
        audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
        audioSource.Play();
        Destroy(eff, 1f);

        Destroy(this.gameObject);
    }
}
