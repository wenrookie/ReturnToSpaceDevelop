using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Z3050Controller : MonoBehaviour
{
    /// <summary>
    /// 机械臂
    /// </summary>
    [Header("机械臂")]
    public GameObject z3050Arm;
    /// <summary>
    /// 机械爪
    /// </summary>
    [Header("机械爪")]
    public GameObject z3050Claw;
    /// <summary>
    /// 机械臂位置限制
    /// </summary>
    [Header("机械臂位置限制")]
    public Transform armTrans;
    /// <summary>
    /// 机械爪位置限制
    /// </summary>
    [Header("机械爪位置限制")]
    public Transform clawTrans;

    float armDistance;

    float clawDistance;
    /// <summary>
    /// 距离上限
    /// </summary>
    [Header("距离上限")]
    public float upDis = 1f;
    /// <summary>
    /// 距离下限
    /// </summary>
    [Header("距离下限")]
    public float downDis =1f;
    /// <summary>
    /// 距离左限
    /// </summary>
    [Header("距离左限")]
    public float leftDis = 1f;
    /// <summary>
    /// 距离右限
    /// </summary>
    [Header("距离右限")]
    public float rightDis = 1f;
    
    private void Update()
    {
        armDistance = z3050Arm.transform.position.y - armTrans.position.y;
        clawDistance = z3050Claw.transform.position.x - clawTrans.position.x;
        if (Input.GetKey(KeyCode.F) && clawDistance < leftDis)//
        {
            z3050Claw.transform.Translate(Vector3.left * -5f * Time.deltaTime,Space.Self);
        }
        else 
        if(Input.GetKey(KeyCode.H) && clawDistance > rightDis)//
        {
            z3050Claw.transform.Translate(Vector3.left * 5f * Time.deltaTime, Space.Self);
        }
        else
        if (Input.GetKey(KeyCode.T)&& armDistance < upDis)
        {
            z3050Arm.transform.Translate(Vector3.forward * 5f * Time.deltaTime, Space.Self);
        }
        else
        if (Input.GetKey(KeyCode.G) && armDistance > downDis)//
        {
            z3050Arm.transform.Translate(Vector3.forward * -5f * Time.deltaTime, Space.Self);
        }
    }
}