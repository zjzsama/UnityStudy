using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson52Exercises : MonoBehaviour
{
    private Animator animator;
    public Transform headPos;
    private float x;
    private float y;
    private float dValue = 0.5f;
    // X方向鼠标旋转的角度
    private float changeRotationX;
    private float changeRotationY;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        #region 练习题
        // 通过2D混合树制作前进后退左右旋转的功能
        #endregion
    }
    private void ChangeValue()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            dValue = 1f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            dValue = 0.5f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        ChangeValue();
        animator.SetFloat("x", x * dValue);
        animator.SetFloat("y", y * dValue);

        // 角度累加
        changeRotationX -= Input.GetAxis("Mouse X");
        changeRotationX = Mathf.Clamp(changeRotationX, -30, 30);
        changeRotationY -= Input.GetAxis("Mouse Y");
        changeRotationY = Mathf.Clamp(changeRotationY, -30, 30);
        // print(Input.GetAxis("Mouse X"));
    }
    private void OnAnimatorIK(int layerIndex)
    {
        animator.SetLookAtWeight(1, 1, 1);
        Vector3 pos = Quaternion.AngleAxis(changeRotationX, Vector3.up) * (headPos.position + headPos.forward * 10);
        pos = Quaternion.AngleAxis(changeRotationY, Vector3.right) * pos;
        animator.SetLookAtPosition(pos);
    }
}
