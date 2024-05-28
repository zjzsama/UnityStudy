using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson15Exercises : MonoBehaviour
{
    public Light light;
    public float moveSpeed;
    public float flashSpeed;
    public Transform lightTransform;
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        #region 练习题一
        //1.通过代码结合点光源
        //模拟一个蜡烛灯光效果
        //来回横跳
        light.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        if (light.transform.position.x > 1.0f)
        {
            moveSpeed = -moveSpeed;
        }
        else if (light.transform.position.x < 0.8f)
        {
            moveSpeed = -moveSpeed;
        }
        //闪一闪
        light.intensity += flashSpeed * Time.deltaTime;
        if (light.intensity >= 1.0f || light.intensity <= 0.5f)
        {
            flashSpeed = -flashSpeed;
        }
        #endregion

        #region 练习题二
        //2.通过代码结合方向光
        //模拟白天黑夜的变化
        lightTransform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
        #endregion
    }
}
