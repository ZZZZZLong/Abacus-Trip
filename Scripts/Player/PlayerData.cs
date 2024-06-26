using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{

    public Vector2 Position => transform.position;//获取到主角的Vector3

    private string sceneName; // 私有字段用于存储场景名称

    //public string sceneName
    //{
    //    get { return _sceneName; } // 获取场景名称的属性访问器

    //    set
    //    {
    //        Scene currentScene = SceneManager.GetActiveScene();
    //        // 获取当前场景的名称并存储到私有字段中
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


    SaveData SavingData()//在这里面添加要存的内容 下面也要加
    {
        Scene currentScene = SceneManager.GetActiveScene();
        // 获取当前场景的名称并存储到私有字段中
        sceneName = currentScene.name;

        var saveData = new SaveData();
        //需要存储的数据
        saveData.playerPosition = transform.position;
        saveData.Save_Time = DateTime.Now.ToString("HH:mm:ss");
        saveData.Save_Date = DateTime.Now.ToString("yyyy/MM/dd");
        saveData.SceneName = sceneName;
        Debug.Log(sceneName);
        //存储背包数据
        saveData.cells_1 = GameManager.Instance.cellTable_Scene1.DataList;
        saveData.cells_2 = GameManager.Instance.cellTable_Scene2.DataList;
        saveData.cells_3 = GameManager.Instance.cellTable_Scene3.DataList;

        return saveData;
    }

    void LoadData(SaveData saveData)//要读取的数据
    {
        //GameManager.Instance.Player.transform.position = saveData.playerPosition;在对话游戏中不好用
        //GameManager.Instance.cellTable.DataList = saveData.cells;
        //LoadManager.Instance.sceneName = saveData.SceneName;
        if(saveData.SceneName == "Scene_1")
        {
            GameManager.Instance.cellTable.DataList = saveData.cells_1;
        }
        else if (saveData.SceneName == "Scene_2")
        {
            GameManager.Instance.cellTable.DataList = saveData.cells_2;
        }
        else if (saveData.SceneName == "Scene_3")
        {
            GameManager.Instance.cellTable.DataList = saveData.cells_3;
            Debug.Log("读取了");
        }

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
    //角色数据
    public Vector3 playerPosition; //
    public string Save_Time;
    public string Save_Date;
    public string SceneName;
    public List<CellTableItem> cells_1;
    public List<CellTableItem> cells_2;
    public List<CellTableItem> cells_3;
}
