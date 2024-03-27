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
    public int id;//用id判断物体
    public string name;//显示文本
    public string description;//显示文本
    public string imagePath;//获取图片
}
