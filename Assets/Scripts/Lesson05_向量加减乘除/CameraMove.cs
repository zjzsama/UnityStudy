using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float zOffset = 4;
    public float yOffset = 7;
    public Transform cubePos;
    private Vector3 Pos;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        // 摄像机的位置在物体后方4米,向上7米

        // Pos.x = cubePos.position.x;
        // Pos.y = cubePos.position.y + 7;
        // Pos.z = cubePos.position.z - 4;
        // this.transform.position = Pos;
        this.transform.position = cubePos.position + -cubePos.forward * zOffset + cubePos.up * yOffset;
        this.transform.LookAt(cubePos);

        // Lesson11Exercise
        this.transform.MyLookAt(cubePos);

    }


}
