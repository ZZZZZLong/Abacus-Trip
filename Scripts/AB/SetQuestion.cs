using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetQuestion : MonoBehaviour
{
    
    public Toggle[] toggles;
    public GameObject Number;
    public GameObject JieGuo;

    private void Start()
    {
        toggles = new Toggle[transform.childCount];
        for (int i = 0; i<transform.childCount;i++)
        {
            Toggle toggle = transform.GetChild(i).GetComponent<Toggle>();
            toggles[i] = toggle;
            Debug.Log(toggle);
        }//给集合赋值
        EventCenter.Instance.AddEventListener("TiJiaoDaAn", DaGou);
    }

    public void SetTrue(int i)
    {
        toggles[i].isOn = true;
    }


    public virtual void DaGou()//注册事件
    {
        Text txt = JieGuo.transform.GetComponent<Text>();
        GetNum GNum = Number.GetComponent<GetNum>();
        double num = GNum.total;


        if(num == 100)
        {
            SetTrue(0);
            txt.text = "答对啦";
        }
        else if(num == 5132)
        {
            SetTrue(1);
            txt.text = "答对啦";
        }
        else if(num == 98742.19)
        {
            SetTrue(2);
            txt.text = "答对啦";
        }
        else
        {
            Debug.Log(num);
            txt.text = "有问题哦，再检查一下吧";
        }
        FinshedAB();
    }

    public virtual void FinshedAB()
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
            StartCoroutine(LoadNextSceneAfterDelay("Scene_5"));

            //显示一个恭喜你答对了的UI
            //通过协程2s后进入下一个场景
        }
    }

    public IEnumerator LoadNextSceneAfterDelay(string SName)
    {
        yield return new WaitForSeconds(2f);
        // 在此处加载下一个场景的逻辑
        UIManager.Instance.ClosePanel(UIConst.Suc);
        LoadManager.Instance.LoadNextLevel(SName);
    }

}
