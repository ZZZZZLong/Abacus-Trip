using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeUI : BasePanel
{
    public void OpenMakeUI()
    {
        SoundManager.Instance.PlaySound(Globals.Click_2);
        EventCenter.Instance.EventTrigger("HideBtn");
        PlayerMove.ISMove = false;
        UIManager.Instance.OpenPanel(UIConst.MakeUI);
    }

    public void CloseMakeUI()
    {
        SoundManager.Instance.PlaySound(Globals.Click_2);
        PlayerMove.ISMove = true;
        UIManager.Instance.ClosePanel(UIConst.MakeUI);
    }
}
