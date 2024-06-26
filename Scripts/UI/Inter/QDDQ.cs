using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QDDQ : MonoBehaviour
{
    public void OpenQDDQ(Button button)
    {
        SoundManager.Instance.PlaySound(Globals.Click_2);
        Transform parent = button.transform.parent.parent;
        GameObject QDDQ = parent.Find("QDDQ").gameObject;
        EventCenter.Instance.EventTrigger<Button>("GetButton", button);
        QDDQ.SetActive(true);
    }

    public void CloseQDDQ(GameObject QDDQ)
    {
        SoundManager.Instance.PlaySound(Globals.Click_2);
        QDDQ.SetActive(false);
    }
}
