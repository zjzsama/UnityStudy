using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson51Exercises : MonoBehaviour
{
    private Animator animator;

    private float y;

    private float dValue = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        #region 练习题

        // 在之前练习题的基础上 通过1D混合树制作前进后退的功能
        animator = GetComponent<Animator>();
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

    private void Move()
    {
        y = Input.GetAxis("Vertical");
        animator.SetFloat("Speed", y * dValue);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        // print(y);
        ChangeValue();
        Jump();
    }
}
