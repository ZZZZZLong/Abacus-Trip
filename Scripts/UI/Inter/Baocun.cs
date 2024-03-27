using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baocun : BasePanel
{
    public void OpenBaocun()
    {
        UIManager.Instance.OpenPanel(UIConst.Baocun);
    }

    public void CloseBaocun()
    {
        UIManager.Instance.ClosePanel(UIConst.Baocun);
    }
}
