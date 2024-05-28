using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson17 : MonoBehaviour
{
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 刚体自带添加力的方法
        //给刚体加力的目标就是
        //让其有一个速度 朝某个方向移动

        //1.首先应该获取刚体组件
        rigidbody = this.GetComponent<Rigidbody>();

        //2.添加力
        //相对世界坐标
        //在Z轴加了一个力
        //加力过后 对象是否停止移动 是由阻力决定的
        //如果阻力始终为0 那给了一个力后 始终不会停止运动
        // rigidbody.AddForce(Vector3.forward * 10f);

        //如果想要在世界坐标系中 让对象 相对于自己的面朝向动
        // rigidbody.AddForce(this.transform.forward * 10f);

        //相对本地坐标
        // rigidbody.AddRelativeForce(Vector3.forward * 10f);

        //3.添加扭矩力,让物体旋转
        //相对世界坐标系
        // rigidbody.AddTorque(Vector3.up * 10f); //绕Y轴旋转
        //相对本地坐标
        // rigidbody.AddRelativeTorque(Vector3.up * 10f); //绕自己的Y轴旋转

        //4.直接改变速度
        //这个速度方向 相对于 世界坐标系的
        //如果要直接通过改变速度来让其移动 要注意这一点
        // rigidbody.velocity = Vector3.forward * 10f;

        //5.模拟爆炸效果
        rigidbody.AddExplosionForce(100f, this.transform.position, 10f); //只影响挂载脚本的对象
        #endregion 
        #region 知识点二 力的几种模式
        //由于四种计算方式不同 所以最终的速度不同
        //根据动量定理计算 Ft=mv v=Ft/m
        rigidbody.AddForce(Vector3.forward * 10f, ForceMode.Acceleration); //加速模式 提供一个持续加速度 忽略质量
        rigidbody.AddForce(Vector3.forward * 10f, ForceMode.Force); //力模式 提供一个持续的力 计算质量
        rigidbody.AddForce(Vector3.forward * 10f, ForceMode.Impulse); //冲量模式 提供一个瞬间力 忽略时间
        rigidbody.AddForce(Vector3.forward * 10f, ForceMode.VelocityChange); //速度模式 提供一个瞬时速度 忽略质量和时间
        #endregion

        #region 知识点三 力场脚本
        //constForce
        #endregion


    }

    // Update is called once per frame
    void Update()
    {
        #region 补充 刚体的休眠
        //判断是否休眠 如果是 就唤醒
        if (rigidbody.IsSleeping())
        {
            rigidbody.WakeUp();
        }
        #endregion
    }
}
