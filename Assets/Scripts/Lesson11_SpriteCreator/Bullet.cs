using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed;

    private Vector3 nowDir;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 2f);
    }

    public void ChangeMoveDir(Vector3 dir)
    {
        nowDir = dir;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(moveSpeed * Time.deltaTime * nowDir);
    }
}
