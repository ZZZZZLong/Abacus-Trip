using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suc : BasePanel
{
    private void Start()
    {
        StartCoroutine(LoadNextSceneAfterDelay());
    }

    IEnumerator LoadNextSceneAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        // �ڴ˴�������һ���������߼�
        UIManager.Instance.ClosePanel(UIConst.Suc);
        LoadManager.Instance.LoadNextLevel("Scene_5");
    }
}
