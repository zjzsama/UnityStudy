using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    public float moveSpeed;
    private SpriteRenderer sr;
    private float x;

    private Rigidbody2D rigidbody2d;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");

        animator.SetInteger("xSpeed", (int)x);
        animator.SetInteger("ySpeed", Mathf.CeilToInt(rigidbody2d.velocity.y));
        // this.transform.Translate(moveSpeed * Time.deltaTime * Vector3.right * x);

        if (x != 0)
        {
            // 由于重力会给予对象 y方向的值 所以我们左右移动 应该只是改变左右速度 y的速度保留原有的值
            rigidbody2d.velocity = new Vector2(x * moveSpeed, rigidbody2d.velocity.y);
        }

        if (x < 0)
        {
            sr.flipX = true;
        }
        else if (x > 0)
        {
            sr.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            GameObject obj = (GameObject)Instantiate(Resources.Load("BulletObj"), this.transform.position + new Vector3(sr.flipX ? -0.3f : 0.3f, 0.5f, 0), Quaternion.identity);
            obj.GetComponent<Bullet>().ChangeMoveDir(sr.flipX ? Vector3.left : Vector3.right);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2d.AddForce(Vector2.up * 300);
        }
    }
}
