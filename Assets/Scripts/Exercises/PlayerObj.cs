using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerObj : MonoBehaviour
{
    public Transform firePos;
    public AudioClip fireClip;

    public float moveSpeed = 10f;
    public float rotateSpeed;
    private Vector3 nowMoveDir = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {

    }
    /// <summary>
    /// 开火方法
    /// </summary>
    public void Fire()
    {
        // 播放音效
        if (MusicData.Instance.SoundIsOpen)
        {
            AudioSource audioSource = this.gameObject.AddComponent<AudioSource>();
            audioSource.clip = fireClip;
            audioSource.Play();
            // 改变音效大小
            audioSource.volume = MusicData.Instance.soundValue;
            Destroy(audioSource, 0.8f);
        }

        // 动态创建子弹
        Instantiate(Resources.Load<GameObject>("Bullet"), firePos.position, Quaternion.identity);
    }

    public void Move(Vector2 dir)
    {
        nowMoveDir.x = dir.x;
        nowMoveDir.y = 0;
        nowMoveDir.z = dir.y;
    }
    // Update is called once per frame
    void Update()
    {
        if (nowMoveDir != Vector3.zero)
        {
            // 朝目标方向移动
            this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            // 不停地朝目标方向 转向
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(nowMoveDir), rotateSpeed * Time.deltaTime);

        }
    }
}
