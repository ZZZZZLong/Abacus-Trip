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
        ObjImage = transform.GetChild(i).gameObject;//找到初始状态的图片
    }
    public void OnPointerClick(PointerEventData eventData)
    {

        ObjImage.SetActive(false);
        i++;
        if (i == ObjImage.transform.parent.childCount)
        {

            i = 0;//
        }
        ObjImage = transform.GetChild(i).gameObject;//点击图片，对象物品的对象发生变化
        ObjImage.SetActive(true);

    }
}
