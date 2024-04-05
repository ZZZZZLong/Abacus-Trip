using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    //重新加载此场景
    public void OnBtnClick()
    {
        Debug.Log("启动");
        EventCenter.Instance.EventTrigger("ReStart");
    }
}
