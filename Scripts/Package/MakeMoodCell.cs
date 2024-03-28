using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MakeMoodCell : MonoBehaviour,IPointerClickHandler
{
    int MakeCell_Index;
    public int MoodId;
    public Transform Mood_Name;

    void Awake()
    {
        MakeCell_Index = this.transform.GetSiblingIndex();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        UIManager.Instance.OpenPanel(UIConst.PackageCon);
        GameManager.Instance.MakeCell_Index = MakeCell_Index;
    }
    public void SetImage(Sprite newSprite,int i)
    {
        MoodId = i;//得到物品的信息
        Debug.Log(MoodId);
        if(GameManager.Instance.cellTable.DataList.Count == 1)
        {
            Mood_Name.GetComponent<Text>().text = GameManager.Instance.cellTable.DataList[0].name;
        }
        else
        {
            Mood_Name.GetComponent<Text>().text = GameManager.Instance.cellTable.DataList[MakeCell_Index].name; //为text赋值

        }
       
        Image image = this.transform.GetComponent<Image>();
        if (image != null)
        {
            image.sprite = newSprite;
        }
        else
        {
            Debug.LogError("Image component not found on the current GameObject.");
        }
    }

}
