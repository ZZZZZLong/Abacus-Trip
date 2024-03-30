using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secen3Trigger : MonoBehaviour
{
    bool isCanEnter;

    private void Start()
    {
        isCanEnter = false;
        EventCenter.Instance.AddEventListener("isEnter", CanEnter);
    }

    void Update()
    {
        isCanEnter = GameManager.Instance.isCanEnter;
        
    }

    void CanEnter()
    {
        if (isCanEnter)
        {
            //显示进入UI
        }
        else
        {
            //显示条件UI
        }
    }
}
