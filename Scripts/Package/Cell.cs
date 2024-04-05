
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
        index = transform.GetSiblingIndex();//֪���Լ������������ǵڼ���
        Transform DetailPanel = transform.parent.parent.parent.parent.Find("DetailPanel");
        detail = DetailPanel.GetComponent<CellDetail>();
        //GetMood();
    }

    public void GetMood()
    {
        transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(GameManager.Instance.cellTable.DataList[index].imagePath);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SoundManager.Instance.PlaySound(Globals.Click_2);
        MakeCell_Index = GameManager.Instance.MakeCell_Index;
        detail.Refresh(index);
        GameObject clickedObject = eventData.pointerPress;
        Sprite imageComponent_Sprite = clickedObject.GetComponent<Image>().sprite;
        GameObject MakecellContent = GameObject.Find("Canvas/MakeUI(Clone)/Panel/Content");
        if(MakecellContent != null)
        {
            UIManager.Instance.ClosePanel(UIConst.PackageCon);
            MakeMoodCell makeoneCell = MakecellContent.transform.GetChild(MakeCell_Index).GetComponent<MakeMoodCell>();
            makeoneCell.SetImage(imageComponent_Sprite, index);//��һ�������úϳɽ���֪����Ʒ����Ϣ
        }
    }
}
