using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowDang : MonoBehaviour,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {

        DesOtherImage();

        Debug.Log("���ڵ�");
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

            // ����Ӷ����ǵ�ǰ��������壬��������
            if (child != transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
