using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjLesson24 : MonoBehaviour
{
    private Rigidbody2D rigidbody2;
    public float moveSpeed;
    private float x;

    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        rigidbody2.velocity = new Vector2(x * moveSpeed, rigidbody2.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2.AddForce(Vector2.up * 300);
        }

        // 人物面朝向改变
        if (x < 0)
        {
            sr.flipX = true;
        }
        else if (x > 0)
        {
            sr.flipX = false;
        }

    }
}
