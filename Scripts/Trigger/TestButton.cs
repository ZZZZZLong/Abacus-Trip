using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{

    public void Fnished()
    {
        GameManager.Instance.isCanEnter_1 = true;
        LoadManager.Instance.LoadNextLevel("Scene_5");
    }

    public void Fnished_2()
    {
        GameManager.Instance.isCanEnter_1 = true;
        LoadManager.Instance.LoadNextLevel("Scene_6");
    }
}
