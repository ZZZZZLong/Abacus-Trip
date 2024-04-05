using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baocun : BasePanel
{
    public void OpenBaocun()
    {
        SoundManager.Instance.PlaySound(Globals.Click_2);
        UIManager.Instance.OpenPanel(UIConst.Baocun);
    }

    public void CloseBaocun()
    {
        SoundManager.Instance.PlaySound(Globals.Click_2);
        UIManager.Instance.ClosePanel(UIConst.Baocun);
    }
}
