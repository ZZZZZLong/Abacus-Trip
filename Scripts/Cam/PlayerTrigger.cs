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
        Debug.Log("�������ʼ�ƶ�");
        PlayerMove.ISMove = false;//��Ҳ��ܶ�
        StartCoroutine(ShowDiaLog());
    }

    IEnumerator ShowDiaLog()
    {
        yield return new WaitForSeconds(2);//120֡����
        DiaLogPanel.SetActive(true);
        gameObject.SetActive(false);
    }


}
