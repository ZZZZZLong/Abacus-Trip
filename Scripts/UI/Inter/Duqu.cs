using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duqu : BasePanel
{
    public void OpenDuqu()
    {
        SoundManager.Instance.PlaySound(Globals.Click_2);
        UIManager.Instance.OpenPanel(UIConst.Duqu);
    }

    public void CloseDuqu()
    {
        SoundManager.Instance.PlaySound(Globals.Click_2);
        UIManager.Instance.ClosePanel(UIConst.Duqu);
    }
}
