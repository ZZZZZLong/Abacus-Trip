using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerData : MonoBehaviour
{

    public Vector2 Position => transform.position;//将摄像机物体挂上脚本,获取到摄像机Vector3



    public void Save(string FileName)
    {
        SaveByJson(FileName); 
    }
    public void Load(string FileName)
    {
        LoadFromJson(FileName);
    }

    void SaveByJson(string FileName)
    {
        //SaveSystem.SaveByJson(PLAYER_DATA_FILE_NAME, SavingData());
        SaveSystem.SaveByJson($"{FileName}.sav", SavingData());
    }

    void LoadFromJson(string FileName)
    {
        var saveData = SaveSystem.LoadFromJson<SaveData>($"{FileName}.sav");

        LoadData(saveData);
    }


    SaveData SavingData()//在这里面添加要存的内容 下面也要加
    {
        var saveData = new SaveData();
        //需要存储的数据
        saveData.playerPosition = transform.position;
        saveData.Save_Time = DateTime.Now.ToString("HH:mm:ss");
        saveData.Save_Date = DateTime.Now.ToString("yyyy/MM/dd");
        //存储背包数据
        saveData.cells = GameManager.Instance.cellTable.DataList;

        return saveData;
    }

    void LoadData(SaveData saveData)//要读取的数据
    { 
        transform.position = saveData.playerPosition;
        GameManager.Instance.cellTable.DataList = saveData.cells;
    }
}

[System.Serializable]
class SaveData
{
    //角色数据
    public Vector3 playerPosition; //
    public string Save_Time;
    public string Save_Date;
    public List<CellTableItem> cells;
}
