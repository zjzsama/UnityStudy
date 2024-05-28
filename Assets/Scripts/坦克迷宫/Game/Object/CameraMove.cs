using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform targetPos;
    private Vector3 pos;
    public float height = 10f;
    private void LateUpdate()
    {
        if (targetPos == null)
        {
            return;
        }
        // x和z与玩家一致
        pos.x = targetPos.position.x;
        pos.z = targetPos.position.z;
        // 通过外部调整 摄像机高度
        pos.y = height;
        this.transform.position = pos;
    }
}
