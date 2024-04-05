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
        }//�����ϸ�ֵ
        EventCenter.Instance.AddEventListener("TiJiaoDaAn", DaGou);
    }

    public void SetTrue(int i)
    {
        toggles[i].isOn = true;
    }


    public virtual void DaGou()//ע���¼�
    {
        Text txt = JieGuo.transform.GetComponent<Text>();
        GetNum GNum = Number.GetComponent<GetNum>();
        double num = GNum.total;


        if(num == 100)
        {
            SetTrue(0);
            txt.text = "�����";
        }
        else if(num == 5132)
        {
            SetTrue(1);
            txt.text = "�����";
        }
        else if(num == 98742.19)
        {
            SetTrue(2);
            txt.text = "�����";
        }
        else
        {
            Debug.Log(num);
            txt.text = "������Ŷ���ټ��һ�°�";
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

            //��ʾһ����ϲ�����˵�UI
            //ͨ��Э��2s�������һ������
        }
    }

    public IEnumerator LoadNextSceneAfterDelay(string SName)
    {
        yield return new WaitForSeconds(2f);
        // �ڴ˴�������һ���������߼�
        UIManager.Instance.ClosePanel(UIConst.Suc);
        LoadManager.Instance.LoadNextLevel(SName);
    }

}
