using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class CellLocalData : Singleton_Mono<CellLocalData>
{
    CellTable cellTable;

    void Awake()
    {
        UpdateCellTable();
    }

    void UpdateCellTable()
    {
        cellTable = GameManager.Instance.cellTable;
    }

    public void addMood(int i, string New_Item, string Description, string ImagePath)
    {
        CellTableItem newItem = new CellTableItem();
        newItem.id = i;
        newItem.name = New_Item;
        newItem.description = Description;
        newItem.imagePath = ImagePath; // 设置图片路径
        cellTable.DataList.Add(newItem);
        // 如果需要在添加新项后更新 cellTable，可以调用 UpdateCellTable() 方法
        UpdateCellTable();
    }
}
