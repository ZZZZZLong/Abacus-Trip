using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowDang : MonoBehaviour,IPointerClickHandler
{
    private void Start()
    {
        EventCenter.Instance.AddEventListener("ReStart", ReStart);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        SoundManager.Instance.PlaySound(Globals.Click);
        DesOtherImage();
        Image image = transform.GetComponent<Image>();
        Color imageColor = image.color;
        imageColor.a = 1f;
        image.color = imageColor;

    }

    void DesOtherImage()
    {
        Transform parent = transform.parent;

        // ����������������Ӷ���
        for (int i = parent.childCount - 1; i >= 0; i--)
        {
            Transform child = parent.GetChild(i);
            Image image = child.GetComponent<Image>();
            Color imageColor = image.color;

            // ����Ӷ����ǵ�ǰ��������壬��������
            if (child != transform)
            {
                imageColor.a = 0f;
                image.color = imageColor;
            }
        }
    }
    void ReStart()
    {
        Image image = transform.GetComponent<Image>();
        Color imageColor = image.color;
        imageColor.a = 0f;
        image.color = imageColor;
    }

}
