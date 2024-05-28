using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson8Exercise : MonoBehaviour
{
    public Transform target;
    private Vector3 targetPos;
    private Vector3 nowPos;
    public float zOffset = 4f;
    public float yOffset = 7f;
    public float moveSpeed = 1f;
    public float time = 0;
    private Quaternion targetQ;
    private Quaternion nowQ;
    public float roundSpeed = 10;
    private float roundTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = target.position;
        nowPos = this.transform.position;
        nowQ = this.transform.rotation;
    }

    private void LateUpdate()
    {
        // 摄像机的位置在物体后方4米,向上7米,用线性插值

        // 先快后慢的移动
        // if (targetPos != target.position + -target.forward * zOffset + target.up * yOffset)
        // {
        //     targetPos = target.position + -target.forward * zOffset + target.up * yOffset;
        // }
        // this.transform.position = Vector3.Lerp(this.transform.position, targetPos, Time.deltaTime);

        // 匀速移动
        time += Time.deltaTime;
        if (targetPos != target.position + -target.forward * zOffset + target.up * yOffset)
        {
            targetPos = target.position + -target.forward * zOffset + target.up * yOffset;
            nowPos = this.transform.position;
            time = 0;
        }

        this.transform.position = Vector3.Lerp(nowPos, targetPos, time * moveSpeed);
        // this.transform.LookAt(target);

        // Lesson11Exercise
        targetQ = Quaternion.LookRotation(target.position - this.transform.position);
        // 先快后慢
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetQ, Time.deltaTime * roundSpeed);
        // 匀速移动
        if (targetQ != Quaternion.LookRotation(target.position - this.transform.position))
        {
            targetQ = Quaternion.LookRotation(target.position - this.transform.position);
            nowQ = this.transform.rotation;
            roundTime = 0;
        }
        roundTime += Time.deltaTime;
        this.transform.rotation = Quaternion.Slerp(nowQ, targetQ, roundTime * roundSpeed);
    }
}
