using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReTip : MonoBehaviour
{
    public GameObject tip;
    public void OnBtnClick()
    {
        SoundManager.Instance.PlaySound(Globals.Click_2);
        tip.SetActive(true);
    }
}
