using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public GameObject CamManager;
    public GameObject DiaLogPanel;
    Cam_1 cam;


    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        cam = CamManager.GetComponent<Cam_1>();
        cam.enabled = true;
        Debug.Log("摄像机开始移动");
        PlayerMove.ISMove = false;//玩家不能动
        StartCoroutine(ShowDiaLog());
    }

    IEnumerator ShowDiaLog()
    {
        yield return new WaitForSeconds(2);//120帧过后
        DiaLogPanel.SetActive(true);
        gameObject.SetActive(false);
    }


}
