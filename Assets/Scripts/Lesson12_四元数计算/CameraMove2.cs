using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove2 : MonoBehaviour
{
    public Transform target;
    // 相对头顶的偏移位置
    public float headOffset = 1;
    // 倾斜角度
    public float angle = 45;
    public float lookSpeed;
    // 摄像机离观测点距离
    public float dis = 5;
    // 距离在minDis和maxDis之间
    public float minDis = 3;
    public float maxDis = 10;
    // 当前摄像机所在位置
    private Vector3 nowPos;
    void Start()
    {
        // 二.用所学三维数学知识实现摄像机跟随效果
        // 1.摄像机在人物斜后方，通过角度控制倾斜率
        // 2.(通过鼠标滚轮可以控制摄像机距离人物的距离(有最大最小限制)
        // 3.(摄像机看向人物头顶上方一个位置(可调节)
        // 4.Vector3.Lerp实现相机跟随人物
        // 5.Quaterino.Slerp实现摄像机看向人物

    }

    private Vector3 nowDir;
    void Update()
    {
        //鼠标中键滚动改变距离
        dis += Input.GetAxis("Mouse ScrollWheel");
        dis = Mathf.Clamp(dis, minDis, maxDis);
        // 向头顶偏移位置
        nowPos = target.position + target.up * headOffset;
        // 往后方偏移位置
        nowDir = Quaternion.AngleAxis(angle, target.right) * -target.forward;
        nowPos = nowPos + nowDir * dis;
        this.transform.position = Vector3.Lerp(this.transform.position, nowPos, Time.deltaTime);
        Debug.DrawLine(nowPos, target.position, Color.red);

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(-nowDir), Time.deltaTime * lookSpeed);
    }
}
