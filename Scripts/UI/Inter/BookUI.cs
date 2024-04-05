using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookUI : BasePanel
{
    public void OpenBookUI()
    {
        SoundManager.Instance.PlaySound(Globals.Click_2);
        UIManager.Instance.OpenPanel(UIConst.Book);//´ò¿ª
    }

    public void CloseBookUI()
    {
        SoundManager.Instance.PlaySound(Globals.Click_2);
        UIManager.Instance.ClosePanel(UIConst.Book);
    }
}
