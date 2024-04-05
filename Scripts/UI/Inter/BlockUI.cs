using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockUI : BasePanel
{
    public void CloseBlock()
    {
        SoundManager.Instance.PlaySound(Globals.Click_2);
        UIManager.Instance.ClosePanel(UIConst.Block);
        PlayerMove.ISMove = true;
    }
}
