using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson20Exercise : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneMgr.Instance.LoadScene("Lesson20Test", () => { Debug.Log("场景切换完成"); });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
