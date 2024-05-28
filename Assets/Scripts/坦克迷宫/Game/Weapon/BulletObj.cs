using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    public float moveSpeed = 50f;
    // 谁发射的我
    public TankBaseObj fatherObj;
    public GameObject effectObj;
    public void SetFather(TankBaseObj fatherObj)
    {
        this.fatherObj = fatherObj;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && fatherObj.tag == "Player" || other.tag == "Cube" || other.tag == "Cube" || other.tag == "Player" && fatherObj.tag == "Enemy")
        {
            // 判断是否受伤
            // 得到碰撞到的对象身上 是否挂载有坦克相关脚本 里氏替换原则
            // 通过父类获取
            TankBaseObj obj = other.GetComponent<TankBaseObj>();
            if (obj != null)
            {
                // 我打另一个对象
                obj.Wound(fatherObj);
            }

            // 当子弹销毁时 创建爆炸特效
            if (effectObj != null)
            {
                // 创建爆炸特效
                GameObject eff = Instantiate(effectObj, this.transform.position, this.transform.rotation);
                // 改音效的状态
                AudioSource audioSource = eff.GetComponent<AudioSource>();
                audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;
                // 设置音效大小
                audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
                audioSource.Play();
                // 销毁子弹
                Destroy(this.gameObject);
                // 销毁特效
                Destroy(eff, 0.5f);
            }
        }

    }
}
