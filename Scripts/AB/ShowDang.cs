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

        // 遍历父对象的所有子对象
        for (int i = parent.childCount - 1; i >= 0; i--)
        {
            Transform child = parent.GetChild(i);
            Image image = child.GetComponent<Image>();
            Color imageColor = image.color;

            // 如果子对象不是当前点击的物体，则销毁它
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
