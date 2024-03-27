using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class QDBC : MonoBehaviour
{
    bool isNew;
    public void OpenQDBC(Button button)
    {
        Transform parent = button.transform.parent.parent;
        GameObject QDBC = parent.Find("QDBC").gameObject;
        GameObject Empty = button.transform.GetChild(1).gameObject;
        isNew = Empty.activeSelf;

        if (isNew)
        {
            EventCenter.Instance.EventTrigger<Button>("GetSave", button);
        }
        else if(!isNew)
        {
            EventCenter.Instance.EventTrigger<Button>("GetButton", button);
            QDBC.SetActive(true);
        }
    }
    public static void OverQDBC(Button button)
    {
        Transform parent = button.transform.parent.parent;
        GameObject QDBC = parent.Find("QDBC").gameObject;
        EventCenter.Instance.EventTrigger<Button>("GetSave", button);
        QDBC.SetActive(false);
    }


    public void CloseQDBC(GameObject QDBC)
    {
        QDBC.SetActive(false);

    }
}
