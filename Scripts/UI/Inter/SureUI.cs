using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SureUI : BasePanel
{
    public void EnterNextScene()
    {
        if(GameManager.Instance.FileName == "Scene_1")
        {
            GameManager.Instance.isCanEnter_1 = false;//合成了算盘才可以睡觉
            LoadManager.Instance.LoadNextLevel("Scene_3");
        }
        else if(GameManager.Instance.FileName == "Scene_3")
        {
            Debug.Log("进入最终场景");

            LoadManager.Instance.LoadNextLevel("Scene_4");
        }
        Debug.Log(GameManager.Instance.FileName);
        UIManager.Instance.ClosePanel(UIConst.Sure);
    }

    public void CloseSureUI()
    {
        UIManager.Instance.ClosePanel(UIConst.Sure);
        PlayerMove.ISMove = true;
    }
}
