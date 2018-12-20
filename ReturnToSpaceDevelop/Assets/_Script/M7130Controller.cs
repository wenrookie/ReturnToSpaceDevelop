using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// M7130控制类
/// </summary>
public class M7130Controller : MonoBehaviour
{
    
    ///// <summary>
    ///// 手臂上升位置
    ///// </summary>
    //[Header("手臂上升位置")]
    //public Transform HandUpTrans;
    ///// <summary>
    ///// 手臂下降位置
    ///// </summary>
    //[Header("手臂下降位置")]
    //public Transform HandDownTrans;
    ///// <summary>
    ///// 托盘左移位置
    ///// </summary>
    //[Header("托盘左移位置")]
    //public Transform TuopanLiftTrans;
    ///// <summary>
    ///// 托盘右移位置
    ///// </summary>
    //[Header("托盘右移位置")]
    //public Transform TuopanRightTrans;
    /// <summary>
    /// 手臂
    /// </summary>
    [Header("手臂")]
    public GameObject M7130Hand;
    /// <summary>
    /// 砂轮
    /// </summary>
    [Header("砂轮")]
    public GameObject M7130GrindingWheel;
    /// <summary>
    /// 托盘
    /// </summary>
    [Header("托盘")]
    public GameObject M7130Tuopan;
    /// <summary>
    /// 判断砂轮是否旋转
    /// </summary>
    bool isRotate = false;
    /// <summary>
    /// 托盘初始位置
    /// </summary>
    [Header("托盘初始位置")]
    public Transform tuopanStartTrans;
    /// <summary>
    /// 手臂初始位置
    /// </summary>
    [Header("手臂初始位置")]
    public Transform handStartTrans;
    
    private void Update()
    {
        
        float tuopanDistnce = Vector3.Distance(tuopanStartTrans.position, M7130Tuopan.transform.position);

        float handDistnce = Vector3.Distance(handStartTrans.position, M7130Hand.transform.position);

        float term1 = handStartTrans.position.y - M7130Hand.transform.position.y;

        float term2 =tuopanStartTrans.position.x - M7130Tuopan.transform.position.x;

        if (Input.GetKey(KeyCode.W)&& term1 > -0.4f)
        {
            //手臂上升
            //M7130Hand.transform.DOMove(HandUpTrans.transform.position, 1f);
            M7130Hand.transform.Translate(Vector3.forward * 2f * Time.deltaTime, Space.Self);
        }
        else
        if (Input.GetKey(KeyCode.S) && term1 < 0.4f)
        {
            //手臂下降
            //M7130Hand.transform.DOMove(HandDownTrans.transform.position, 1f);
            M7130Hand.transform.Translate(Vector3.forward * -2f * Time.deltaTime, Space.Self);
        }
        else
        if (Input.GetKey(KeyCode.A) && term2 > -0.8f)
        {
            //托盘左移
            //M7130Tuopan.transform.DOMove(TuopanLiftTrans.transform.position, 2f);
            M7130Tuopan.transform.Translate(Vector3.left * -2f * Time.deltaTime, Space.Self);
        }
        else
        if (Input.GetKey(KeyCode.D) && term2 < 0.8f)
        {
            //托盘右移
            //M7130Tuopan.transform.DOMove(TuopanRightTrans.transform.position, 1f);
            M7130Tuopan.transform.Translate(Vector3.left * 1f * Time.deltaTime, Space.Self);
        }
        else
        if (Input.GetKey(KeyCode.Z))
        {
            isRotate = true;
        }
        else
        if (Input.GetKeyDown(KeyCode.X))
        {
            isRotate = false;
        }
        if (isRotate)
        {
            M7130GrindingWheel.transform.Rotate(Vector3.forward * 2000f);
        }
    }
}