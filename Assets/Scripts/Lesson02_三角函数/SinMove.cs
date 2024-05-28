using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMove : MonoBehaviour
{
    public float moveSpeed = 5; //面朝向移动速度
    public float sinSpeed = 1;//正弦函数的频率
    public float sinAmplitude = 0.5f;//正弦函数的振幅
    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 面朝向移动
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        // 左右曲线移动
        time += Time.deltaTime * sinSpeed;
        this.transform.Translate(Vector3.right * Mathf.Sin(time) * sinAmplitude * Time.deltaTime);
    }
}
