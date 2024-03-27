using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ZZZZZLong/CellTable", fileName = "CellTable")]

public class CellTable : ScriptableObject
{
    public List<CellTableItem> DataList = new List<CellTableItem>();
}
[System.Serializable]
public class CellTableItem
{
    public int id;//��id�ж�����
    public string name;//��ʾ�ı�
    public string description;//��ʾ�ı�
    public string imagePath;//��ȡͼƬ
}
