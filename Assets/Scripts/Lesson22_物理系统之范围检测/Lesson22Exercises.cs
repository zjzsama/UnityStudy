using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson22Exercises : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        #region 练习题一
        // 世界坐标原点有一个立方体 键盘WASD键可以控制其前后移动和旋转
        // 请结合所学知识实现
        // 1.按J键在立方体面朝向前方1m处进行立方体范围检测
        // 2.按K键在立方体前面5m范围内进行胶囊范围检测
        // 3.按L键一立方体脚下为原点,半径10m内进行球形范围检测
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        // 位移
        this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * y);
        // 旋转
        this.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * x);

        if (Input.GetKeyDown(KeyCode.J))
        {
            Collider[] colliders = Physics.OverlapBox(this.transform.position + this.gameObject.transform.forward * 1, Vector3.one, this.transform.rotation, 1 << LayerMask.NameToLayer("Enemy"));
            foreach (var item in colliders)
            {
                print("物体受伤" + item.name);
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Collider[] colliders = Physics.OverlapCapsule(this.transform.position, this.transform.position + this.gameObject.transform.forward * 5, 0.5f, 1 << LayerMask.NameToLayer("Enemy"));
            foreach (var item in colliders)
            {
                print("物体受伤" + item.name);
            }
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Collider[] colliders = Physics.OverlapSphere(this.transform.position, 10f, 1 << LayerMask.NameToLayer("Enemy"));
            foreach (var item in colliders)
            {
                print("物体受伤" + item.name);
            }
        }
    }
}
