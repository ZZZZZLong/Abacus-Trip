using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cell : MonoBehaviour, IPointerClickHandler
{
    int index;
    int MakeCell_Index;
    CellDetail detail;
    void Awake()
    {
        index = this.transform.GetSiblingIndex();//知道自己在子物体中是第几个
        Transform DetailPanel = this.transform.parent.parent.parent.parent.Find("DetailPanel");
        detail = DetailPanel.GetComponent<CellDetail>();
        //GetMood();
    }

    public void GetMood()
    {
        this.transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(GameManager.Instance.cellTable.DataList[index].imagePath);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        MakeCell_Index = GameManager.Instance.MakeCell_Index;
        detail.Refresh(index);
        GameObject clickedObject = eventData.pointerPress;
        Sprite imageComponent_Sprite = clickedObject.GetComponent<Image>().sprite;
        GameObject MakecellContent = GameObject.Find("Canvas/MakeUI(Clone)/Panel/Content");
        if(MakecellContent != null)
        {
            UIManager.Instance.ClosePanel(UIConst.PackageCon);
            MakeMoodCell makeoneCell = MakecellContent.transform.GetChild(MakeCell_Index).GetComponent<MakeMoodCell>();
            makeoneCell.SetImage(imageComponent_Sprite, GameManager.Instance.cellTable.DataList[index].id);//传一个索引让合成界面知道物品的信息
        }
    }
}
