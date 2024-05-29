using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson49Exercises : MonoBehaviour
{
    private Animator animator;

    public float rotateSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //控制角色移动
        animator.SetInteger("Speed", (int)Input.GetAxisRaw("Vertical"));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Jump", true);
        }
        this.transform.Rotate(Vector3.up, Input.GetAxisRaw("Horizontal") * rotateSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("Fall");
        }
        // 按K键切换动画层级权重
        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetLayerWeight(animator.GetLayerIndex("New Layer 0"), 1);
        }
    }

    public void JumpOver()
    {
        animator.SetBool("Jump", false);
    }
}
