using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson7Exercises : MonoBehaviour
{
    public Transform B;
    // Start is called before the first frame update
    void Start()
    {
        #region 1
        // 判断一个物体B在另一个物体A的左上,左下,右上,右下哪个方向
        #endregion

        #region 2
        // 当一个物体B在物体A左前方20度或右前方30度范围内,并且距离A只有5m的距离在控制台打印"发现入侵者"
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

        // 1
        // 点乘判断前后 负数代表钝角(后)
        if (Vector3.Dot(this.transform.forward, B.position - this.transform.position) > 0 && Vector3.Cross(this.transform.position, B.position).y < 0)
        {
            print("B在A的左前方");
        }
        else if (Vector3.Dot(this.transform.forward, B.position - this.transform.position) > 0 && Vector3.Cross(this.transform.position, B.position).y > 0)
        {
            print("B在A的右前方");
        }
        else if (Vector3.Dot(this.transform.forward, B.position - this.transform.position) < 0 && Vector3.Cross(this.transform.position, B.position).y < 0)
        {
            print("B在A的左后方");
        }
        else if (Vector3.Dot(this.transform.forward, B.position - this.transform.position) < 0 && Vector3.Cross(this.transform.position, B.position).y > 0)
        {
            print("B在A的右后方");
        }
        // 2
        if ((Vector3.Distance(this.transform.position, B.position) <= 5 && (Vector3.Angle(this.transform.forward, B.position - this.transform.position) <= 20 && Vector3.Cross(this.transform.position, B.position).y < 0)) || (Vector3.Distance(this.transform.position, B.position) <= 5 && (Vector3.Angle(this.transform.forward, B.position - this.transform.position) >= 30 && Vector3.Cross(this.transform.position, B.position).y < 0)))
        {
            Debug.Log("发现入侵者");
        }
    }
}
