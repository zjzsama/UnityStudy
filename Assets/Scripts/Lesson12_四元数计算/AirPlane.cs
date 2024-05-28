using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum E_FireType
{

    One, //单发
    Two,//双发
    Three,//扇形
    Round,//环形
}
public class AirPlane : MonoBehaviour
{
    public E_FireType nowType = E_FireType.One;
    public int roundNum = 4;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        bullet = Resources.Load<GameObject>("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            nowType = E_FireType.One;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            nowType = E_FireType.Two;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            nowType = E_FireType.Three;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            nowType = E_FireType.Round;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire(GetNowType());
        }
    }

    public E_FireType GetNowType()
    {
        return nowType;
    }

    public void Fire(E_FireType nowType)
    {

        switch (nowType)
        {
            case E_FireType.One:
                GameObject bulletObj = Instantiate(bullet, transform.position, transform.rotation);
                break;
            case E_FireType.Two:
                Instantiate(bullet, this.transform.position - this.transform.right * 0.5f, transform.rotation);
                Instantiate(bullet, this.transform.position + this.transform.right * 0.5f, transform.rotation);
                break;
            case E_FireType.Three:
                //朝自己的面朝向发射
                Instantiate(bullet, this.transform.position, transform.rotation);
                //左侧偏移20度
                Instantiate(bullet, this.transform.position, transform.rotation * Quaternion.AngleAxis(-20, Vector3.up));
                //右侧偏移20度
                Instantiate(bullet, this.transform.position, transform.rotation * Quaternion.AngleAxis(20, Vector3.up)); ;
                break;
            case E_FireType.Round:
                float angle = 360 / roundNum;
                for (int i = 0; i < roundNum; i++)
                {
                    Instantiate(bullet, this.transform.position, transform.rotation * Quaternion.AngleAxis(angle * i, Vector3.up));
                }
                break;
            default:
                break;
        }
    }
}
