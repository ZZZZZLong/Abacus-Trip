using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Setting : BasePanel
{
    LoadManager loadManager;
    public void OpenSettinge()
    {
        SoundManager.Instance.PlaySound(Globals.Click_2);
        EventCenter.Instance.EventTrigger("HideBtn");
        PlayerMove.ISMove = false;
        UIManager.Instance.OpenPanel(UIConst.Setting);
    }

    public void CloseSetting()
    {
        SoundManager.Instance.PlaySound(Globals.Click_2);
        PlayerMove.ISMove = true;
        UIManager.Instance.ClosePanel(UIConst.Setting);
    }

    public void BackStartPanel()
    {
        SoundManager.Instance.PlaySound(Globals.Click_2);
        loadManager = GameObject.Find("LoadManager").transform.GetComponent<LoadManager>();
        loadManager.BackPrevious();
    }
}
