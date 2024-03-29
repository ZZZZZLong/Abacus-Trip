using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public GameObject CamManager;
    public GameObject DiaLogPanel;
    Cam cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cam = CamManager.GetComponent<Cam>();
        cam.enabled = true;
        Debug.Log("�������ʼ�ƶ�");
        gameObject.SetActive(false);
        PlayerMove.ISMove = false;//��Ҳ��ܶ�
        StartCoroutine(ShowDiaLog());
    }

    IEnumerator ShowDiaLog()
    {
        yield return new WaitForSeconds(2);//120֡����
        DiaLogPanel.SetActive(true);
    }


}
