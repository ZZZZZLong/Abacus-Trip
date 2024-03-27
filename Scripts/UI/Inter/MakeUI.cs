using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeUI : BasePanel
{
    public void OpenMakeUI()
    {
        EventCenter.Instance.EventTrigger("HideBtn");
        PlayerMove.ISMove = false;
        UIManager.Instance.OpenPanel(UIConst.MakeUI);
    }

    public void CloseMakeUI()
    {

        PlayerMove.ISMove = true;
        UIManager.Instance.ClosePanel(UIConst.MakeUI);
    }
}
