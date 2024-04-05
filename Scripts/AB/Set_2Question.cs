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
            txt.text = "�����";
        }
        else if (num == 94)
        {
            SetTrue(1);
            txt.text = "�����";
        }
        else if (num == 47)
        {
            SetTrue(2);
            txt.text = "�����";
        }
        else if (num == 12)
        {
            SetTrue(3);
            txt.text = "�����";
        }
        else if (num == 23)
        {
            SetTrue(4);
            txt.text = "�����";
        }
        else
        {
            Debug.Log(num);
            txt.text = "������Ŷ���ټ��һ�°�";
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

            //��ʾһ����ϲ�����˵�UI
            //ͨ��Э��2s�������һ������
        }
    }
}
