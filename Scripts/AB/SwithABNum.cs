using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwithABNum : MonoBehaviour, IPointerClickHandler
{
    int i;
    GameObject ObjImage;
    private void Start()
    {
        i = 0;
        ObjImage = transform.GetChild(i).gameObject;//�ҵ���ʼ״̬��ͼƬ
    }
    public void OnPointerClick(PointerEventData eventData)
    {

        ObjImage.SetActive(false);
        i++;
        if (i == ObjImage.transform.parent.childCount)
        {

            i = 0;//
        }
        ObjImage = transform.GetChild(i).gameObject;//���ͼƬ��������Ʒ�Ķ������仯
        ObjImage.SetActive(true);

    }
}
