using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodAdd : MonoBehaviour
{
    public GameObject Button;

    private void OnTriggerEnter2D(Collider2D other)
    {
        EventCenter.Instance.AddEventListener("HideBtn", HideBtn);
        Button.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Button.SetActive(false);
    }
    void HideBtn()
    {
        if (Button != null)
        {
            Button.SetActive(false);
        }
    }

    private void Update()
    {
        if (Button.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            Button.SetActive(false);
            //talkUI.SetActive(true);//ʰȡ��Ʒ��ʾ
            CellLocalData.Instance.addMood(1, "ľ��", "�ջ𣿻�����������ʲô�أ�", "Package/Wood");
            Debug.Log("��Ʒ����Ϊ��" + GameManager.Instance.cellTable.DataList.Count);
        }
    }
}
