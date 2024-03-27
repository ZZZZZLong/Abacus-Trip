using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duqu : BasePanel
{
    public void OpenDuqu()
    {
        UIManager.Instance.OpenPanel(UIConst.Duqu);
    }

    public void CloseDuqu()
    {
        UIManager.Instance.ClosePanel(UIConst.Duqu);
    }
}
