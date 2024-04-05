using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Set_2Question : SetQuestion
{
    public override void DaGou()
    {
        Text txt = JieGuo.transform.GetComponent<Text>();
        GetNum GNum = Number.GetComponent<GetNum>();
        double num = GNum.total;


        if (num == 35)
        {
            SetTrue(0);
            txt.text = "答对啦";
        }
        else if (num == 94)
        {
            SetTrue(1);
            txt.text = "答对啦";
        }
        else if (num == 47)
        {
            SetTrue(2);
            txt.text = "答对啦";
        }
        else if (num == 12)
        {
            SetTrue(3);
            txt.text = "答对啦";
        }
        else if (num == 23)
        {
            SetTrue(4);
            txt.text = "答对啦";
        }
        else
        {
            Debug.Log(num);
            txt.text = "有问题哦，再检查一下吧";
        }
        FinshedAB();
    }

    public override void FinshedAB()
    {
        bool allTogglesChecked = true;
        foreach (Toggle toggle in toggles)
        {
            if (!toggle.isOn)
            {
                allTogglesChecked = false;
                break;
            }
        }

        if (allTogglesChecked)
        {
            UIManager.Instance.OpenPanel(UIConst.Suc);
            StartCoroutine(LoadNextSceneAfterDelay("Scene_6"));

            //显示一个恭喜你答对了的UI
            //通过协程2s后进入下一个场景
        }
    }
}
