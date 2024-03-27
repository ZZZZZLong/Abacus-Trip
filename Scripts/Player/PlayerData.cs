using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerData : MonoBehaviour
{

    public Vector2 Position => transform.position;//�������������Ͻű�,��ȡ�������Vector3



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


    SaveData SavingData()//�����������Ҫ������� ����ҲҪ��
    {
        var saveData = new SaveData();
        //��Ҫ�洢������
        saveData.playerPosition = transform.position;
        saveData.Save_Time = DateTime.Now.ToString("HH:mm:ss");
        saveData.Save_Date = DateTime.Now.ToString("yyyy/MM/dd");
        //�洢��������
        saveData.cells = GameManager.Instance.cellTable.DataList;

        return saveData;
    }

    void LoadData(SaveData saveData)//Ҫ��ȡ������
    { 
        transform.position = saveData.playerPosition;
        GameManager.Instance.cellTable.DataList = saveData.cells;
    }
}

[System.Serializable]
class SaveData
{
    //��ɫ����
    public Vector3 playerPosition; //
    public string Save_Time;
    public string Save_Date;
    public List<CellTableItem> cells;
}
