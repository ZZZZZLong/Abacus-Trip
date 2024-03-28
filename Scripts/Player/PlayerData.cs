using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.PlayerSettings;

public class PlayerData : MonoBehaviour
{

    public Vector2 Position => transform.position;//��ȡ�����ǵ�Vector3

    private string sceneName; // ˽���ֶ����ڴ洢��������

    //public string sceneName
    //{
    //    get { return _sceneName; } // ��ȡ�������Ƶ����Է�����

    //    set
    //    {
    //        Scene currentScene = SceneManager.GetActiveScene();
    //        // ��ȡ��ǰ���������Ʋ��洢��˽���ֶ���
    //        _sceneName = currentScene.name;
    //    }
    //}

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
        Scene currentScene = SceneManager.GetActiveScene();
        // ��ȡ��ǰ���������Ʋ��洢��˽���ֶ���
        sceneName = currentScene.name;

        var saveData = new SaveData();
        //��Ҫ�洢������
        saveData.playerPosition = transform.position;
        saveData.Save_Time = DateTime.Now.ToString("HH:mm:ss");
        saveData.Save_Date = DateTime.Now.ToString("yyyy/MM/dd");
        saveData.SceneName = sceneName;
        Debug.Log(sceneName);
        //�洢��������
        saveData.cells = GameManager.Instance.cellTable.DataList;

        return saveData;
    }

    void LoadData(SaveData saveData)//Ҫ��ȡ������
    {
        GameManager.Instance.Player.transform.position = saveData.playerPosition;
        GameManager.Instance.cellTable.DataList = saveData.cells;
        //LoadManager.Instance.sceneName = saveData.SceneName;
    }
    
    
    public string LoadScene_Name(string FileName)
    {
        var saveData = SaveSystem.LoadFromJson<SaveData>($"{FileName}.sav");
        return saveData.SceneName;
    }

}

[System.Serializable]
class SaveData
{
    //��ɫ����
    public Vector3 playerPosition; //
    public string Save_Time;
    public string Save_Date;
    public string SceneName;
    public List<CellTableItem> cells;
}
