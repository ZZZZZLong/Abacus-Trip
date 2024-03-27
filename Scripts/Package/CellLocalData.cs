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
        newItem.imagePath = ImagePath; // ����ͼƬ·��
        cellTable.DataList.Add(newItem);
        // �����Ҫ������������� cellTable�����Ե��� UpdateCellTable() ����
        UpdateCellTable();
    }
}
