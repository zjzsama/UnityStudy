using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson18Test : MonoBehaviour
{
    private Texture tex;


    void Start()
    {
        ResourcesMgr.Instance.LoadRes<Texture>("Tex/Test", (obj) =>
        {
            tex = obj;
        }
        );
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnGUI()
    {
        if (tex != null)
        {
            GUI.DrawTexture(new Rect(0, 0, 100, 100), tex);
        }
    }
}
