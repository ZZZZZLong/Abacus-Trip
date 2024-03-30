using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockUI : BasePanel
{
    public void CloseBlock()
    {
        UIManager.Instance.ClosePanel(UIConst.Block);
        PlayerMove.ISMove = true;
    }
}
