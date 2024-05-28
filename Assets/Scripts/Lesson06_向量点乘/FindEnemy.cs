using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FindEnemy : MonoBehaviour
{
    public Transform B;
    // Start is called before the first frame update
    void Start()
    {
        // 当一个物体B在物体A前方45度角范围内,并且A只有5米远时,在控制台打印"发现入侵者"
    }

    // Update is called once per frame
    void Update()
    {
        // if (Vector3.Distance(this.transform.position, B.position) <= 5 && Vector3.Angle(this.transform.forward, this.transform.position - B.position) <= 22.5f)
        // {
        //     print("发现入侵者");
        // }

        if (Vector3.Distance(this.transform.position, B.position) <= 5)
        {
            // 1.算出点乘结果(方向向量)
            float dotResult = Vector3.Dot(this.transform.forward, (B.position - this.transform.position).normalized);
            // 2.通过反三角函数算出角度
            if (Mathf.Acos(dotResult) * Mathf.Rad2Deg <= 22.5f)
            {
                print("发现入侵者");
            }
        }
    }
}
