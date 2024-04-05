using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookAdd : MonoBehaviour
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
            CellLocalData.Instance.addMood(9, "�����㷨", "����ͬ����Ի:����ͷ�������㣬�����㣬��ͷ���㣬�����ͷ������", "Package/Book");
            Debug.Log("��Ʒ����Ϊ��" + GameManager.Instance.cellTable.DataList.Count);
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            UIManager.Instance.OpenPanel(UIConst.NewMood);
            GameManager.Instance.isCanEnter_1 = true;
            StartCoroutine(CloseTip());
            // ����Ƿ��ҵ�����ײ�����
            if (collider != null)
            {
                // ������ײ��
                collider.enabled = false;
            }
            else
            {
                Debug.LogWarning("����û����ײ�������");
            }

        }
    }
    IEnumerator CloseTip()
    {
        yield return new WaitForSeconds(1);
        UIManager.Instance.ClosePanel(UIConst.NewMood);
    }
}
