using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public CinemachineVirtualCamera FollowMouseVcam;

    private CinemachineFramingTransposer cinemachineFraming;
    public float Speed = 5f;
    public float targetScreenX_min = 0.1f; // 目标 ScreenX 值
    public float targetScreenX_max = 0.5f;
    public float decreaseSpeed = 0.05f; // 减少速度
    public bool Direction;


    private void Awake()
    {
        cinemachineFraming = FollowMouseVcam.GetCinemachineComponent<CinemachineFramingTransposer>();
        Direction = true;
    }

    void Update()
    {
        if(Direction)
        {
            GoRight();//在激活后右移动
        }
        else if (Direction == false)
        {
            GoLeft();//切换后向左移动
        }
    }

    void GoRight()
    {
        // 检查当前 ScreenX 值是否大于目标值
        if (cinemachineFraming.m_ScreenX > targetScreenX_min)
        {
            // 使用 Mathf.MoveTowards 逐渐减少 ScreenX 值
            float newScreenX = Mathf.MoveTowards(cinemachineFraming.m_ScreenX, targetScreenX_min, decreaseSpeed * Time.deltaTime);

            // 设置新的 ScreenX 值
            cinemachineFraming.m_ScreenX = newScreenX;
        }
    }

    void GoLeft()
    {
        // 检查当前 ScreenX 值是否大于目标值
        if (cinemachineFraming.m_ScreenX < targetScreenX_max)
        {
            // 使用 Mathf.MoveTowards 逐渐增加 ScreenX 值
            float newScreenX = Mathf.MoveTowards(targetScreenX_max, cinemachineFraming.m_ScreenX, decreaseSpeed * Time.deltaTime);

            // 设置新的 ScreenX 值
            cinemachineFraming.m_ScreenX = newScreenX;
        }
        else if (cinemachineFraming.m_ScreenX == targetScreenX_max)
        {
            Destroy(gameObject);//在返回初始位置后销毁物体
        }
    }
}
