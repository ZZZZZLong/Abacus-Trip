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

        Debug.Log("我在点");
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

            // 如果子对象不是当前点击的物体，则销毁它
            if (child != transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
