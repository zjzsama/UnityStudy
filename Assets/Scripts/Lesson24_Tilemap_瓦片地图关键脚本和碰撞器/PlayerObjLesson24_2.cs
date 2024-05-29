using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjLesson24_2 : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Rigidbody2D rigidbody2;
    private SpriteRenderer sr;

    private float x;
    private float y;
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
        y = Input.GetAxis("Vertical");
        // 水平方向的移动
        this.transform.Translate(Vector3.right * moveSpeed * x * Time.deltaTime);
        this.transform.Translate(Vector3.up * moveSpeed * y * Time.deltaTime);
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
