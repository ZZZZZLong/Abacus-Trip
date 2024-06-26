using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void RemoveMood(int id)
    {
        List<CellTableItem> itemsToRemove = new List<CellTableItem>();
        foreach (CellTableItem item in GameManager.Instance.cellTable.DataList)
        {
            if (item.id == id)
            {
                itemsToRemove.Add(item);
            }
        }

        // 删除标记的元素
        foreach (CellTableItem itemToRemove in itemsToRemove)
        {
            GameManager.Instance.cellTable.DataList.Remove(itemToRemove);
        }
    }
}
