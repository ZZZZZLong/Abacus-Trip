using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static void SaveByJson(string saveFileName, object data)
    {
        var json = JsonUtility.ToJson(data);

        var path = Path.Combine(Application.persistentDataPath,saveFileName);

        File.WriteAllText(path, json);

        
        try
        {
            Debug.Log($"成功存档数据在{path}");

        }
        catch (System.Exception exception)
        {
            Debug.LogError($"存档到{path}失败.\n{exception}");
        }
    }

    public static T LoadFromJson<T>(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        try
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<T>(json);
            return data;
        }
        catch (System.Exception exception)
        {
            Debug.LogError($"存档读取失败在{path}. \n{exception}");
            return default;
        }

    }

    public static void DeleteSaveFlie(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);


        try
        {
            File.Delete(path);
        }
        catch(System.Exception exception) 
        {
            Debug.LogError($"存档位置错误:{path}. \n{exception}");
        }


    }
}

/* 使用方法：
    1.声明一个函数来实现SaveSystem.SaveByJson(PLAYER_DATA_FILE_NAME, SavingData());
    2.声明一个常量来显示存档数据的存档名称 const String PLAYER_DATA_FILE_NAME = "PlayerData.zs"//后缀随便改
    3.保存玩家数据的SaveData类和方法SavingData
    4.测试一次提交

 
 
 
 
 */
