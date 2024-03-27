using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Setting : BasePanel
{
    LoadManager loadManager;
    public void OpenSettinge()
    {
        EventCenter.Instance.EventTrigger("HideBtn");
        PlayerMove.ISMove = false;
        UIManager.Instance.OpenPanel(UIConst.Setting);
    }

    public void CloseSetting()
    {
        PlayerMove.ISMove = true;
        UIManager.Instance.ClosePanel(UIConst.Setting);
    }

    public void BackStartPanel()
    {
        loadManager = GameObject.Find("LoadManager").transform.GetComponent<LoadManager>();
        loadManager.BackPrevious();
    }
}
