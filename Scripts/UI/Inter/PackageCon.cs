using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageCon : BasePanel
{
    Transform ContentRoot;
    //Transform CellDetail;
    
    private void Awake()
    {
        ContentRoot = transform.Find("PackagePanel/Center/Scroll View/Viewport/Content");
        //CellDetail = transform.Find("PackagePanel/Center/DetailPanel");
        EventCenter.Instance.AddEventListener("AddCell",AddCell);//在其他函数中触发事件
        LoadPackage();
    }

    public void AddCell()
    {
        GameObject CellPrefab = Resources.Load<GameObject>("Prefabs/UI/Cell");
        GameObject Cell = GameObject.Instantiate(CellPrefab, ContentRoot, false);
        Cell cell = Cell.GetComponent<Cell>();
        cell.GetMood();//为Cell赋予图片
    }

    public void LoadPackage()
    {
        CellTable CellData = GameManager.Instance.cellTable;
        if (ContentRoot != null)
        {
            for (int i = 0; i < CellData.DataList.Count; i++)
            {
                AddCell();
            }
        }
    }
    public void OpenPackage()
    {
        SoundManager.Instance.PlaySound(Globals.Click_2);
        EventCenter.Instance.EventTrigger("HideBtn");
        PlayerMove.ISMove = false;
        UIManager.Instance.OpenPanel(UIConst.PackageCon);
    }

    public void ClosePackage()
    {
        SoundManager.Instance.PlaySound(Globals.Click_2);
        PlayerMove.ISMove = true;
        UIManager.Instance.ClosePanel(UIConst.PackageCon);
    }
}
