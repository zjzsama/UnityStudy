using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicData
{
    private static MusicData instance;

    public static MusicData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MusicData();
            }
            return instance;
        }
    }
    //音效开关
    public bool SoundIsOpen = true;
    //音效大小
    public float soundValue = 1f;
}
