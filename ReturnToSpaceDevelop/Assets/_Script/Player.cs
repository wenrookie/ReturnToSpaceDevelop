using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// 人物控制类
/// </summary>
public class Player : MonoBehaviour
{
    /// <summary>
    /// 速度
    /// </summary>
    public int speed = 1;
    /// <summary>
    /// 人物
    /// </summary>
    [Header("人物")]
    public GameObject people;

    Transform selfTrans;

    private void Update()
    {
        selfTrans = people.transform;
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                if (hit.collider.tag != "Plane")
                    return;
                Vector3 targetPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                
                float distance = Vector3.Distance(transform.position, targetPos);
                float time = distance / speed;
                
                transform.DOMove(targetPos, 1 * time);
                
            }
        }
    }

    
}