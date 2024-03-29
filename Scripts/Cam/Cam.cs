using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public CinemachineVirtualCamera FollowMouseVcam;

    private CinemachineFramingTransposer cinemachineFraming;
    public float Speed = 5f;
    public float targetScreenX_min = 0.1f; // Ŀ�� ScreenX ֵ
    public float targetScreenX_max = 0.5f;
    public float decreaseSpeed = 0.05f; // �����ٶ�
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
            GoRight();//�ڼ�������ƶ�
        }
        else if (Direction == false)
        {
            GoLeft();//�л��������ƶ�
        }
    }

    void GoRight()
    {
        // ��鵱ǰ ScreenX ֵ�Ƿ����Ŀ��ֵ
        if (cinemachineFraming.m_ScreenX > targetScreenX_min)
        {
            // ʹ�� Mathf.MoveTowards �𽥼��� ScreenX ֵ
            float newScreenX = Mathf.MoveTowards(cinemachineFraming.m_ScreenX, targetScreenX_min, decreaseSpeed * Time.deltaTime);

            // �����µ� ScreenX ֵ
            cinemachineFraming.m_ScreenX = newScreenX;
        }
    }

    void GoLeft()
    {
        // ��鵱ǰ ScreenX ֵ�Ƿ����Ŀ��ֵ
        if (cinemachineFraming.m_ScreenX < targetScreenX_max)
        {
            // ʹ�� Mathf.MoveTowards ������ ScreenX ֵ
            float newScreenX = Mathf.MoveTowards(targetScreenX_max, cinemachineFraming.m_ScreenX, decreaseSpeed * Time.deltaTime);

            // �����µ� ScreenX ֵ
            cinemachineFraming.m_ScreenX = newScreenX;
        }
        else if (cinemachineFraming.m_ScreenX == targetScreenX_max)
        {
            Destroy(gameObject);//�ڷ��س�ʼλ�ú���������
        }
    }
}
