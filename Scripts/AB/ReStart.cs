using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    //���¼��ش˳���
    public void OnBtnClick()
    {
        Debug.Log("����");
        EventCenter.Instance.EventTrigger("ReStart");
    }
}
