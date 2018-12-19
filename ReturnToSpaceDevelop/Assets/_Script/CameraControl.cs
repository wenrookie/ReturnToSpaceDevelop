using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 摄像机控制类
/// </summary>
public class CameraControl : MonoBehaviour
{
    /// <summary>
    /// 世界坐标系x轴与摄像机本地坐标系x周之间的夹角
    /// </summary>
    float angleofWordToLocalX;

    /// <summary>
    /// 世界坐标系y轴与摄像机本地坐标系y轴之间的夹角
    /// </summary>
    float angleofWordToLocalY;

    /// <summary>
    /// X轴方向移动的灵敏度
    /// </summary>
    public float sensitivity0fX = 5f;

    /// <summary>
    /// Y轴方向移动的灵敏度
    /// </summary>
    public float sensitivity0fY = 5f;

    /// <summary>
    /// 滑轮的灵敏度
    /// </summary>
    public float sensitivity0fScorllwheel = 5f;

    /// <summary>
    /// 摄像机的目标朝向
    /// </summary>
    Quaternion targeRotation;

    /// <summary>
    /// 摄像机旋转速度
    /// </summary>
    public float rotateSpeed = 10f;
    /// <summary>
    /// 摄像机的平移速度
    /// </summary>
    public float translateSpeed;

    /// <summary>
    /// 摄像机距离目标点
    /// </summary>
    float currentDistance;

    /// <summary>
    /// 摄像机距离目标点的目标距离
    /// </summary>
    float targetDistance;

    /// <summary>
    /// 摄像机观察的目标
    /// </summary>
    public Transform lookTargt;

    /// <summary>
    /// X最小限位角度
    /// </summary>
    public float minLimitAngleX = -360f;

    /// <summary>
    /// X最大限位角度
    /// </summary>
    public float maxLimitAngleX = 360f;

    /// <summary>
    /// Y最小限位角度
    /// </summary>
    public float minLimitAngleY = -360f;

    /// <summary>
    /// Y最大限位角度
    /// </summary>
    public float maxLimitAngleY = 360f;

    /// <summary>
    /// 摄像机距离观察点最小距离
    /// </summary>
    public float minLimitDistance = 2f;

    /// <summary>
    /// 摄像机距离观察点最大距离
    /// </summary>
    public float maxLimitDistance = 10f;

    private void Start()
    {
        //计算世界坐标系与摄像机本地坐标系的夹角
        angleofWordToLocalX = Vector3.Angle(Vector3.right, transform.right);
        angleofWordToLocalY = Vector3.Angle(Vector3.up, transform.up);
        //计算摄像机距离观察点的距离
        currentDistance = Vector3.Distance(lookTargt.position, transform.position);
        targetDistance = currentDistance;
    }
    private void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {

            //建立鼠标移动与夹角变化之间的映射关系
            angleofWordToLocalX += Input.GetAxis("Mouse X") * sensitivity0fX;
            angleofWordToLocalY -= Input.GetAxis("Mouse Y") * sensitivity0fY;
            //处理摄像机旋转角度的限位
            angleofWordToLocalX = Mathf.Clamp(angleofWordToLocalX, minLimitAngleX, maxLimitAngleX);
            angleofWordToLocalY = Mathf.Clamp(angleofWordToLocalY, minLimitAngleY, maxLimitAngleY);


            //计算目标朝向
            targeRotation = Quaternion.Euler(angleofWordToLocalY, angleofWordToLocalX, 0);
            //更新计算机的朝向
            transform.rotation = Quaternion.Lerp(transform.rotation, targeRotation, rotateSpeed * Time.deltaTime);
        }
        //建立鼠标滚轮与摄像机平移的映射关系
        targetDistance -= Input.GetAxis("Mouse ScrollWheel") * sensitivity0fScorllwheel;
        //处理摄像机与观察点距离的限位
        targetDistance = Mathf.Clamp(targetDistance, minLimitDistance, maxLimitDistance);
        currentDistance = Mathf.Lerp(currentDistance, targetDistance, translateSpeed);
        //更新摄像机的当前位置
        transform.position = lookTargt.position - (transform.forward * currentDistance);
        //第二种写法
        transform.position = lookTargt.position - transform.rotation * Vector3.forward * currentDistance;


    }
}
