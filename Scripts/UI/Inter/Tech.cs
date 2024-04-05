using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tech : BasePanel
{
    public void OpenTech()
    {
        PlayerMove.ISMove = false;
        UIManager.Instance.OpenPanel(UIConst.Tech);
    }

    public void CloseTech()
    {
        PlayerMove.ISMove = true;
        UIManager.Instance.ClosePanel(UIConst.Tech);
    }
}
