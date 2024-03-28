using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CellDetail : MonoBehaviour
{
    private Transform UIDescription;
    private Transform UIIcon;
    private Transform UITitle;
    public GameObject UseButton;
    GameObject NPC;
    int Mood_i;

    void Awake()
    {
        InitUIName();
        //Refresh(0);
    }

    private void InitUIName()
    {
        UITitle = transform.Find("Title");
        UIIcon = transform.Find("Icon");
        UIDescription = transform.Find("Description");
        UseButton.SetActive(false);
    }
    public void Refresh(int i)
    {
        Mood_i = i;//ˢ�º�ֵ
        Sprite loadedSprite = Resources.Load<Sprite>(GameManager.Instance.cellTable.DataList[i].imagePath);
        UITitle.GetComponent<Text>().text = GameManager.Instance.cellTable.DataList[i].name;
        UIIcon.GetComponent<Image>().sprite = loadedSprite;
        UIDescription.GetComponent<Text>().text = GameManager.Instance.cellTable.DataList[i].description;
        UseButton.SetActive(true);
    }

    public void UseBtn()
    {
        Debug.Log(GameManager.Instance.cellTable.DataList[Mood_i].name);//����ʹ�ú��������¼�
        string Mood_name = GameManager.Instance.cellTable.DataList[Mood_i].name;
        UIManager.Instance.ClosePanel(UIConst.PackageCon);
        PlayerMove.ISMove = true;
        if (Mood_name == "ľ���ֵܵ��ֵܵ��ֵ�")//���������Ʒ�¼�
        {
            EventCenter.Instance.EventTrigger("ShowDia","NPC1");
        }
    }


}
