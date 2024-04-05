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
        EventCenter.Instance.AddEventListener("ReStart", Restart);
        i = 0;
        ObjImage = transform.GetChild(i).gameObject;//�ҵ���ʼ״̬��ͼƬ
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        SoundManager.Instance.PlaySound(Globals.Click);
        ObjImage.SetActive(false);
        i++;
        if (i == ObjImage.transform.parent.childCount)
        {

            i = 0;//
        }
        ObjImage = transform.GetChild(i).gameObject;//���ͼƬ��������Ʒ�Ķ������仯
        ObjImage.SetActive(true);

    }

    public void Restart()
    {
        SoundManager.Instance.PlaySound(Globals.Click);
        BackZ();
        ObjImage = transform.GetChild(0).gameObject;
        ObjImage.SetActive(true);
        i = 0;
    }

    void BackZ()
    {   
        for(int j = 0; j< ObjImage.transform.parent.childCount;j++)
        {
            ObjImage = transform.GetChild(i).gameObject;//���ͼƬ��������Ʒ�Ķ������仯
            ObjImage.SetActive(false);
        }
        
    }
}
